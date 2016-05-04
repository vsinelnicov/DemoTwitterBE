using System.Web.Optimization;

namespace DemoTwitter.WEB
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include
                ("~/bootstrap.js",
                "~/bootstrap.min.js",
                "~/jquery.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include
                ("~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",
                "~/Content/business-casual.css",
                "~/Content/login.css"));
        }
    }
}