using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TicTacToe.Data;

namespace TicTacToe.Web.Controllers
{
    [Authorize]
    public abstract class BaseApiController : ApiController
    {
        protected ITicTacToeData data;

        protected BaseApiController(ITicTacToeData data)
        {
            this.data = data;
        }
    }
}