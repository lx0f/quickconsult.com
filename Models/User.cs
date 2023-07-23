using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace QuickConsult.Models;

[Index(nameof(Nric), IsUnique = true)]
public class User : IdentityUser<Guid>
{
    public required string Nric { get; set; }
    public required ICollection<Appointment> DoctorAppointments;
    public required ICollection<Appointment> PatientAppointments;
}