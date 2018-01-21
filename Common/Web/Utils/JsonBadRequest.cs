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
        }

        public JsonBadRequest(string message)
        {
            this.Data = message;
        }

        public JsonBadRequest(object data)
        {
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = 400;
            base.ExecuteResult(context);
        }

    }
}
