using Microsoft.AspNetCore.Identity;

namespace IdentityProjectAPI.Entities
{
    public class AppRole : IdentityRole
    {
        public DateTime CreatedOn { get; set; }
    }
}
