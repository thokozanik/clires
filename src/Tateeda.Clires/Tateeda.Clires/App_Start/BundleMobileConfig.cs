namespace Tateeda.Clires.App_Start
{
	using global::System.Web.Optimization;

	public class BundleMobileConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquerymobile")
				.Include("~/Scripts/jquery.mobile-{version}.js", "~/Scripts/toastr.min.js"));

			bundles.Add(new StyleBundle("~/Content/Mobile/css")
				.Include("~/Content/Site.Mobile.css", "~/Content/toastr.min.css"));

			bundles.Add(new StyleBundle("~/Content/jquerymobile/css")
				.Include("~/Content/jquery.mobile-{version}.css"));
		}
	}
}