using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Caching;

namespace TEWebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Kesiraj();
        }
        private void Kesiraj()
        {
            System.Web.Caching.Cache cc = System.Web.HttpContext.Current.Cache;
            if (cc["CountryCodes"] == null)
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
                cc.Add("CountryCodes", dicti, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(1000, 0, 0), CacheItemPriority.Normal, null);
            }



        }

    }
}