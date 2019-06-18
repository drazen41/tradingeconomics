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
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetCalendarSvcAsync));
           
        }
        private async Task GetCalendarSvcAsync()
        {
            var calendarService = new CalendarService();
            var calendarList = await calendarService.GetCalendarsAsync();
            rptCalendar.DataSource = calendarList;
            rptCalendar.DataBind();
        }
        protected string FormatiranDatum(string datum)
        {
            return DateTime.Parse(datum).ToShortDateString();
        }

    }
}