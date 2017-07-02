using System.Web;
using System.Web.Optimization;

namespace ApplicantTracker
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/angularui").Include("~/Scripts/angular.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/angularlib")
                .IncludeDirectory("~/Scripts/Libraries", "*.js", searchSubdirectories:true));
            bundles.Add(new ScriptBundle("~/bundles/app").Include("~/Scripts/app.js")
                .IncludeDirectory("~/Scripts/Directives", "*.js", searchSubdirectories:true)
                .IncludeDirectory("~/Scripts/Controllers", "*.js", searchSubdirectories:true)
                .IncludeDirectory("~/Scripts/Services", "*.js", searchSubdirectories:true));
            //bundles.Add(new ScriptBundle("~/bundles/theme").Include("~/Scripts/sb-admin-2.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));            

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js","~/Scripts/respond.js"));
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content", "*.css", searchSubdirectories:true));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));
        }
    }
}
