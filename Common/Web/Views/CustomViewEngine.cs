
using System.Web.Mvc;

namespace Common.Web.Views
{
    public class CustomViewEngine: RazorViewEngine
    {
        public CustomViewEngine()
        {
            ViewLocationFormats = new string[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml"
            };
        }
    }
}
