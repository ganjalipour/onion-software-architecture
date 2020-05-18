using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Consulting.Common.Model;
using Newtonsoft.Json;
using Consulting.Common.Constants;

namespace Consulting.Applications.AppService.AuthAppService
{
 public class ValidateModelStateAttribute: Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.ModelState.IsValid)
            {
                var modelStateEntries = actionContext.ModelState.Values;
                ResultObject resultObject = new ResultObject();

                foreach (var item in modelStateEntries)
                {
                    foreach(var error in item.Errors)
                    {
                        resultObject.ServerErrors.Add(new ServerErr() { Hint = error.ErrorMessage, Type = ConstErrorTypes.ModelError });
                    }
                }
                actionContext.Result = new JsonResult(resultObject);
            }
        }


    }
}
