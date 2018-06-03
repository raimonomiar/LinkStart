using System.Web;
using System.Web.Optimization;

namespace LinkStart
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js",
                        "~/assets/js/chartist.min.js",
                        "~/assets/js/paper-dashboard.js",
                        "~/Scripts/bootbox.min.js",
                        "~/Scripts/jquery.timeago.js",
                        "~/Scripts/knockout-3.4.2.js",
                        "~/Scripts/knockout.mapping-latest.js"
         
           
   
                        

                        ));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                        "~/Scripts/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/assets/js/bootstrap.min.js",
                      "~/assets/js/bootstrap-notify.js",
                      "~/assets/js/bootstrap-checkbox-radio.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/css/bootstrap.min.css",
                      "~/assets/css/animate.min.css",
                      "~/assets/css/paper-dashboard.css",
                      "~/assets/css/themify-icons.css",
                      "~/assets/css/font-awesome.min.css",
                      "~/assets/css/font.css",
                      "~/assets/css/Login.css"
                      ));
        }
    }
}
