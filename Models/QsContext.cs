using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuickConsult.Models;

public class QsContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public QsContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Appointment>(entity =>
        {
            entity.HasOne(e => e.PreviousAppointment)
                .WithOne()
                .HasForeignKey<Appointment>(e => e.PreviousAppointmentId);

            entity.HasOne(e => e.NextAppointment)
                .WithOne()
                .HasForeignKey<Appointment>(e => e.NextAppointmentId);

            entity.HasOne(e => e.Doctor)
                .WithOne()
                .HasForeignKey<Appointment>(e => e.DoctorId);

            entity.HasOne(e => e.Patient)
                .WithOne()
                .HasForeignKey<Appointment>(e => e.PatientId);
        });

        builder.Entity<User>(entity =>
        {
            entity.HasMany(e => e.DoctorAppointments)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);
            entity.HasMany(e => e.PatientAppointments)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);
        });
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Payment> Payments { get; set; }
}