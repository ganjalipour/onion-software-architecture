using Consulting.Applications.AppService.RoleManagement;
using Consulting.Common.Constants;
using Consulting.Domains.Core.MongoDb.Service;
using Consulting.Domains.MongoDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Consulting.Common.Auth;

namespace Consulting.Applications.AppService.AuthAppService
{
    public class MicroFundAuthorizeAttribute : Attribute
    {
        public int ActionID { get; set; }
        public MicroFundAuthorizeAttribute(int actionID)
        {
            ActionID = actionID;
        }
    }

    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        //private readonly PermissionItem _item;
        //private readonly int _action;
        public AuthorizeActionFilter()
        {
            // _action = action;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // bool isAuthorized = MumboJumboFunction(context.HttpContext.User, _item, _action); // :)
            bool isAuthorized = true;
            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
            }
        }

    }


    public class ActionFilterMicroFund : IActionFilter
    {
        private AccessControlAppService accessControlAppService;
        private ServiceLogService serviceLogService;
        public int UserID = 0;
        public DateTime RequestDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public ActionFilterMicroFund(AccessControlAppService _accessControlAppService, ServiceLogService _serviceLogService)
        {
            accessControlAppService = _accessControlAppService;
            serviceLogService = _serviceLogService;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int activityID = 0;
            var act = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<MicroFundAuthorizeAttribute>();

            foreach (var itemAct in act)
            {
                activityID = itemAct.ActionID;
            }

            var accessToken = context.HttpContext.Request.Headers["Authorization"];
            JwtSecurityToken jsonToken = new JwtSecurityToken();
            if (accessToken.Count > 0)
            {
                string jwt = accessToken[0].Replace("Bearer ", string.Empty);
                var handler = new JwtSecurityTokenHandler();

                var isTokenValid = JwtUserAuthentication.ValidateToken(jwt, out UserID);
                if (!isTokenValid) throw new Exception("شناسه کاربری معتبر نیست");
            }

#if DEBUG
            //bool hasAccess = accessControlAppService.CheckAccess(UserID, activityID).Result;
            //if (!hasAccess) throw new Exception(" خطای دسترسی : " + Convert.ToString(activityID));
#endif
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {
            ServiceLog servlog = new ServiceLog
            {
                requestMethod = context.HttpContext.Request.Method,
                requestDate = RequestDate,
                requestUri = context.HttpContext.Request.Path,
                ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString(),
                userID = UserID,
                //requestContent = context.HttpContext.Request.Body,
                requestContentType = context.HttpContext.Request.ContentType,
                responseDate = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                //responseContent = context.HttpContext.Response.Body,
                responseStatusCode = context.HttpContext.Response.StatusCode,
                responseContentType = context.HttpContext.Response.ContentType
            };

#if !DEBUG
            serviceLogService.AddServiceLog(servlog);
#endif
        }
    }


    //public class TestAttribute : Attribute
    //{
    //    public TestAttribute(ControllerContext controllerContext)
    //    {         
    //        int activityID = 0;
    //        var actt = (controllerContext.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<MicroFundAuthorizeAttribute>();

    //        foreach (var itemAct in act)
    //        {
    //            activityID = itemAct.ActionID;
    //        }

    //        foreach (var item in controllerContext.HttpContext.User.Claims)
    //        {
    //            if (item.Type == "jti") UserID = Convert.ToInt32(item.Value);
    //        }
    //    }
    //}

}
