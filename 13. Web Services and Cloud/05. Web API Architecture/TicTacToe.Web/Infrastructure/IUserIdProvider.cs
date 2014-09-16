using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicTacToe.Web.Infrastructure
{
    public interface IUserIdProvider
    {
        string GetUserId();
    }
}