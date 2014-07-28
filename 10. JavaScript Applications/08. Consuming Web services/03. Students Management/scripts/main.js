(function () {
    'use strict';
    require.config({
        paths: {
            "jquery": "libs/jquery.min",
            'underscore': 'libs/underscore',
            'mustache': 'libs/mustache',
            'http-request': 'http-request'
        }
    });

    require(['jquery', 'mustache', 'http-request'], function ($, Mustache, httpRequest) {

        var API_KEY = 'WLw6A3cGrZoffd8M',
            studentsUrl = 'http://api.everlive.com/v1/' + API_KEY + '/Students',
            $getButton = $('#get-students'),
            $addButton = $('#post-students'),
            $studentsContainer = $('#students-container'),
            studentData = {};


        // Get Students from DataBase
        $getButton.on('click', function () {
            httpRequest.getJSON(studentsUrl)
                .then(renderStudents, errorGetStudents)
        });
        function renderStudents(result) {
            var template = $('#students-template').html();
            var students = {
                students: result.Result
            };
            var studentsResult = Mustache.render(template, students);
            $studentsContainer.html(studentsResult);

        }

        function errorGetStudents(reason) {
            console.log(reason);
            alert(JSON.stringify(reason));
        }


        // Add student
        $addButton.on('click', function () {
            var $firstName = $('#first-name'),
                $lastName = $('#last-name'),
                $age = $('#age');

            if (!$firstName.val()) {
                $firstName.css('box-shadow', 'red 0 0 4pt 1pt');
                return null;
            }
            else {
                $firstName.css('box-shadow', '');
            }

            if (!$lastName.val()) {
                $lastName.css('box-shadow', 'red 0 0 4pt 1pt');
                return null;
            }
            else {
                $lastName.css('box-shadow', '');
            }

            if (!$age.val()) {
                $age.css('box-shadow', 'red 0 0 4pt 1pt');
                return null;
            }
            else {
                $age.css('box-shadow', '');
            }

            studentData = {
                FirstName: $firstName.val(),
                LastName: $lastName.val(),
                Age: $age.val()
            };
            httpRequest.postJSON(studentsUrl, studentData)
                .then(studentSuccessAdd, errorAddStudent);
        });
        function studentSuccessAdd(result) {
            alert('Student added at ' + result.Result.CreatedAt);
            $('#first-name').val('');
            $('#last-name').val('');
            $('#age').val('');
            $getButton.click();
        }

        function errorAddStudent(reason) {
            console.log(reason);
            alert(reason);
        }

        //Delete student
        function deleteStudent(ev) {
            var studentID = $(ev.target).attr('target-id'),
                url = studentsUrl + '/' + studentID;

            httpRequest.deletePublic(url)
                .then(function () {
                    alert("Removed successfully");
                    $getButton.click();
                },function (reason) {
                    console.log(reason);
                });
        }

        $studentsContainer.on('click', 'button', deleteStudent);
    })
}());

