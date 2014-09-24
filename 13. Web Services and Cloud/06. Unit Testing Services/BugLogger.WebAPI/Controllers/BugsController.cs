namespace BugLogger.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Models;

    public class BugsController : ApiController
    {
        private readonly IBugLoggerData data;

        public BugsController()
            : this(new BugLoggerData())
        {
            
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IQueryable<BugDataModel> All()
        {
            var bugs = this.data.Bugs.All().Select(BugDataModel.FromEntityToModel);

            return bugs;
        }

        [HttpGet]
        public IHttpActionResult GetFromDate([FromUri]DateTime date)
        {
            var bugs = this.data.Bugs.GetAllFromDate(date).Select(BugDataModel.FromEntityToModel);

            if (!bugs.Any())
            {
                return NotFound();
            }

            return Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult GetByStatus([FromUri] BugStatus status)
        {
            var bugs = this.data.Bugs.GetAllByStatus(status).Select(BugDataModel.FromEntityToModel);

            if (!bugs.Any())
            {
                return NotFound();
            }

            return Ok(bugs);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] CreateBugModel createBugModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(createBugModel.Description))
            {
                return BadRequest("Description cannot be null or empty");
            }

            if (createBugModel.LogDate == DateTime.MinValue || createBugModel.LogDate == DateTime.MaxValue)
            {
                return BadRequest("Invalid LogDate: " + createBugModel.LogDate);
            }

            var bug = new Bug
            {
                Description = createBugModel.Description,
                LogDate = createBugModel.LogDate,
                Status = createBugModel.Status
            };

            try
            {
                this.data.Bugs.Add(bug);
                this.data.SaveChanges();

                var model = new BugDataModel(bug);
                return Created("New bug created", model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult ChangeStatus(int id, BugStatus status)
        {
            var bug = this.data.Bugs.Find(id);

            if (bug == null)
            {
                return NotFound();
            }

            try
            {
                bug.Status = status;
                this.data.SaveChanges();
                var model = new BugDataModel(bug);
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}