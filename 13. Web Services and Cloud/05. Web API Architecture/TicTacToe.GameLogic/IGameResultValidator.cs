using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameLogic
{
    public interface IGameResultValidator
    {
        GameResult GetResult(string board);
    }
}
