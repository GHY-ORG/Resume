using System.Web;
using System.Web.Optimization;

namespace BaoMing
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/js_bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/reset.css",
                      "~/Content/bootstrap.css",
                      "~/Content/baoMing.css",
                      "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/Content/css/index").Include(
                      "~/Content/index.css"));
        }
    }
}
