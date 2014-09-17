namespace StudentSystem.Web.DataModels
{
    using System;
    using System.Linq.Expressions;
    using Models;

	
    public class MaterialDataModel
    {
        public static Func<Material, MaterialDataModel> FromMaterial
        {
            get
            {
                return material => new MaterialDataModel
                {
					Id = material.MaterialId,
					DownloadUrl = material.DownloadUrl,
					Type = material.Type,
					HomeworkId = material.HomeworkId
                };
            }
        }

        public MaterialDataModel()
        {
            
        }

        public MaterialDataModel(Material material)
        {
            this.Id = material.MaterialId;
            this.DownloadUrl = material.DownloadUrl;
			this.Type = material.Type;
			this.HomeworkId = material.HomeworkId;
        }

        public int Id { get; set; }

        public string DownloadUrl { get; set; }

        public MaterialType Type { get; set; }

        public int HomeworkId { get; set; }
    }
	
}