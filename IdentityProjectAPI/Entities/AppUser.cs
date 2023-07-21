using IdentityProjectAPI.Enums;
using Microsoft.AspNetCore.Identity;

namespace IdentityProjectAPI.Entities
{
    public class AppUser:
    IdentityUser
    {
        public Gender Gender { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}
