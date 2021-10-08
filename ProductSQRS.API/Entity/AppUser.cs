using Microsoft.AspNetCore.Identity;

namespace ProductSQRS.API.Entity
{
    public class AppUser:IdentityUser<string>
    {
        public int BirdDate { get; set; }
    }
}
