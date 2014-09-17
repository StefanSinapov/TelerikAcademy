namespace StudentSystem.WebAPI.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using StudentSystem.Models;

    public class StudentsController : BaseApiController
    {
        public StudentsController()
            : this(new StudentSystemData(new StudentSystemContext()))
        {

        }

        public StudentsController(IStudentSystemData data)
            : base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.Data.Students.All().Select(stud => new StudentDataModel(stud)));
        }

        [HttpPost]
        public IHttpActionResult Add(StudentDataModel student)
        {
            if (student == null)
            {
                return BadRequest();
            }

            var newStudent = new Student
            {
                Name = student.Name
            };

            this.Data.Students.Add(newStudent);
            this.Data.SaveChanges();

            return Ok(newStudent.StudentId);
        }

        [HttpPut]
        public IHttpActionResult Edit(int id, StudentDataModel student)
        {
            if (student == null)
            {
                return BadRequest("Student must be valid");
            }

            var studentMap = this.Data.Students.GetById(id);
            studentMap.Name = student.Name;
            this.Data.SaveChanges();

            return Ok(studentMap);
        }
    }
}