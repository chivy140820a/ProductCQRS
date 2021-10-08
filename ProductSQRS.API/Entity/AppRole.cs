using Microsoft.AspNetCore.Identity;

namespace ProductSQRS.API.Entity
{
    public class AppRole:IdentityRole<string>
    {
        public string Decripstions { get; set; }
    }
}
