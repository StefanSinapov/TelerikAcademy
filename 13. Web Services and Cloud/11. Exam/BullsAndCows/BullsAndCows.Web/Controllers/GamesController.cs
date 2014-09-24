namespace BullsAndCows.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using BullsAndCows.Models;
    using BullsAndCows.Models.Enums;
    using Data;
    using Data.Contracts;
    using DataModels;
    using GameLogic;

    public class GamesController : BaseApiController
    {
        private const int DefaultPageSize = 10;

        private GameEngine engine = new GameEngine();

        public GamesController()
            : base(new BullsAndCowsData(BullsAndCowsDbContext.Create()))
        {

        }

        public GamesController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetPublic(int page = 0)
        {
            if (User.Identity.IsAuthenticated)
            {
                return this.GetAuth(page);
            }

            var games = this.Data.Games.All()
                .Where(g => g.GameState == GameState.WaitingForOpponent)
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * DefaultPageSize)
                .Take(DefaultPageSize)
                .Select(GameDataModel.FromEntityToModel);

            return Ok(games);
        }

        [HttpGet]
        [Authorize]
        private IHttpActionResult GetAuth(int page)
        {
            var userId = this.GetUserId();

            var games = this.Data.Games.All()
                .Where(g => (g.GameState == GameState.WaitingForOpponent ||
                    g.BluePlayerId == userId || g.RedPlayerId == userId))
                .OrderBy(g => g.GameState)
                .ThenBy(g => g.Name)
                .ThenBy(g => g.DateCreated)
                .ThenBy(g => g.RedPlayer.UserName)
                .Skip(page * DefaultPageSize)
                .Take(DefaultPageSize)
                .Select(GameDataModel.FromEntityToModel);

            return Ok(games);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetById(int id)
        {
            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            if (game.GameState == GameState.WaitingForOpponent)
            {
                return BadRequest("Game is waiting for opponent");
            }

            if (game.GameState == GameState.Finished)
            {
                return BadRequest("Game is already finished");
            }

            var model = new GameInfoDataModel
            {
                Id = game.Id,
                Name = game.Name,
                Blue = game.BluePlayer.UserName,
                Red = game.RedPlayer.UserName,
                GameState = game.GameState.ToString(),
                DateCreated = game.DateCreated
            };

            if (game.BluePlayerId == this.GetUserId())
            {
                model.YourNumber = game.BluePlayerDigits;
                model.YourGuesses = game.BluePlayerGuesses.AsQueryable()
                                .Select(GuessDataModel.FromEntityToModel)
                                .ToArray();
                model.OpponentGuesses = game.RedPlayerGuesses.AsQueryable()
                                .Select(GuessDataModel.FromEntityToModel)
                                .ToArray();
                model.YourColor = "blue";
            }
            else if (game.RedPlayerId == this.GetUserId())
            {
                model.YourNumber = game.RedPlayerDigits;
                model.YourGuesses = game.RedPlayerGuesses.AsQueryable()
                                .Select(GuessDataModel.FromEntityToModel)
                                .ToArray();
                model.OpponentGuesses = game.BluePlayerGuesses.AsQueryable()
                                .Select(GuessDataModel.FromEntityToModel)
                                .ToArray();
                model.YourColor = "red";
            }
            else
            {
                return this.Unauthorized();
            }

            return Ok(model);
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(CreateGameDataModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var redPlayerId = this.GetUserId();
            var userName = this.GetUsername();

            var game = new Game
            {
                Name = createModel.Name,
                DateCreated = DateTime.Now,
                GameState = GameState.WaitingForOpponent,
                RedPlayerId = redPlayerId,
                RedPlayerDigits = createModel.Number
            };

            this.Data.Games.Add(game);
            this.Data.SaveChanges();

            var returnModel = new GameDataModel
            {
                Id = game.Id,
                Name = game.Name,
                Red = userName,
                Blue = "No blue player yet",
                GameState = "WaitingForOpponent",
                DateCreated = game.DateCreated
            };

            return Ok(returnModel);
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult Join(int id, [FromBody]JoinGameDataModel joinModel)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var userId = this.GetUserId();
            var userName = this.GetUsername();
            var game = this.Data.Games.Find(id);

            if (game == null)
            {
                return NotFound();
            }

            if (game.GameState != GameState.WaitingForOpponent)
            {
                return BadRequest();
            }

            if (userId == game.RedPlayerId)
            {
                return BadRequest(". A game, created by a user, cannot be joined by the same user");
            }

            game.BluePlayerId = userId;
            game.BluePlayerDigits = joinModel.Number;

            var joinNotification = this.engine.GetJoinGameNotification(game.Id, userName, game.Name);
            game.RedPlayer.Notifications.Add(joinNotification);

            this.engine.SetFirstPlayer(game);

            this.Data.SaveChanges();

            var returnModel = new JoinGameResultDataModel(string.Format("You joined game \"{0}\"", game.Name));

            return Ok(returnModel);
        }
    }

   
}