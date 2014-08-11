using System.Web.Optimization;
namespace Tateeda.Clires.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			/******************** J-QUERY *********************/
		    bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.*", "~/Scripts/jquery-migrate-1.*",
		        "~/Scripts/jquery.unobtrusive*", "~/Scripts/jquery.unobtrusive-ajax.js"));

			bundles.Add(new ScriptBundle("~/bundles/jquery-mobile").Include("~/Scripts/jquery-mobile*"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui*"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));
			bundles.Add(new ScriptBundle("~/bundles/requirejs").Include("~/Scripts/require.js"));
			/******************** SLIDER *********************/
			bundles.Add(new ScriptBundle("~/bundles/slider").Include("~/Scripts/Custom/PageSlider.js"));
			/******************** KNOCKOUT *********************/
			bundles.Add(
				new ScriptBundle("~/bundles/knockout").Include(
					"~/Scripts/TrafficCop.js",
					"~/Scripts/infuser.js",
					"~/Scripts/knockout*",
					"~/Scripts/koExternalTemplateEngine_all.js",
                    "~/Scripts/lib/knockout.simplegrid.1.3.js"));
			/******************** BOOTSTRAP *********************/
			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
			/******************** AJAX *********************/
			bundles.Add(new ScriptBundle("~/bundles/ajaxform").Include("~/Scripts/Custom/ajaxForm.js"));
			/******************** CALENDAR *********************/
			bundles.Add(
				new ScriptBundle("~/bundles/calendar").Include(
					"~/Scripts/lib/calendar/fullcalendar.js",
					"~/Scripts/lib/calendar/jquery-ui-sliderAccess.js",
					"~/Scripts/lib/calendar/jquery-ui-timepicker-addon.js",
					"~/Scripts/app/calendar/calendar.js"));

			/******************** TATEEDA *********************/
			bundles.Add(
				new ScriptBundle("~/bundles/tateedajs").Include("~/Scripts/toastr.js", "~/Scripts/main.js", "~/Scripts/app/config.js", "~/Scripts/app/feedback.js"));

			/******************** CALENDAR - STYLES *********************/
			bundles.Add(
				new StyleBundle("~/Content/calendar/css").Include(
					"~/Content/calendar/fullcalendar.print.css",
					"~/Content/calendar/fullcalendar.css",
					"~/Content/calendar/jquery-ui-timepicker-addon.css",
					"~/Content/calendar/calendar.css"));
			/******************** TATEEDA - STYLES *********************/
			bundles.Add(
				new StyleBundle("~/Content/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-responsive.min.css",
					"~/Content/toastr.css",
					"~/Content/toastr-responsive.css",
					"~/Content/clires.css",
					"~/Content/sitebar.css"));

			bundles.Add(
				new StyleBundle("~/Content/themes/base/css").Include(
					"~/Content/themes/base/jquery.ui.css",
					"~/Content/themes/base/jquery.ui.core.css",
					"~/Content/themes/base/jquery.ui.resizable.css",
					"~/Content/themes/base/jquery.ui.selectable.css",
					"~/Content/themes/base/jquery.ui.accordion.css",
					"~/Content/themes/base/jquery.ui.autocomplete.css",
					"~/Content/themes/base/jquery.ui.button.css",
					"~/Content/themes/redmond/jquery.ui.dialog.css",
					"~/Content/themes/redmond/jquery.ui.slider.css",
					"~/Content/themes/redmond/jquery.ui.tabs.css",
					"~/Content/themes/redmond/jquery.ui.datepicker.css",
					"~/Content/themes/redmond/jquery.ui.progressbar.css",
					"~/Content/themes/redmond/jquery.ui.theme.css"));
		}
	}
}