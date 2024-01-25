using Caloracker1.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize] // Eğer kullanıcı girişi gerekiyorsa
public class UserController : Controller
{
    private readonly Caloracker1Context _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(Caloracker1Context context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<IActionResult> AddUserRole(string userId)
    {
        // Check if the user exists
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            // Handle the case where the user is not found
            return NotFound($"User with ID {userId} not found.");
        }

        // Check if the role exists by name
        var roleName = "PremiumUser";

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            // If the role doesn't exist, create it
            role = new IdentityRole(roleName);
            await _roleManager.CreateAsync(role);
        }

        // Check if the user already has the role
        var userRole = await _context.UserRoles
            .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == role.Id);

        if (userRole == null)
        {
            // If the user doesn't have the role, add it
            userRole = new IdentityUserRole<string>
            {
                UserId = userId,
                RoleId = role.Id
            };

            _context.UserRoles.Add(userRole);
            await _context.SaveChangesAsync();
        }

        return Ok("User role added or changed successfully.");
    }





    [HttpPost]
    public async Task<IActionResult> MakeUserPremium(string userId)
    {
        try
        {
            // Get the user
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var premiumRole = await _roleManager.FindByNameAsync("PremiumUser");
            if (premiumRole == null)
            {
                premiumRole = new IdentityRole("PremiumUser");
                await _roleManager.CreateAsync(premiumRole);
            }

            // Remove existing roles
            var existingRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, existingRoles);

            // Add the Premium role to the user
            await _userManager.AddToRoleAsync(user, "PremiumUser");

            return Ok("User has been made Premium.");
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return StatusCode(500, "An error occurred while making the user Premium.");
        }
    }


// GET: User/Index
public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // GET: User/Details/5
    public async Task<IActionResult> Details(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }


    // GET: User/Edit/5
    public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: User/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email")] IdentityUser user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _userManager.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        return View(user);
    }

    // GET: User/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        await _userManager.DeleteAsync(user);
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(string id)
    {
        return _userManager.Users.Any(e => e.Id == id);
    }
}
