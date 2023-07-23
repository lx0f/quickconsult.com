using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Models;

public enum UserType
{
    Doctor,
    Patient
}

[Index(nameof(Nric), IsUnique = true)]
public class User : IdentityUser<Guid>
{
    [Key]
    public string Nric { get; set; }    
    public UserType Type { get; set; }
}