namespace World.Web
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using World.Data;
    using World.Models;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var data = new WorldData();
                var continents = data.Continents.All().Select(c => c.Name).ToList();
                this.ListBoxContinents.DataSource = continents;
                this.ListBoxContinents.DataBind();
            }
        }

        protected void BindCountries(object sender, EventArgs e)
        {
            var selectedContinent = this.ListBoxContinents.SelectedValue;

            var data = new WorldData();

            var coutries = data.Countries.All()
                .Where(c => c.Continent.Name == selectedContinent)
                .ToList();

            this.GridViewCoutries.DataSource = coutries;
            this.GridViewCoutries.DataBind();
        }

        protected void ButtonInsert_OnClick(object o, EventArgs e)
        {
            var data = new WorldData();

            var name = this.GridViewCoutries.FooterRow.FindControl("TextBoxCountryName") as TextBox;
            var language = this.GridViewCoutries.FooterRow.FindControl("TextBoxCountryLanguage") as TextBox;
            var population = this.GridViewCoutries.FooterRow.FindControl("TextBoxCountryPopulation") as TextBox;

            var continentName = this.ListBoxContinents.SelectedValue;
            var continent = data.Continents.All().First(c => c.Name == continentName);

            var country = new Country
                              {
                                  Name = name.Text,
                                  Population = decimal.Parse(population.Text),
                                  Language = language.Text,
                              };
            continent.Countries.Add(country);
            data.Continents.Update(continent);
            data.SaveChanges();

            this.BindCountries(null, null);
        }

        protected void GridViewCoutries_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridViewCoutries.PageIndex = e.NewPageIndex;
            this.BindCountries(null, null);
        }

        protected void GridViewCoutries_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var gridView = (GridView)sender;
            int countryId = int.Parse(gridView.DataKeys[e.RowIndex].Value.ToString());

            var data = new WorldData();

            var country = data.Countries.Find(countryId);
            data.Countries.Delete(country);

            data.SaveChanges();
            gridView.EditIndex = -1;
            this.BindCountries(null, null);
        }

        protected void GridViewCoutries_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.GridViewCoutries.EditIndex = -1;
            this.BindCountries(null, null);
        }

        protected void GridViewCoutries_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.GridViewCoutries.EditIndex = e.NewEditIndex;
            this.BindCountries(null, null);
        }

        protected void ListViewTowns_OnItemEditing(object sender, ListViewEditEventArgs e)
        {
            this.ListViewTowns.EditIndex = e.NewEditIndex;
            this.BindTowns(null, null);
        }

        protected void ListViewTowns_OnItemUpdating(object sender, ListViewUpdateEventArgs e)
        {
            var listView = (ListView)sender;
            int townId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());
            var data = new WorldData();

            var editedRow = listView.Items[e.ItemIndex];
            var name = editedRow.FindControl("TextBoxTownName") as TextBox;
            var population = editedRow.FindControl("TextBoxTownPopulation") as TextBox;

            var town = data.Towns.Find(townId);
            town.Name = name.Text;
            town.Population = decimal.Parse(population.Text);

            data.Towns.Update(town);
            data.SaveChanges();

            listView.EditIndex = -1;
            this.BindTowns(null, null);
        }

        protected void ListViewTowns_OnItemCanceling(object sender, ListViewCancelEventArgs e)
        {
            this.ListViewTowns.EditIndex = -1;
            this.BindTowns(null, null);
        }

        protected void ListViewTowns_OnItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            var listView = (ListView)sender;
            int townId = int.Parse(listView.DataKeys[e.ItemIndex].Value.ToString());
            var data = new WorldData();
            var town = data.Towns.Find(townId);

            data.Towns.Delete(town);
            data.SaveChanges();

            listView.EditIndex = -1;
            this.BindTowns(null, null);
        }

        protected void ListViewTowns_OnItemInserting(object sender, ListViewInsertEventArgs e)
        {
            string name = e.Values["Name"].ToString();
            var population = decimal.Parse(e.Values["Population"].ToString());
            
            int countryId = int.Parse(this.GridViewCoutries.SelectedValue.ToString());

            var town = new Town
            {
                Name = name,
                Population = population,
                CountryId = countryId
            };

            var data = new WorldData();
            data.Towns.Add(town);

            data.SaveChanges();
            this.ListViewTowns.EditIndex = -1;
            this.BindTowns(null, null);
        }

        protected void ListViewTowns_OnPagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            var townsPager = this.ListViewTowns.FindControl("DataPagerTowns") as DataPager;
            townsPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.BindTowns(null, null);
        }

        protected void ButtonAddTown_OnClick(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.FirstItem;
            this.BindTowns(null, null);
        }

        protected void ButtonCancelInsert_OnClick(object sender, EventArgs e)
        {
            this.ListViewTowns.InsertItemPosition = InsertItemPosition.None;
            this.BindTowns(null, null);
        }

        protected void BindTowns(object sender, EventArgs e)
        {
            var selectedCountryId = int.Parse(this.GridViewCoutries.SelectedValue.ToString());

            var data = new WorldData();
            var towns = data.Towns.All()
                .Where(c => c.CountryId == selectedCountryId)
                .ToList();
            this.ListViewTowns.DataSource = towns;
            this.ListViewTowns.DataBind();
        }
    }
}