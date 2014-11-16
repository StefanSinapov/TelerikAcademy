namespace TelerikExamSystem.Web
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    public class ViewEnginesConfiguration
    {
        internal static void RegisterViewEngines(params BuildManagerViewEngine[] viewEngines)
        {
            ViewEngines.Engines.Clear();

            foreach (var viewEngine in viewEngines)
            {
                ViewEngines.Engines.Add(viewEngine);
            }
        }
    }
}