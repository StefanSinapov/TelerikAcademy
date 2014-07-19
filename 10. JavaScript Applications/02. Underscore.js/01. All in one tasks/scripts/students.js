define(['chance'], function (Chance) {
    'use strict';
    var Students = [],
        chance = new Chance(),
        student;

    function getRandomMarks(count) {
        var marks = [];
        for (var i = 0; i < count; i++) {
            marks.push(chance.integer({min: 2, max: 6}));
        }
        return marks;
    }

    for (var i = 0; i < 20; i++) {
        student = {
            firstName: chance.first(),
            lastName: chance.last(),
            age: chance.age({type: 'adult'}),
            marks: getRandomMarks(5)
        };
        Students.push(student);
    }
    return Students;
});