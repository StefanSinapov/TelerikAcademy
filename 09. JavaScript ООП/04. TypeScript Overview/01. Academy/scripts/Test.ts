///<reference path='People.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='Interfaces.ts'/>
///<reference path='University.ts'/>
///<reference path='Enums.ts'/>


//I'm sorry for the poor demo but I have no time for more. You can check all other methods and stuff


var pesho = new People.Student('Pesho', 'Peshev', Enums.Gender.Male, '8014949');
console.log(pesho.toString());
console.log(pesho);

//Some Course
var jsOOP = new University.Course('JavaScript OOP', Enums.Subject.JavaScriptOOP);
jsOOP.addStudent(pesho);
console.log(jsOOP);

//other stuff
var someCourses = new Utilities.List<University.Course>();
someCourses.add(new University.Course('JavaScript Dom & UI', Enums.Subject.JavaScriptDOMUI));
someCourses.add(new University.Course('C# I', Enums.Subject.CSharpPartOne));
someCourses.add(new University.Course('High-Quality Code', Enums.Subject.HighQualityCode));
pesho.courses = someCourses;
console.log(pesho.toString() + ' courses: ');
console.log(pesho.courses);


var doncho = new People.Teacher('Doncho', 'Minkov', Enums.Gender.Male, 5000);
doncho.addCourse(jsOOP);
console.log(doncho.toString() + ' courses:');
console.log(doncho.courses);