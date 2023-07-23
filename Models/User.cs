using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace QuickConsult.Models;

[Index(nameof(Nric), IsUnique = true)]
public class User : IdentityUser<Guid>
{
    public required string Nric { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Appointment> DoctorAppointments;
    public ICollection<Appointment> PatientAppointments;
}