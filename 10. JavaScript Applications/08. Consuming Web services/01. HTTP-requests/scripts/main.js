(function () {
    'use strict';
    require.config({
        paths: {
            "jquery": "libs/jquery.min",
            'underscore': 'libs/underscore',
            'http-request': 'http-request'
        }
    });

    require(['jquery', 'underscore', 'http-request'], function ($, _, httpRequest) {

        var API_KEY = 'WLw6A3cGrZoffd8M',
            studentsUrl = 'http://api.everlive.com/v1/' + API_KEY + '/Students',
            $getButton = $('#get-students'),
            $addButton = $('#post-students'),
            $studentsContainer = $('#students-container'),
            studentData = {};


        // Get Students from DataBase
        $getButton.on('click', function () {
            httpRequest.getJSON(studentsUrl)
                .then(successfullyGetStudents, errorGetStudents)
        });

        function successfullyGetStudents(result) {
            var $students = $('<table>');
            $students.append($('<tr/>')
                .append($('<th/>').text("First Name"),
                $('<th/>').text("Last Name"),
                $('<th/>').text("Age")));
            $.each(result.Result, function (count, item) {
                $students.append($('<tr/>')
                    .append($('<td/>').text(item.FirstName),
                    $('<td/>').text(item.LastName),
                    $('<td/>').text(item.Age)));
            });
            $studentsContainer.html($students);
        }

        function errorGetStudents(reason) {
            console.log(reason);
            alert(JSON.stringify(reason));
        }

        // Add student
        $addButton.on('click', function () {
            studentData = {
                FirstName: $('#first-name').val(),
                LastName: $('#last-name').val(),
                Age: $('#age').val()
            };
            httpRequest.postJSON(studentsUrl, studentData)
                .then(studentSuccessAdd, errorAddStudent);
        });

        function studentSuccessAdd(result) {
            alert('Student added at ' + result.Result.CreatedAt);
            $('#first-name').val('');
            $('#last-name').val('');
            $('#age').val('')
        }

        function errorAddStudent(reason) {
            console.log(reason);
            alert(reason);
        }
    })

}());

