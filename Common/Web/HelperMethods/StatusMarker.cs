using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.Web.HelperMethods
{
    public static class StatusMarker
    {
        public static MvcHtmlString StatusClass(this HtmlHelper html, int estado)
        {
            TagBuilder tag = new TagBuilder("span");

            switch (estado)
            {
                case 4:
                    return new MvcHtmlString("label-warning");
                case 2:
                    return  new MvcHtmlString("label-success");
                case 3:
                    return  new MvcHtmlString("label-danger");
                default:
                    return  new MvcHtmlString("label-primary");
            }
        }
    }
}
