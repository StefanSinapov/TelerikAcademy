namespace BullsAndCows.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using BullsAndCows.Models;

    public class ScoreDataModel
    {
        public static Expression<Func<User, ScoreDataModel>> FromEntityToModel
        {
            get
            {
                return u => new ScoreDataModel
                {
                    Username = u.UserName,
                    Rank = (u.Wins * 100) + (15 * u.Losses)
                };
            }
        }

        public string Username { get; set; }

        public int Rank { get; set; }
    }
}