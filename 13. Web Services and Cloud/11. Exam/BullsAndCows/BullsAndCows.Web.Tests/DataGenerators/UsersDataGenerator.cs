namespace BullsAndCows.Web.Tests.DataGenerators
{
    using System;
    using System.Collections.Generic;
    using BullsAndCows.Models;

    internal class UsersDataGenerator
    {
        private static readonly Random Rnd = new Random();

        public ICollection<User> GenereateUser(int count)
        {
            var users = new HashSet<User>();

            for (int i = 0; i < count; i++)
            {
                var user = new User
                {
                    UserName = "User #" + 1,
                    Wins = Rnd.Next(0, 10),
                    Losses = Rnd.Next(0, 10)
                };

                users.Add(user);
            }

            return users;
        }
    }
}