namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BullsAndCows.Models;

    public class GameInfoDataModel
    {
        public static Expression<Func<Game, GameInfoDataModel>> FromEntityToModelBlue
        {
            get
            {
                return game => new GameInfoDataModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    DateCreated = game.DateCreated,
                    Red = game.RedPlayer.UserName,
                    Blue = game.BluePlayer.UserName,
                    YourNumber = game.BluePlayerDigits,
                    YourGuesses =
                        game.BluePlayerGuesses.AsQueryable().Select(GuessDataModel.FromEntityToModel).ToArray(),
                    OpponentGuesses =
                        game.RedPlayerGuesses.AsQueryable().Select(GuessDataModel.FromEntityToModel).ToArray(),
                    YourColor = "blue",
                    GameState = game.GameState.ToString()
                };
            }
        }

        public static Expression<Func<Game, GameInfoDataModel>> FromEntityToModelRed
        {
            get
            {
                return game => new GameInfoDataModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    DateCreated = game.DateCreated,
                    Red = game.RedPlayer.UserName,
                    Blue = game.BluePlayer.UserName,
                    YourNumber = game.RedPlayerDigits,
                    YourGuesses =
                        game.RedPlayerGuesses.AsQueryable().Select(GuessDataModel.FromEntityToModel).ToArray(),
                    OpponentGuesses =
                        game.BluePlayerGuesses.AsQueryable().Select(GuessDataModel.FromEntityToModel).ToArray(),
                    YourColor = "red",
                    GameState = game.GameState.ToString()
                };
            }
        }

        public GameInfoDataModel()
        {
            this.YourGuesses = new HashSet<GuessDataModel>();
            this.OpponentGuesses = new HashSet<GuessDataModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public string Red { get; set; }

        public string Blue { get; set; }

        public string YourNumber { get; set; }

        public ICollection<GuessDataModel> YourGuesses { get; set; }

        public ICollection<GuessDataModel> OpponentGuesses { get; set; }

        public string YourColor { get; set; }

        public string GameState { get; set; }
    }
}