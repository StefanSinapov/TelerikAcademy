namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using BullsAndCows.Models;

    public class GameDataModel
    {
        public static Expression<Func<Game, GameDataModel>> FromEntityToModel
        {
            get
            {
                return game => new GameDataModel
                {
                    Id = game.Id,
                    GameState = game.GameState.ToString(),
                    Blue = game.BluePlayer != null ? game.BluePlayer.UserName : "No blue player yet",
                    Red = game.RedPlayer.UserName,
                    DateCreated = game.DateCreated,
                    Name = game.Name
                };
            }
        }

        public GameDataModel()
        {
            this.Blue = "No blue player yet";
            this.GameState = "WaitingForOpponent";
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Blue { get; set; }

        public string Red { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}