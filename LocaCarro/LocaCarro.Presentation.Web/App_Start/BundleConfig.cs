using System.Web.Optimization;

namespace LocaCarro.Presentation.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Script Bundles
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));
                        
            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.js"));
            
            //Style Bundles
            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap/css/bootstrap.min.css", new CssRewriteUrlTransform())
                .Include("~/Content/font-awesome.min.css", new CssRewriteUrlTransform()));
        }
    }
}