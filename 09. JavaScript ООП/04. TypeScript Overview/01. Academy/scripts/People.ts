///<reference path='Interfaces.ts'/>
///<reference path='Enums.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='University.ts'/>

module People {
    export class Person implements Interfaces.IPerson {
        private _firstName:string;
        private _lastName:string;
        private _gender:Enums.Gender;

        constructor(firstName:string, lastName:string, gender:Enums.Gender) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gender = gender;
        }

        get firstName():string {
            return this._firstName;
        }

        set firstName(value:string) {
            if (value.length < 3) {
                throw new Error('First Name must be at least 3 characters');
            }
            else if (value === undefined) {
                throw  new Error('First name must be typed');
            }
            this._firstName = value;
        }

        get lastName():string {
            return this._lastName;
        }

        set lastName(value:string) {
            if (value.length < 3) {
                throw new Error('Last name must be at least 3 characters');
            }
            else if (value === undefined) {
                throw  new Error('Last name must be typed');
            }
            this._lastName = value;
        }

        get gender():Enums.Gender {
            return this._gender;
        }

        set gender(value:Enums.Gender) {
            this._gender = value;
        }

        toString():string {
            return this.firstName + " " + this.lastName;
        }
    }

    export class Student extends Person implements Interfaces.IStudent{
        _courses: Utilities.List<University.Course>;
        _studentNumber: string;

        constructor(firstName: string, lastName: string, gender: Enums.Gender, studentNumber: string)
        {
            super(firstName, lastName, gender);
            this.studentNumber = studentNumber;
            this.courses = new Utilities.List<University.Course>();
        }

        get studentNumber(){
            return this._studentNumber;
        }
        set studentNumber(value: string){
            if(value.length != 7)
            {
                throw new Error('Students ID number must be exactly 7 symbols');
            }
            this._studentNumber = value;
        }

        get courses() {
            return this._courses;
        }
        set courses(value: Utilities.List<University.Course>){
            this._courses = value;
        }

        addCourse(value: University.Course) :void{
            this.courses.add(value);
        }
    }

    export class Employee extends Person implements Interfaces.IEmployee {
        private _assignment:string;
        private _salary: number;
        private _position: Enums.Position;

        constructor(firstName: string, lastName: string, gender: Enums.Gender,
                    salary: number, position: Enums.Position){
            super(firstName, lastName, gender);
            this.salary = salary;
            this.position = position;
        }

        get salary(){
            return this._salary;
        }
        set salary(value: number){
            if(value < 0){
                throw Error('Salary cannot be negative value');
            }
            this._salary = value;
        }

        get assignment(){
            return this._assignment;
        }
        set assignment(value: string){
            if(value || value.length <= 0)
            {
                throw Error('Assignment cannot be null or empty string');
            }
            this._assignment = value;
        }

        get position(){
            return this._position;
        }
        set position(value: Enums.Position){
            this._position = value;
        }

        addAssignment(value: string): void{
            this.assignment = value;
        }
        completeAssignment(): void{
            this.assignment = '';
        }
    }

    export class Teacher extends Employee implements Interfaces.ITeacher {
        private _courses: Utilities.List<University.Course>;

        constructor(firstName: string, lastName: string, gender: Enums.Gender,
                    salary: number){
            super(firstName, lastName, gender, salary, Enums.Position.Teacher);
            this.courses = new Utilities.List<University.Course>();
        }

        get courses() {
            return this._courses;
        }
        set courses(value: Utilities.List<University.Course>) {
            this._courses = value;
        }

        addCourse(value: University.Course): void{
            this.courses.add(value);
        }
        removeCourse(value: University.Course): void{
            this.courses.remove(value);
        }
    }
}