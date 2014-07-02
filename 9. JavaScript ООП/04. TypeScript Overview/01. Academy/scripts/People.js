///<reference path='Interfaces.ts'/>
///<reference path='Enums.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='University.ts'/>
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var People;
(function (People) {
    var Person = (function () {
        function Person(firstName, lastName, gender) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
        }
        Object.defineProperty(Person.prototype, "firstName", {
            get: function () {
                return this._firstName;
            },
            set: function (value) {
                if (value.length < 3) {
                    throw new Error('First Name must be at least 3 characters');
                } else if (value === undefined) {
                    throw new Error('First name must be typed');
                }
                this._firstName = value;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Person.prototype, "lastName", {
            get: function () {
                return this._lastName;
            },
            set: function (value) {
                if (value.length < 3) {
                    throw new Error('Last name must be at least 3 characters');
                } else if (value === undefined) {
                    throw new Error('Last name must be typed');
                }
                this._lastName = value;
            },
            enumerable: true,
            configurable: true
        });


        Object.defineProperty(Person.prototype, "gender", {
            get: function () {
                return this._gender;
            },
            set: function (value) {
                this._gender = value;
            },
            enumerable: true,
            configurable: true
        });


        Person.prototype.toString = function () {
            return this.firstName + " " + this.lastName;
        };
        return Person;
    })();
    People.Person = Person;

    var Student = (function (_super) {
        __extends(Student, _super);
        function Student(firstName, lastName, gender, studentNumber) {
            _super.call(this, firstName, lastName, gender);
            this.studentNumber = studentNumber;
            this.courses = new Utilities.List();
        }
        Object.defineProperty(Student.prototype, "studentNumber", {
            get: function () {
                return this._studentNumber;
            },
            set: function (value) {
                if (value.length != 7) {
                    throw new Error('Students ID number must be exactly 7 symbols');
                }
                this._studentNumber = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Student.prototype, "courses", {
            get: function () {
                return this._courses;
            },
            set: function (value) {
                this._courses = value;
            },
            enumerable: true,
            configurable: true
        });

        Student.prototype.addCourse = function (value) {
            this.courses.add(value);
        };
        return Student;
    })(Person);
    People.Student = Student;

    var Employee = (function (_super) {
        __extends(Employee, _super);
        function Employee(firstName, lastName, gender, salary, position) {
            _super.call(this, firstName, lastName, gender);
            this.salary = salary;
            this.position = position;
        }
        Object.defineProperty(Employee.prototype, "salary", {
            get: function () {
                return this._salary;
            },
            set: function (value) {
                if (value < 0) {
                    throw Error('Salary cannot be negative value');
                }
                this._salary = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Employee.prototype, "assignment", {
            get: function () {
                return this._assignment;
            },
            set: function (value) {
                if (value || value.length <= 0) {
                    throw Error('Assignment cannot be null or empty string');
                }
                this._assignment = value;
            },
            enumerable: true,
            configurable: true
        });

        Object.defineProperty(Employee.prototype, "position", {
            get: function () {
                return this._position;
            },
            set: function (value) {
                this._position = value;
            },
            enumerable: true,
            configurable: true
        });

        Employee.prototype.addAssignment = function (value) {
            this.assignment = value;
        };
        Employee.prototype.completeAssignment = function () {
            this.assignment = '';
        };
        return Employee;
    })(Person);
    People.Employee = Employee;

    var Teacher = (function (_super) {
        __extends(Teacher, _super);
        function Teacher(firstName, lastName, gender, salary) {
            _super.call(this, firstName, lastName, gender, salary, 0 /* Teacher */);
            this.courses = new Utilities.List();
        }
        Object.defineProperty(Teacher.prototype, "courses", {
            get: function () {
                return this._courses;
            },
            set: function (value) {
                this._courses = value;
            },
            enumerable: true,
            configurable: true
        });

        Teacher.prototype.addCourse = function (value) {
            this.courses.add(value);
        };
        Teacher.prototype.removeCourse = function (value) {
            this.courses.remove(value);
        };
        return Teacher;
    })(Employee);
    People.Teacher = Teacher;
})(People || (People = {}));
//# sourceMappingURL=People.js.map
