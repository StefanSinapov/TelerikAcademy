///<reference path='Interfaces.ts'/>
///<reference path='People.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='Enums.ts'/>
var University;
(function (University) {
    var Course = (function () {
        function Course(title, subject) {
            this.title = title;
            this.subject = subject;
            this.students = new Utilities.List();
            this.teachers = new Utilities.List();
        }
        Object.defineProperty(Course.prototype, "title", {
            get: function () {
                return this._title;
            },
            set: function (value) {
                if (value == undefined || value.length <= 0) {
                    throw Error('Title cannot be null or empty string');
                }
                this._title = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Course.prototype, "subject", {
            get: function () {
                return this._subject;
            },
            set: function (value) {
                this._subject = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Course.prototype, "students", {
            get: function () {
                return this._students;
            },
            set: function (value) {
                this._students = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Course.prototype, "teachers", {
            get: function () {
                return this._teachers;
            },
            set: function (value) {
                this._teachers = value;
            },
            enumerable: true,
            configurable: true
        });

        Course.prototype.addStudent = function (value) {
            this.students.add(value);
        };
        Course.prototype.removeStudent = function (value) {
            this.students.remove(value);
        };
        Course.prototype.addTeacher = function (value) {
            this.teachers.add(value);
        };
        Course.prototype.removeTeacher = function (value) {
            this.teachers.remove(value);
        };
        return Course;
    })();
    University.Course = Course;
})(University || (University = {}));
//# sourceMappingURL=University.js.map
