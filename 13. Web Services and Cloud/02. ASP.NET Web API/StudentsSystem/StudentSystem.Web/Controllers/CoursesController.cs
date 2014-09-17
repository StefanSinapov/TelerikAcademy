namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using DataModels;
    using Models;

    public class CoursesController : BaseApiController
    {

        public CoursesController()
            : base(new StudentSystemData(new StudentSystemContext()))
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var courses = this.Data.Courses.All().Select(CourseDataModel.FromCourse);


            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var course = this.Data.Courses.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            var courseDataModel = new CourseDataModel(course);

            return Ok(courseDataModel);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseDataModel courseModel)
        {
            if (string.IsNullOrEmpty(courseModel.Description))
            {
                return BadRequest("Course description cannot be empty");
            }

            var course = new Course
            {
                Description = courseModel.Description
            };

            this.Data.Courses.Add(course);
            this.Data.SaveChanges();

            courseModel.Id = course.CourseId;
            return Ok(courseModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CourseDataModel courseModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var course = this.Data.Courses.GetById(id);
            if (course == null)
            {
                return BadRequest("There is no such course in the system");
            }

            courseModel.Description = courseModel.Description;
            this.Data.SaveChanges();

            return Ok(courseModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var course = this.Data.Courses.GetById(id);
            if (course == null)
            {
                return BadRequest("There is no such course in the system");
            }

            this.Data.Courses.Delete(course);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}