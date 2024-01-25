using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Caloracker1.Controllers
{
    public class HomeController1 : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController1(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                // Kullanıcının özelliklerine erişin
                var userEmail = user.Email;
                // Diğer özellikleri de alabilirsiniz
            }

            return View();
        }
    }
}
