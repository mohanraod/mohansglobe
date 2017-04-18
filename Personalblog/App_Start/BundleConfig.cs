using System.Web;
using System.Web.Optimization;

namespace Personalblog
{
    public class BundleConfig
    {
        
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/home-page").Include(
                        "~/Scripts/player.js",
                        "~/Scripts/home.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/about").Include(
                      "~/Scripts/jquery-2.1.3.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/materialize.min.js",
                      "~/Scripts/retina.min.js",
                      "~/Scripts/scrollreveal.min.js",
                      "~/Scripts/swiper.jquery.min.js",
                      "~/Scripts/jquery.magnific-popup.min.js",
                      "~/Scripts/custom.js",
                      "~/Scripts/js.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/site.css",
                      "~/Content/SocialMediaShare.css"));

            bundles.Add(new StyleBundle("~/Content/about").Include(
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.css",
                      "~/Content/swiper.min.css",
                      "~/Content/materialize.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/style.css",
                        "~/Content/toggle.css"));
        }
    }
}
