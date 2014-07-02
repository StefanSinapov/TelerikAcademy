///<reference path='People.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='Interfaces.ts'/>
///<reference path='University.ts'/>
///<reference path='Enums.ts'/>
//I'm sorry for the poor demo but I have no time for more. You can check all other methods and stuff
var pesho = new People.Student('Pesho', 'Peshev', 0 /* Male */, '8014949');
console.log(pesho.toString());
console.log(pesho);

//Some Course
var jsOOP = new University.Course('JavaScript OOP', 6 /* JavaScriptOOP */);
jsOOP.addStudent(pesho);
console.log(jsOOP);

//other stuff
var someCourses = new Utilities.List();
someCourses.add(new University.Course('JavaScript Dom & UI', 5 /* JavaScriptDOMUI */));
someCourses.add(new University.Course('C# I', 0 /* CSharpPartOne */));
someCourses.add(new University.Course('High-Quality Code', 3 /* HighQualityCode */));
pesho.courses = someCourses;
console.log(pesho.toString() + ' courses: ');
console.log(pesho.courses);

var doncho = new People.Teacher('Doncho', 'Minkov', 0 /* Male */, 5000);
doncho.addCourse(jsOOP);
console.log(doncho.toString() + ' courses:');
console.log(doncho.courses);
//# sourceMappingURL=Test.js.map
