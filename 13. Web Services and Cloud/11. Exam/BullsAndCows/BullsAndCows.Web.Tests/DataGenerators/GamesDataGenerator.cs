namespace BullsAndCows.Web.Tests.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Models;
    using BullsAndCows.Models.Enums;

    public class GamesDataGenerator
    {
        private static readonly Random Rnd = new Random();

        public ICollection<Game> GenereateGames(int count)
        {
            var games = new HashSet<Game>();

            for (int i = 0; i < count; i++)
            {
                var game = new Game
                {
                    Name = "Game #" + 1,
                    RedPlayer = new User { UserName = "User #" + i },
                    GameState = GameState.WaitingForOpponent,
                    RedPlayerDigits = "1234",
                    DateCreated = DateTime.Now
                };

                games.Add(game);
            }

            return games;
        }

    }
}