using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.Sum_with_WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSum_OnClick(object sender, EventArgs e)
        {
            lbResult.Text = (int.Parse(tbFirstNumber.Text) + int.Parse(tbSecondNumber.Text)).ToString();
        }

    }
}