﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QuanLyDuLich.Filter
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentUser = filterContext.HttpContext.Session["ID"];
            if (currentUser == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        controller = "LogIn",
                        action = "LogIn"
                    })
                );
            }
            base.OnActionExecuting(filterContext);
        }
    }
}