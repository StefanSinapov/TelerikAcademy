namespace BullsAndCows.Web.Controllers
{
    using System.Web.Http;
    using BullsAndCows.Models.Enums;
    using Data;
    using Data.Contracts;
    using DataModels;
    using GameLogic;

    public class GuessesController : BaseApiController
    {
        private GameEngine engine;

        public GuessesController()
            : this(new BullsAndCowsData(BullsAndCowsDbContext.Create()), new GameEngine())
        {

        }

        public GuessesController(IBullsAndCowsData data, GameEngine engine)
            : base(data)
        {
            this.engine = engine;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult Guess(int id, [FromBody] CreateGuessDataModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = this.Data.Games.Find(id);
            var userId = this.GetUserId();
            bool isRedPlayer = false;

            if (game == null)
            {
                return NotFound();
            }

            if (game.GameState == GameState.Finished || game.GameState == GameState.WaitingForOpponent)
            {
                return BadRequest("Game is :" + game.GameState);
            }

            if (!(game.RedPlayerId == userId || game.BluePlayerId == userId))
            {
                return this.Unauthorized();
            }

            if (game.RedPlayerId == userId && game.GameState == GameState.BlueInTurn)
            {
                return BadRequest("Its not your turn");
            }

            if (game.BluePlayerId == userId && game.GameState == GameState.RedInTurn)
            {
                return BadRequest("Its not your turn");
            }


            var guess = this.engine.MakeGuess(game, userId, model.Number);


            if (userId == game.RedPlayerId)
            {
                isRedPlayer = true;
                game.RedPlayerGuesses.Add(guess);
            }
            else if (userId == game.BluePlayerId)
            {
                game.BluePlayerGuesses.Add(guess);
            }

            this.Data.SaveChanges();


            if (guess.BullsCount == 4)
            {
                //Red wins
                if (isRedPlayer)
                {
                    var winningNotifiaction = 
                            this.engine.GetWinningNotification(game.Id, game.BluePlayer.UserName, game.Name);
                    game.RedPlayer.Notifications.Add(winningNotifiaction);

                    var lossingNotifiaction = 
                            this.engine.GetLossingNotification(game.Id, game.RedPlayer.UserName, game.Name);
                    game.BluePlayer.Notifications.Add(lossingNotifiaction);

                    game.RedPlayer.Wins++;
                    game.BluePlayer.Losses++;
                }
                else // Blue wins
                {
                    var winningNotifiaction =
                            this.engine.GetWinningNotification(game.Id, game.RedPlayer.UserName, game.Name);
                    game.BluePlayer.Notifications.Add(winningNotifiaction);

                    var lossingNotifiaction =
                            this.engine.GetLossingNotification(game.Id, game.BluePlayer.UserName, game.Name);
                    game.RedPlayer.Notifications.Add(lossingNotifiaction);

                    game.BluePlayer.Wins++;
                    game.RedPlayer.Losses++;
                }

                game.GameState = GameState.Finished;

            }
            else
            {
                var nextPlayerNotification = this.engine.GetNextPlayerNotification(game.Id, game.Name);

                if (isRedPlayer)
                {
                    game.GameState = GameState.BlueInTurn;
                    game.BluePlayer.Notifications.Add(nextPlayerNotification);
                }
                else
                {
                    game.GameState = GameState.RedInTurn;
                    game.RedPlayer.Notifications.Add(nextPlayerNotification);
                }
            }

            this.Data.SaveChanges();


            var outputModel = new GuessDataModel
            {
                Id = guess.Id,
                DateMade = guess.DateMade,
                Number = guess.Number,
                UserId = guess.UserId,
                Username = guess.User.UserName,
                BullsCount = guess.BullsCount,
                CowsCount = guess.CowsCount,
                GameId = guess.GameId
            };

            return Ok(outputModel);
        }
    }
}