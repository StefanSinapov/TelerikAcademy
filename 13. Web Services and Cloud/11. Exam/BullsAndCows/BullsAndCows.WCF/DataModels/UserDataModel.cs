namespace BullsAndCows.WCF.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Models;

    public class UserDataModel
    {
        public static Expression<Func<User, UserDataModel>> FromEntityToModel
        {
            get
            {
                return user => new UserDataModel
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }
    }
}