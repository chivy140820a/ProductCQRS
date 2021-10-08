using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ProductSQRS.API.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProductSQRS.API.SerVice.RequitmentSV
{
    public class RequitmentSerVice : IRequitmentSerVice
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IAuthorizationService _authorizationService;
        public RequitmentSerVice(IAuthorizationService authorizationService, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
        }
        public async Task<bool> Author(string UserName)
        {
            var claimUser = new ClaimsPrincipal();
            var users = await _userManager.FindByNameAsync(UserName);
            var user = await _authorizationService.AuthorizeAsync(claimUser,users.BirdDate,"Requitmentpolycy");
            if(user.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
