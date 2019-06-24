using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
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
            var kes = Cache["CountryCodes"];
            if (kes == null)
                Kesiraj();
            else
                dicti = (Dictionary < string, string >) kes;

            
            ContentPlaceHolder cont = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            Panel panel = (Panel)cont.FindControl("pnlCountries");
            //if (!Page.IsPostBack)

                //else
                //    ToggleCountries();
                PopulateCountries(panel);
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            Panel pnl = (Panel)Page.FindControl("pnlCountries");
        }
        private void PopulateCountries(Panel pnl)
        {
            Panel panel = pnl;
            if (panel == null)
                panel = (Panel)Page.FindControl("pnlCountries");
           
            Table tbl = new Table();
            
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            CheckBox cb = new CheckBox();
            cb.Text = "Mexico";
            cb.CheckedChanged += new EventHandler(cbCountry_CheckedChanged);
            cb.AutoPostBack = true;
            tc.Controls.Add(cb);
            tr.Controls.Add(tc);
            tbl.Controls.Add(tr);
            panel.Controls.Add(tbl);
            //panel.CssClass = "countries";
        }

        private void cbCountry_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            cb.Checked = false;
            cb.Text = "Test";
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
        private void ToggleCountries()
        {
            ContentPlaceHolder cont = (ContentPlaceHolder)this.Master.FindControl("MainContent");
            var panel = (Panel)Page.FindControl("pnlCountries");
            //panel.Visible = panel.Visible == true ? false : true;
        }
        protected void pnlCountries_PreRender(object sender, EventArgs e)
        {
            //Panel panel = (Panel)sender;
            //if (Session["pnlCountries"] == null)
            //{
            //    PopulateCountries(panel);
            //    Session["pnlCountries"] = true;
            //    //panel.Visible = false;
            //}
            //if (!Page.IsPostBack)
            //{
            //    PopulateCountries(panel);
            //}


        }

        protected void btnCountries_ServerClick(object sender, EventArgs e)
        {
            var obj = sender;
        }
        private void Kesiraj()
        {
            Dictionary<string, string> dicti = new Dictionary<string, string>();
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

            }
            Cache.Add("CountryCodes", dicti,null,System.Web.Caching.Cache.NoAbsoluteExpiration,new TimeSpan(1000,0,0),CacheItemPriority.Normal,null);
           
            
        }
    }
}