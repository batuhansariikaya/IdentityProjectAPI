using IdentityProjectAPI.Entities;
using IdentityProjectAPI.Enums;
using IdentityProjectAPI.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityProjectAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly ISendMail _sendMail;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, ISendMail sendMail)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _sendMail = sendMail;
        }
        public async Task<IActionResult> SignUp()
        {
            AppUser user = new AppUser
            {
                UserName = "batuhansarikaya",
                Email = "batuhansarikaya008@gmail.com",
                Gender = Gender.Male,
                CreatedOn = DateTime.UtcNow
            };
            var result = _userManager.CreateAsync(user, "123456Aa*").Result;
            if (result.Succeeded)
            {
                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action("ConfirmEmail", "Home", new
                {
                    userId = user.Id,
                    token = confirmationToken,
                }, HttpContext.Request.Scheme);
                _sendMail.Send(user.Email, confirmationToken);
            }
            return View();
        }
    }
}
