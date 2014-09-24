namespace BullsAndCows.GameLogic
{
    using System;
    using Models;
    using Models.Enums;

    public class GameEngine
    {
        private static Random rnd = new Random();

        public void SetFirstPlayer(Game game)
        {
            game.GameState = rnd.Next() <= 0.5 ? GameState.RedInTurn : GameState.BlueInTurn;
        }

        public Guess MakeGuess(Game game, string playerId, string guessNumber)
        {
            string number = game.RedPlayerDigits;
            User user = game.RedPlayer;

            if (playerId == game.RedPlayerId)
            {
                number = game.BluePlayerDigits;

                user = game.RedPlayer;
            }
            else if (playerId == game.BluePlayerId)
            {
                number = game.RedPlayerDigits;

                user = game.BluePlayer;
            }


            var guess = new Guess
            {
                GameId = game.Id,
                UserId = playerId,
                Number = guessNumber,
                DateMade = DateTime.Now,
                CowsCount = this.FindDigits(number, guessNumber, false),
                BullsCount = this.FindDigits(number, guessNumber, true)
            };

            //check if(win)

            //next player

            //notifiaction

            return guess;
        }

        private int FindDigits(string number, string guess, bool isBull)
        {
            var guessedDigits = 0;
            var chosenNumberAsArray = guess;
            var secretNumberAsArray = number;

            for (var i = 0; i < 4; i++)
            {
                var digit = secretNumberAsArray[i];
                var indexOfDigit = chosenNumberAsArray.IndexOf(digit);
                var isDigitGuessed = isBull ? indexOfDigit == i : indexOfDigit != i;

                if (indexOfDigit != -1 && isDigitGuessed)
                {
                    guessedDigits++;
                }
            }
            return guessedDigits;
        }

        public Notification GetWinningNotification(int gameId, string username, string gameName)
        {
            var notifictaion = new Notification
            {
                Message = string.Format("You beat {0} in game \"{1}\"", username, gameName),
                Type = NotificationType.GameWon,
                DateCreated = DateTime.Now,
                GameId = gameId
            };

            return notifictaion;
        }

        public Notification GetLossingNotification(int gameId, string username, string gameName)
        {
            var notifictaion = new Notification
            {
                Message = string.Format("{0} beat you in game \"{1}\"", username, gameName),
                Type = NotificationType.GameLost,
                DateCreated = DateTime.Now,
                GameId = gameId
            };

            return notifictaion;
        }

        public Notification GetNextPlayerNotification(int gameId, string gameName)
        {
            var notifictaion = new Notification
            {
                Message = string.Format("It is your turn in game \"{0}!\"", gameName),
                Type = NotificationType.YourTurn,
                DateCreated = DateTime.Now,
                GameId = gameId
            };

            return notifictaion;
        }

        public Notification GetJoinGameNotification(int gameId, string opponentName, string gameName)
        {

            var notifictaion = new Notification
            {
                Message = string.Format("{0} joined your game \"{1}\"", opponentName, gameName),
                Type = NotificationType.GameJoined,
                DateCreated = DateTime.Now,
                GameId = gameId
            };

            return notifictaion;
        }
    }
}