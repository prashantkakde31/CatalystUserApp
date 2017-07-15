﻿using Interpidians.Catalyst.Client.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Interpidians.Catalyst.Client.Web.Common
{
    [AttributeUsageAttribute(AttributeTargets.Method, Inherited = true)]
    public sealed class AuthorizeActionAttribute : ActionFilterAttribute, IActionFilter
    {

        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            BaseController baseController = (BaseController)filterContext.Controller;

            // Checks whether the user session is active or not before checking user action access permission.
            if (baseController.sessionStore.ItemExists(SessionKeys.USER_DETAILS))
            {
                // Get requested action name.
                string action = this.AliasAction;
                if (string.IsNullOrEmpty(action))
                {
                    action = filterContext.ActionDescriptor.ActionName;
                }

                // Get user information from session.
                //LoginUserInformation userLoginInfo = baseController.sessionStore.GetItemFromSession<LoginUserInformation>(SessionKeys.USER_DETAILS);
                //UserInformation userInfo = userLoginInfo.UserInformation;

                //Checks whether user's PermittedActions list contians requested action. if not redirect of Access Denied page.

                //if (userInfo.PermittedActions.Count(pa => pa.ActionMethod == action) == 0)
                //{
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                        { "Controller", "Authorization" },
                        { "Action", "AccessDenied" },
                        {"returnUrl",filterContext.HttpContext.Request.Url.PathAndQuery}
                     });
                //}
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                           new RouteValueDictionary {
                        { "Controller", "Login" },
                        { "Action", "Index" },
                        {"returnUrl",filterContext.HttpContext.Request.Url.PathAndQuery}
                     });
            }
        }

        public string AliasAction
        {
            get;
            set;
        }
    }
}