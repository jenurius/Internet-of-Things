using System.Web;
using System.Web.Optimization;

namespace IOTWebsite_Final
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.min.js",
                      "~/Scripts/html5shiv.js",
                      "~/Scripts/jquery.isotope.min.js",
                      "~/Scripts/jquery.js",
                      "~/Scripts/jquery.prettyPhoto.js",
                      "~/Scripts/main.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/main.css",
                      "~/Content/prettyPhoto.css",
                      "~/Content/responsive.css"));
        }
    }
}
