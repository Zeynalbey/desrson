﻿using DemoApplication.Controllers;
using DemoApplication.Services.Abstracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoApplication.Filters
{
    public class ActionFilter : IActionFilter
    {
        private readonly IUserService _userService;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        //public void OnActionExecuting(ActionExecutingContext context)
        //{

        //}

        public ActionFilter(IUserService userService)
        {
            _userService = userService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (_userService.IsAuthenticated)
            {
                var controller = (AuthenticationController)context.Controller;
                context.Result = controller.RedirectToRoute("client-account-dashboard");
            }
        }

    }
}
