using QuickConsult.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Pages.Doctor;

public class RegisterModel : PageModel
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    [BindProperty, Required]
    public required string Nric { get; set; }
    [BindProperty, Required]
    public string FirstName { get; set; }
    [BindProperty, Required]
    public string LastName { get; set; }
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

        // TODO: fetch from external data store instead
        var vettedDoctorsList = new List<string>() { "t0412345d", "s0412345d", "k0412475d" };
        if (!vettedDoctorsList.Contains(Nric.ToLower()))
        {
            ModelState.AddModelError("", "You are not a verified doctor. Please contact National University Hosptial.");
            return Page();
        }

        // check if user already exists as a patient
        var possibleUser = await _userManager.FindByNameAsync(Nric.ToLower());
        if (possibleUser is not null)
        {
            await _userManager.AddToRoleAsync(possibleUser, "Doctor");
            return Redirect("/doctor");
        }

        var user = new User()
        {
            UserName = Nric,
            Nric = Nric,
            FirstName = FirstName,
            LastName = LastName
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

        await _userManager.AddToRoleAsync(user, "Doctor");
        await _signInManager.SignInAsync(user, false);
        return Redirect("/index");
    }
}