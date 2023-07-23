using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuickConsult.Pages.Doctor;

[Authorize(Roles = "Doctor")]
public class IndexModel : PageModel
{

}