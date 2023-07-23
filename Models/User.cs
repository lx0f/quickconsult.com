using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace QuickConsult.Models;

[Index(nameof(Nric), IsUnique = true)]
public class User : IdentityUser<Guid>
{
    public required string Nric { get; set; }
    public ICollection<Appointment> DoctorAppointments;
    public ICollection<Appointment> PatientAppointments;

    public static implicit operator User(ClaimsPrincipal v)
    {
        throw new NotImplementedException();
    }
}