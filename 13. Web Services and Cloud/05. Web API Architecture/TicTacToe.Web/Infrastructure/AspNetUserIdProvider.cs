using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Threading;

namespace TicTacToe.Web.Infrastructure
{
    public class AspNetUserIdProvider : IUserIdProvider
    {
        public string GetUserId()
        {
            return Thread.CurrentPrincipal.Identity.GetUserId();
        }
    }
}