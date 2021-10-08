using Microsoft.AspNetCore.Authorization;
using ProductSQRS.API.Requitment;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSQRS.API
{
    public class AppAuthorizationHandler : IAuthorizationHandler
    {
        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();
            var resource = context.Resource;
            foreach(var requitment in pendingRequirements)
            {
                if(requitment is CheckRequitment)
                {
                    var text = (int)resource;
                   if(text>18)
                    {
                        context.Succeed(requitment);
                    }
                    else
                    {
                        context.Fail();
                    }
                }    
            }
            return Task.CompletedTask;
        }
    }
}
