using FloritasStore.Models;
using FloritasStore.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloritasStore.Services.Authorization
{
    public class CompanyAuthorizationHandler : AuthorizationHandler<CompanyRequirement, Company>
    {

        public readonly UserManager<ApplicationUser> _userManager;

        public CompanyAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CompanyRequirement requirement, Company resource)
        {

            if (context.User.IsInRole("Admin"))
            {
                context.Succeed(requirement);
            }
            else
            {                

                var user = _userManager.GetUserAsync(context.User).Result;
                                
                if (resource.Id == user.CompanyId)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;

        }
    }

    public class CompanyRequirement : IAuthorizationRequirement { }

}
