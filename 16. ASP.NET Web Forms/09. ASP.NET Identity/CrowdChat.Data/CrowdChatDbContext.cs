namespace CrowdChat.Data
{
    using System.Data.Entity;

    using CrowdChat.Common;
    using CrowdChat.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class CrowdChatDbContext : IdentityDbContext<User>
    {
        public CrowdChatDbContext()
            : base(ConnectionStrings.DefaultConnection, false)
        {
        }

        public static CrowdChatDbContext Create()
        {
            return new CrowdChatDbContext();
        }

        public IDbSet<Message> Messages { get; set; }
    }
}