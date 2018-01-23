using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Common.Web.Utils
{
    public class JsonBadRequest: JsonResult
    {
        public JsonBadRequest()
        {
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public JsonBadRequest(string message)
        {
            this.Data = message;
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public JsonBadRequest(object data)
        {
            this.Data = data;
            this.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = 400;
            base.ExecuteResult(context);
        }

    }
}
