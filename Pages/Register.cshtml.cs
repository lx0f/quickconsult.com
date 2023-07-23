using QuickConsult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Pages;

public class RegisterModel : PageModel
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    [BindProperty, Required]
    public required string Nric { get; set; }
    [BindProperty, Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
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

        var user = new User()
        {
            UserName = Nric,
            Nric = Nric,
        };
        var result = await _userManager.CreateAsync(user, Password);

        if (!result.Succeeded)
        {
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
            return Page();
        }

        await _userManager.AddToRoleAsync(user, "Patient");
        await _signInManager.SignInAsync(user, false);
        return Redirect("/index");
    }
}