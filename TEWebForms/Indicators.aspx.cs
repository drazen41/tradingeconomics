using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEWebForms.Services;

namespace TEWebForms
{
    public partial class Indicators : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetIndicatorsSvcAsync));
        }
        private async Task GetIndicatorsSvcAsync()
        {
            var indicatorsService = new IndicatorService();
            var indicatorsList = await indicatorsService.GetCountryIndicatorsAsync("mexico");
            gvIndicators.DataSource = indicatorsList;
            gvIndicators.DataBind();
        }
    }
}