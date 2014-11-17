namespace LaptopSystem.Web.Areas.Admin.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using LaptopSystem.Data;
    using LaptopSystem.Data.Models;

    public class ManufacturersController : Controller
    {
        private readonly LaptopSystemDbContext dataContext = new LaptopSystemDbContext();

        // GET: Admin/Manufacturers
        public ActionResult Index()
        {
            return this.View(this.dataContext.Manufacturers.ToList());
        }

        // GET: Admin/Manufacturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = this.dataContext.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return this.HttpNotFound();
            }

            return this.View(manufacturer);
        }

        // GET: Admin/Manufacturers/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Admin/Manufacturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                this.dataContext.Manufacturers.Add(manufacturer);
                this.dataContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(manufacturer);
        }

        // GET: Admin/Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = this.dataContext.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return this.HttpNotFound();
            }

            return this.View(manufacturer);
        }

        // POST: Admin/Manufacturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                this.dataContext.Entry(manufacturer).State = EntityState.Modified;
                this.dataContext.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(manufacturer);
        }

        // GET: Admin/Manufacturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Manufacturer manufacturer = this.dataContext.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return this.HttpNotFound();
            }

            return this.View(manufacturer);
        }

        // POST: Admin/Manufacturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = this.dataContext.Manufacturers.Find(id);
            this.dataContext.Manufacturers.Remove(manufacturer);
            this.dataContext.SaveChanges();
            return this.RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.dataContext.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
