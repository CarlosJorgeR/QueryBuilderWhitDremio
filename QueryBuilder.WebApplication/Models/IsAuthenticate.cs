using Microsoft.AspNetCore.Authorization;
using QueryBuilder.Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueryBuilder.WebApplication.Models
{
    public class IsAutenticate : AuthorizationHandler<IsAutenticate>, IAuthorizationRequirement
    {
        public IClient client { get; set; }
        public IsAutenticate(IClient client)
        {
            
            this.client = client;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAutenticate requirement)
        {
       
            if (!client.IsAutenticate)
                context.Fail();
            else
                context.Succeed(requirement);
        }
    }
    
}
