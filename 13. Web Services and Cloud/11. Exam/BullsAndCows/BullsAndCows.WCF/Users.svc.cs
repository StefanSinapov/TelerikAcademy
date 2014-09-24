namespace BullsAndCows.WCF
{
    using System;
    using System.Linq;
    using Data;
    using Data.Contracts;
    using DataModels;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UsersService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UsersService.svc or UsersService.svc.cs at the Solution Explorer and start debugging.
    public class UsersService : IUsers
    {
        private const int DefaultPageSize = 10;
        private IBullsAndCowsUsersData data = new BullsAndCowsUsersData(new BullsAndCowsDbContext());

        public IQueryable<UserDataModel> Get(int page)
        {
            var users = this.data.Users.All()
                .OrderBy(u => u.UserName)
                .Skip(page*DefaultPageSize)
                .Take(DefaultPageSize)
                .Select(UserDataModel.FromEntityToModel);

            return users;
        }

        public UserInfoDataModel GetById(string id)
        {
            var user = this.data.Users.Find(id);

            var model = new UserInfoDataModel
            {
                Id = user.Id,
                Losses = user.Losses,
                Rank = user.Rank,
                Username = user.UserName,
                Wins = user.Wins
            };

            return model;
        }
    }
}
