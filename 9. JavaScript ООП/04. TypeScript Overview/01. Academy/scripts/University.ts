///<reference path='Interfaces.ts'/>
///<reference path='People.ts'/>
///<reference path='Utilities.ts'/>
///<reference path='Enums.ts'/>

module University {

    export class Course implements Interfaces.ICourse{
        private _title: string;
        private _subject: Enums.Subject;
        private _students: Utilities.List<People.Student>;
        private _teachers: Utilities.List<People.Teacher>;

        constructor(title: string, subject: Enums.Subject){
            this.title = title;
            this.subject = subject;
            this.students = new Utilities.List<People.Student>();
            this.teachers = new Utilities.List<People.Teacher>();
        }

        get title(){
            return this._title;
        }
        set title(value: string){
            if(value == undefined || value.length <= 0)
            {
                throw Error('Title cannot be null or empty string');
            }
            this._title = value;
        }

        get subject(){
            return this._subject;
        }
        set subject(value: Enums.Subject){
            this._subject = value;
        }

        get students(){
            return this._students;
        }
        set students(value: Utilities.List<People.Student>){
            this._students = value;
        }

        get teachers(){
            return this._teachers;
        }
        set teachers(value: Utilities.List<People.Teacher>){
            this._teachers = value;
        }

        addStudent(value: People.Student): void{
            this.students.add(value);
        }
        removeStudent(value: People.Student): void{
            this.students.remove(value);
        }
        addTeacher(value: People.Teacher): void{
            this.teachers.add(value);
        }
        removeTeacher(value: People.Teacher): void{
            this.teachers.remove(value);
        }
    }
}