namespace StudentSystem.Web.Controllers
{
    using System.Web.Http;
    using Data;
    using DataModels;
    using System.Linq;
    using Models;

    public class MaterialsController : BaseApiController
    {
        public MaterialsController()
            : base(new StudentSystemData(new StudentSystemContext()))
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var materials = this.Data.Materials.All().Select(MaterialDataModel.FromMaterial);

            return Ok(materials);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var material = this.Data.Materials.GetById(id);

            if (material == null)
            {
                return NotFound();
            }

            var materialModel = new MaterialDataModel(material);

            return Ok(materialModel);
        }

        [HttpPost]
        public IHttpActionResult Create(MaterialDataModel materialModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(materialModel.DownloadUrl))
            {
                return BadRequest("Material URL cannot be empty");
            }

            var material = new Material
            {
                DownloadUrl = materialModel.DownloadUrl,
                Type = materialModel.Type,
                HomeworkId = materialModel.HomeworkId
            };

            this.Data.Materials.Add(material);
            this.Data.SaveChanges();

            materialModel.Id = material.MaterialId;

            return Ok(materialModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, MaterialDataModel materialModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var material = this.Data.Materials.GetById(id);

            if (material == null)
            {
                return NotFound();
            }

            material.DownloadUrl = materialModel.DownloadUrl;
            material.Type = material.Type;
            material.HomeworkId = materialModel.HomeworkId;

            this.Data.SaveChanges();

            return Ok(materialModel);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var material = this.Data.Materials.GetById(id);

            if (material == null)
            {
                return NotFound();
            }

            this.Data.Materials.Delete(material);
            this.Data.SaveChanges();

            return Ok();
        }
    }
}