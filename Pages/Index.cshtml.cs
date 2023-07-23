using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace QuickConsult.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public IndexModel(ILogger<IndexModel> logger, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> OnGet()
    {
        var doctorResult = await _roleManager.FindByNameAsync("Doctor");
        if (doctorResult is null)
        {
            await _roleManager.CreateAsync(new IdentityRole<Guid>() { Name = "Doctor" });
        }

        var patientResult = await _roleManager.FindByNameAsync("Patient");
        if (patientResult is null)
        {
            await _roleManager.CreateAsync(new IdentityRole<Guid>() { Name = "Patient" });
        }

        return Page();
    }
}
