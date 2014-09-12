define(function () {
    'use strict';
    var Course;
    Course = (function () {
        function Course(title, scoreFormula) {
            this.title = title;
            this._scoreFormula = scoreFormula;
            this._students = [];
        }

        Course.prototype.addStudent = function(student){
            this._students.push(student);
        };

        Course.prototype.calculateResults = function () {
            var self = this;
            this._students.forEach(function (student) {
                student.totalScore = self._scoreFormula(student);
            });
        };

        Course.prototype.getTopStudentsByExam = function(count){
            return sortStudentsBy(this._students, count, 'exam');
        };

        Course.prototype.getTopStudentsByTotalScore = function(count){
            return sortStudentsBy(this._students, count, 'totalScore');
        };

        function sortStudentsBy(students, count, sortBy){
            students.sort(function(first, second){
                return second[sortBy] - first[sortBy];
            });

            return students.splice(0, count);
        }

        return Course;
    }());

    return Course;
});