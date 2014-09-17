namespace StudentSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using DataModels;
    using Models;

    public class HomeworksController : BaseApiController
    {
        public HomeworksController()
            :base(new StudentSystemData(new StudentSystemContext()))
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var homeworks = this.Data.Homeworks.All().Select(HomeworkDataModel.FromHomework);

            return Ok(homeworks);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var homework = this.Data.Homeworks.GetById(id);
            if (homework == null)
            {
                return NotFound();
            }

            var homeworkModel = new HomeworkDataModel(homework);

            return Ok(homeworkModel);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkDataModel homeworkModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(string.IsNullOrEmpty(homeworkModel.Content))
            {
                return BadRequest("Homework Content cannot be empty");
            }

            var homework = new Homework
            {
                Content = homeworkModel.Content,
                CourseId = homeworkModel.CourseId,
                StudentId = homeworkModel.StudentId,
                TimeSent = homeworkModel.TimeSent
            };

            this.Data.Homeworks.Add(homework);
            this.Data.SaveChanges();

            homeworkModel.Id = homework.HomeworkId;

            return Ok(homeworkModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, HomeworkDataModel homeworkModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var homework = this.Data.Homeworks.GetById(id);

            if (homework == null)
            {
                return NotFound();
            }

            homework.Content = homeworkModel.Content;
            homework.CourseId = homework.CourseId;

            this.Data.SaveChanges();

            return Ok(homeworkModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var homework = this.Data.Homeworks.GetById(id);

            if (homework == null)
            {
                return NotFound();
            }

            this.Data.Homeworks.Delete(homework);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}