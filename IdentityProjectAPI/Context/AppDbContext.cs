using IdentityProjectAPI.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityProjectAPI.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string> 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
    }
}
