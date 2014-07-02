///<reference path='Utilities.ts'/>
///<reference path='University.ts'/>
///<reference path='Enums.ts'/>

module Interfaces {
    export interface IPerson {
        firstName: string;
        lastName: string;
        gender: Enums.Gender;
        toString(): string;
    }

    export interface IStudent extends IPerson{
        courses: Utilities.List<University.Course>;
        studentNumber: string;
        addCourse(value: University.Course): void;
    }

    export interface IEmployee extends IPerson{
        salary: number;
        assignment: string;
        position: Enums.Position;
        addAssignment(value): void;
        completeAssignment(): void;
    }

    export interface ITeacher extends IEmployee{
        courses: Utilities.List<University.Course>;
        addCourse(value: University.Course): void;
        removeCourse(value: University.Course): void;
    }

    export interface ICourse {
        subject: Enums.Subject;
        students: Utilities.List<People.Student>;
        teachers: Utilities.List<People.Teacher>;
        addStudent(value: People.Student): void;
        removeStudent(value: People.Student): void;
        addTeacher(value: People.Teacher): void;
        removeTeacher(value: People.Teacher): void;
    }

    export interface IList {
        add(item): void;
        remove(item): void;
        count: number;
    }
}