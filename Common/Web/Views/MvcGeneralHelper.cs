using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Common.Web.Views
{
    public static class MvcGeneralHelper
    {
        public static string GetModelStateErrors(ModelStateDictionary modelState)
        {
            String messages = String.Join(Environment.NewLine, modelState.Values.SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage + " " + v.Exception));

            return messages;
        }
    }
}
