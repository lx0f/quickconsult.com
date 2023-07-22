using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace QuickConsult.Models;

public enum UserType
{
    Doctor,
    Patient
}

[Index(nameof(Nric), IsUnique = true)]
public class User : IdentityUser<Guid>
{
    public required string Nric { get; set; }
    public required UserType Type { get; set; }
}