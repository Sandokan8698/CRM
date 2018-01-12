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
                case 1:
                    return new MvcHtmlString("label-success");
                default:
                    return  new MvcHtmlString("label-primary");
            }
        }
    }
}
