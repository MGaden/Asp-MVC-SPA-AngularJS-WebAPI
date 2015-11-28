using Microsoft.Ajax.Utilities;
using System.Web;
using System.Web.Optimization;

namespace WebClient
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-rtl").Include(
           "~/Scripts/bootstrap-rtl.js",
           "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css", "~/Content/style.css"));


            bundles.Add(new StyleBundle("~/Content/css-rtl").Include(
                      "~/Content/bootstrap-rtl.css",
                      "~/Content/site.css", "~/Content/style.css"));

            var AngularJSBundle = new ScriptBundle("~/bundles/angular").Include(
                 "~/Scripts/angular.js",
                 "~/Scripts/angular-resource.js",
                 "~/Scripts/angular-route.js",
                 "~/Scripts/angular-animate.min.js",
                 "~/Scripts/angular-confirm.js",
                 "~/Scripts/ui-bootstrap-tpls-0.14.3.js"
                 ).Include("~/Scripts/ui.*");
            bundles.Add(AngularJSBundle);

            bundles.Add(new ScriptBundle("~/bundles/json2")
               .Include("~/Scripts/json2.js"));

            var AppBundle = new ScriptBundle("~/bundles/app")
               .IncludeDirectory("~/app", "*.js", false)
               .IncludeDirectory("~/app/directives", "*.js", false)
               .IncludeDirectory("~/app/services", "*.js", false)
               .IncludeDirectory("~/app/controllers", "*.js", false)
               .Include("~/Scripts/underscore.js");
            bundles.Add(AppBundle);

        }
    }

    /// <summary>
    /// exclude set of names from being minified
    /// </summary>
    public class NoRenameTransform : IBundleTransform
    {
        protected static Minifier compiler = new Minifier();

        public void Process(BundleContext context, BundleResponse response)
        {
        }
    }
}
