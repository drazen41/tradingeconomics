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
    public partial class Rating : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetRatingsSvcAsync));
           
        }
        private async Task GetRatingsSvcAsync()
        {
            var ratingService = new RatingService();
            var ratingList = await ratingService.GetRatingsAsync();
            gvRatings.DataSource = ratingList;
            gvRatings.DataBind();
        }

    }
}