namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using DataModels;
    using Models;

    public class StudentsController : BaseApiController
    {

        public StudentsController()
            : base(new StudentSystemData(new StudentSystemContext()))
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var students = this.Data.Students.All().Select(StudentDataModel.FromStudent);

            return Ok(students);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = this.Data.Students.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            var studentModel = new StudentDataModel(student);

            return Ok(studentModel);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentDataModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(studentModel.Name))
            {
                return BadRequest("Student Name cannot be empty");
            }

            var student = new Student
            {
                Name = studentModel.Name
            };

            this.Data.Students.Add(student);
            this.Data.SaveChanges();

            studentModel.Id = student.StudentId;

            return Ok(studentModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentDataModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = this.Data.Students.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            student.Name = studentModel.Name;

            this.Data.SaveChanges();

            return Ok(studentModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var student = this.Data.Students.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            this.Data.Homeworks.Delete(student);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}