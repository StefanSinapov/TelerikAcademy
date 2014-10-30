// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The bundle config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CrowdChat.Web
{
    using System.Web.Optimization;
    using System.Web.UI;

    /// <summary>
    /// The bundle config.
    /// </summary>
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkID=303951
        #region Public Methods and Operators

        /// <summary>
        /// The register bundles.
        /// </summary>
        /// <param name="bundles">
        /// The bundles.
        /// </param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(
                new ScriptBundle("~/bundles/WebFormsJs").Include(
                    "~/Scripts/WebForms/WebForms.js", 
                    "~/Scripts/WebForms/WebUIValidation.js", 
                    "~/Scripts/WebForms/MenuStandards.js", 
                    "~/Scripts/WebForms/Focus.js", 
                    "~/Scripts/WebForms/GridView.js", 
                    "~/Scripts/WebForms/DetailsView.js", 
                    "~/Scripts/WebForms/TreeView.js", 
                    "~/Scripts/WebForms/WebParts.js"));

            // Order is very important for these files to work, they have explicit dependencies
            bundles.Add(
                new ScriptBundle("~/bundles/MsAjaxJs").Include(
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjax.js", 
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxApplicationServices.js", 
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxTimer.js", 
                    "~/Scripts/WebForms/MsAjax/MicrosoftAjaxWebForms.js"));

            // Use the Development version of Modernizr to develop with and learn from. Then, when you’re
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;

            ScriptManager.ScriptResourceMapping.AddDefinition(
                "respond", 
                new ScriptResourceDefinition { Path = "~/Scripts/respond.min.js", DebugPath = "~/Scripts/respond.js", });
        }

        #endregion
    }
}