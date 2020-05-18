using Consulting.Common;
using Consulting.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Consulting.Infrastructure.Core.Data.Repositories.EFCore;
using System.Linq;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Common.Collections;
using Microsoft.AspNetCore.Mvc;

namespace Consulting.Infrastructure.Core.Data.Factories
{
    public class ActionRequestFilter : IActionFilter
    {
        private IServiceProvider Provider;
        private IContextProviderFactory ContextProviderFactory;

        public ActionRequestFilter(IContextProviderFactory contextProviderFactory, IServiceProvider provider)
        {
            Provider = provider;
            ContextProviderFactory = contextProviderFactory;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
              var act = (RequestAttribute)(context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<RequestAttribute>().FirstOrDefault();

            if (act.RequestType == Common.Constants.RequestType.Post)
            {
                ContextProviderFactory.dbContext = Provider.GetServices<AppCommandDBContext>().FirstOrDefault();
            }
            else
            {
                ContextProviderFactory.dbContext = Provider.GetServices<AppQueryDBContext>().FirstOrDefault();
            }
        }

    }
}
