using QuickConsult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Pages.Doctor;

public class LoginModel : PageModel
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    [BindProperty, Required]
    public required string Nric { get; set; }
    [BindProperty, Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public LoginModel(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.FindByNameAsync(Nric);
        if (user is null)
        {
            ModelState.AddModelError(nameof(Nric), "User with this NRIC doesn't exist.");
            return Page();
        }

        if (!await _userManager.IsInRoleAsync(user, "Doctor"))
        {
            ModelState.AddModelError("", "You are not a doctor. Please go to http://quickconsult.com to access the patient portal.");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(user, Password, false, false);

        if (!result.Succeeded)
        {
            ModelState.AddModelError(nameof(Nric), "Either NRIC or Password is incorrect.");
            ModelState.AddModelError(nameof(Password), "Either NRIC or Password is incorrect.");
            return Page();
        }

        return Redirect("/index");
    }
}