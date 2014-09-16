namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            return GameResult.NotFinished;
        }
    }
}
