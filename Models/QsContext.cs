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
        });
    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Payment> Payments { get; set; }
}