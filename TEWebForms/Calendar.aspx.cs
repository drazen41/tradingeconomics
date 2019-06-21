using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TEWebForms.Models.Responses;
using TEWebForms.Services;


namespace TEWebForms
{
    public partial class Calendar : System.Web.UI.Page 
    {
        private IEnumerable<DateTime> vanjskiPodaci = null;
        private List<CalendarResponse> listaDogadaji = null;
        Dictionary<string, string> dicti = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(GetCalendarSvcAsync));
            
            if (Session["countryCodes"] == null)
            {
                var pathToCsv = HttpContext.Current.Server.MapPath("~/App_Data/") + "CountryCodes.txt";
                var data = File.ReadLines(pathToCsv).Select(line => line.Split(','));
                //var data = File.ReadLines(pathToCsv);
                char[] quotes = { '\"', ' ' };
                foreach (var d in data)
                {
                    
                    string val = "";
                    string key = "";
                    if (d.Count() > 2)
                    {
                        var d0 = d[0].Trim(quotes).Replace("\\\"", "\"");
                        var d1 = d[1].Trim(quotes).Replace("\\\"", "\""); 
                        val = d0 + "-" + d1;
                        key = d[2];
                    }
                    else
                    {
                        val = d[0];
                        key = d[1];
                    }
                    
                    dicti.Add(key, val);
                    Session["countryCodes"] = dicti;
                }
                //var dict = data.ToDictionary(line => line[0], line => line[1]);
            }
            else
            {
                dicti = (Dictionary<string, string>)Session["countryCodes"];
            }
            
        }
        private void PopulateCountries(Panel pnl)
        {
            var panel = pnl;
            Table tbl = new Table();
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            CheckBox cb = new CheckBox();
            cb.Text = "Mexico";
            tc.Controls.Add(cb);
            tr.Controls.Add(tc);
            tbl.Controls.Add(tr);
            panel.Controls.Add(tbl);
        }

        private async Task GetCalendarSvcAsync()
        {
            var calendarService = new CalendarService();
            var calendarList = await calendarService.GetCalendarsAsync();
            vanjskiPodaci = calendarList.Select(x => x.Date.Date).Distinct();
            listaDogadaji = calendarList;
            rptCalendar.DataSource = vanjskiPodaci;
            rptCalendar.DataBind();
        }
        protected string FormatiranDatum(string datum)
        {
            return DateTime.Parse(datum).ToShortDateString();
        }

        protected void rptCalendar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater dogadaji = (Repeater)e.Item.FindControl("rtpDetails");
                Label lbl = (Label)e.Item.FindControl("labelDate");
                //Label lbl = (Label)rptCalendar.Controls[0].Controls[0].FindControl("labelDate");
                DateTime datum = DateTime.Parse(lbl.Text);
                var podaci = listaDogadaji.Where(x => x.Date.Date == datum);
                dogadaji.DataSource = podaci;
                dogadaji.DataBind();
            }
        }
        protected void rptDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var cr = (CalendarResponse)e.Item.DataItem;
                var drzava = cr.Country;
                Table tablica = (Table)e.Item.FindControl("tblCountry");
                if (tablica != null)
                {
                    string code = dicti.FirstOrDefault(x => x.Value == drzava).Key;

                    TableRow tr = new TableRow();
                    string klasa = "flag flag-" + code.ToLower();
                    Panel panel = new Panel();
                    panel.CssClass = klasa;
                    panel.ToolTip = drzava;
                    TableCell tc1 = new TableCell();
                    tc1.Controls.Add(panel);
                    
                    //tc1.CssClass = klasa;
                    tr.Cells.Add(tc1);
                    TableCell tc = new TableCell();
                    //tc.Controls.Add(new LiteralControl("Test"));
                    
                    tc.Text = code;
                    tr.Cells.Add(tc);
                    
                    tablica.Rows.Add(tr);
                }
                
            }
        }

        protected void pnlCountries_PreRender(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            if (Session["pnlCountries"] == null)
            {
                PopulateCountries(panel);
                Session["pnlCountries"] = true;
                panel.Visible = false;
            }
            else
            {
                panel.Visible = panel.Visible == true ? false : true;
            }


        }

       
    }
}