namespace ForumSystem.Services.DataModels
{
    using System;
    using System.Linq.Expressions;
    using ForumSystem.Models;

    public class TagDataModel
    {
        public static Expression<Func<Tag, TagDataModel>> FromEntityToModel
        {
            get
            {
                return m => new TagDataModel
                {
                    Id = m.Id,
                    Name = m.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}