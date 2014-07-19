(function () {
    'use strict';
    require.config({
        paths: {
            "underscore": "libs/underscore",
            "chance": "libs/chance"
        }
    });

    require(['underscore', 'students', 'animals', 'books'], function (_, students, animals, books) {

        function showArray(array, title) {
            if (!(array instanceof Array)) {
                throw new TypeError('Array is not instance of Array');
            }
            function padRight(str, len) {
                if (typeof str !== 'string') {
                    str = str.toString();
                }
                len = len || 35;
                return str + new Array(len + 1 - str.length).join(' ');
            }

            console.warn(title);
//            console.log('Count: ' + array.length);
            console.log(new Array(40).join('-'));
            if (array.length === 0) {
                console.log([]);
            }
            else {
                array.forEach(function (item) {
                    var result = '';
                    for (var prop in item) {
                        var propValueSpacing;
                        if (item[prop].length > 10) {
                            propValueSpacing = item[prop].length + 5;
                        }
                        else {
                            propValueSpacing = 10
                        }
                        result += '' + padRight(prop, prop.length) + ': ' + padRight(item[prop], propValueSpacing);
                    }
                    console.log(result);
                });
            }
            console.log(new Array(40).join('*'));
            console.log('');
        }

        showArray(students, 'Initial Array of students');

        /* 1. Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Print the students in descending order by full name. Use Underscore.js */
        var filterAndSortFirstNameBeforeLastName = _.chain(students)
            .filter(function (student) {
                if (student.firstName < student.lastName) {
                    return true;
                } else {
                    return false;
                }
            })
            .sortBy('firstName')
            .reverse()
            .value();
        showArray(filterAndSortFirstNameBeforeLastName, '1. Filtered and sorted');

        /* 2. Write function that finds the first name and last name of all students with age between 18 and 24.*/
        var studentsBetween18and24 = _.filter(students, function (student) {
            return !!(student.age >= 18 && student.age <= 24);
        });
        showArray(studentsBetween18and24, '2. All students with age between 18 and 24.');

        /* 3. Write a function that by a given array of students finds the student with highest marks*/
        var bestStudent = _.max(students, function (student) {
            return (_.reduce(student.marks, function (a, b) {
                return a + b;
            }, 0) / student.marks.length);
        });
        showArray([bestStudent], "3. Student with best grates");


        /*All animals*/
        showArray(animals, 'All initial animals');

        /* 4. Write a function that by a given array of animals, groups them by species and sorts them by number of legs*/
        var groupedAnimals = _.chain(animals)
            .sortBy('legsCount')
            .groupBy('specie')
            .value();
        console.log('---------------------!!! 4. Animal grouped by specie and sort by legs!!!--------------------');
        _.each(groupedAnimals, function (group) {
            showArray(group, group[0].specie);
        });

        /* 5. By a given array of animals, find the total number of legs*/
        var totalSumOfLegs = 0;
        _.each(animals, function (animal) {
            totalSumOfLegs += animal.legsCount;
        });
        console.log('---------------------!!! 5. Total Sum of animals legs!!!--------------------');
        console.log('Total legs: ' + totalSumOfLegs);


        showArray(books, 'All books');
        /* 6. By a given collection of books, find the most popular author (the author with the highest number of books)*/
        var mostPopularAuhtor = _.chain(books)
            .groupBy('author')
            .max(function (books) {
                return books.length;
            })
            .value();
        showArray(mostPopularAuhtor, '6. Most popular author is: ' + mostPopularAuhtor[0].author);


        /* 7. By an array of people find the most common first and last name. Use underscore*/
        var newPeople = [
            {
                firstName: 'Pesho',
                lastName: 'Petrov',
                age: 16
            },
            {
                firstName: 'Ivan',
                lastName: 'Goshov',
                age: 23
            },
            {
                firstName: 'Pesho',
                lastName: 'Atanasov',
                age: 12
            },
            {
                firstName: 'Hristo',
                lastName: 'Georgiev',
                age: 20
            },
            {
                firstName: 'Doncho',
                lastName: 'Minkov',
                age: 23
            },
            {
                firstName: 'Pesho',
                lastName: 'Ivanov',
                age: 16
            },
            {
                firstName: 'Gosho',
                lastName: 'Goshov',
                age: 56
            },
            {
                firstName: 'Ivaylo',
                lastName: 'Goshov',
                age: 32
            },
        ];

        showArray(newPeople, '7. By an array of people find the most common first and last name. New array of people with duplicating names');
        var mostCommonFirstName = _.chain(newPeople)
            .groupBy('firstName')
            .max(function(group){
                return group.length;
            })
            .value()[0].firstName;
        console.log('Most common first name: ' + mostCommonFirstName);

        var mostCommonLastName = _.chain(newPeople)
            .groupBy('lastName')
            .max(function(group){
                return group.length;
            })
            .value()[0].lastName;
        console.log('Most common last name: ' + mostCommonLastName);
    })
}());