namespace UpdateAjax
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using UpdateAjax.Models;

    public partial class _Default : Page
    {
        public IQueryable<EmployeeViewModel> SelectEmployees()
        {
            var db = new NorthwindEntities();
            var employees =
                db.Employees.Select(
                    e =>
                    new EmployeeViewModel
                        {
                            Address = e.Address,
                            EmployeeID = e.EmployeeID,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Title = e.Title
                        }).OrderBy(e => e.EmployeeID);
            return employees;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridViewEmloyees_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            var gridView = sender as GridView;
            var value = Convert.ToInt32(gridView.SelectedValue);
            var db = new NorthwindEntities();
            this.GridViewOrders.DataSource = db.Orders.Where(x => x.EmployeeID == value).ToList();
            this.GridViewOrders.DataBind();
        }
    }
}