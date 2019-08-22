using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartEssentials.WebApi.Filters
{
    public class EnsureUserLoggedIn : ActionFilterAttribute
    {
        private readonly IClientContext _clientContext;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserRepository _userRepository;

        public EnsureUserLoggedIn()
        {
            // I was unable able to remove the default ctor 
            // because of compilation error while using the 
            // attribute in my controller
        }

        public EnsureUserLoggedIn(IClientContext clientContext,
                                IHttpContextAccessor httpContext,
                                IUserRepository userRepository)
        {
            _clientContext = clientContext;
            _httpContext = httpContext;
            _userRepository = userRepository;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userId = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (String.IsNullOrEmpty(userId))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                context.Result = new JsonResult("Unauthorized");
            }

            User user = _userRepository.Get(userId);

            _clientContext.User = user;
        }
    }
}
