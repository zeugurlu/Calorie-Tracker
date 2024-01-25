using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class UserRoleController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddUserRole(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var roleExists = await _roleManager.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            // Role doesn't exist, handle accordingly (create or show error)
            return NotFound();
        }

        var result = await _userManager.AddToRoleAsync(user, roleName);
        if (result.Succeeded)
        {
            // User added to role successfully
            return RedirectToAction("Index", "Home"); // Change to your desired redirect
        }
        else
        {
            // Failed to add user to role, handle accordingly
            return View("Error");
        }
    }
}
