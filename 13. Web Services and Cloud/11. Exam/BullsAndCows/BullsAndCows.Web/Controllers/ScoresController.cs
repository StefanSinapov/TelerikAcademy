namespace BullsAndCows.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;

    public class ScoresController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        public ScoresController()
            : this(new BullsAndCowsData(new BullsAndCowsDbContext()))
        {
        }

        public ScoresController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var users = this.Data.Users.All()
                .Select(ScoreDataModel.FromEntityToModel)
                .OrderByDescending(r => r.Rank)
                .ThenBy(r => r.Username)
                .Take(DefaultPageSize);

            return Ok(users);
        }
    }
}