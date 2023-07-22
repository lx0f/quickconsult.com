using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Models;

public enum PaymentStatus
{
    Canceled,
    Done,
    Pending,
}

public class Payment
{
    [Key]
    public Guid Id { get; set; }
    public PaymentStatus Status { get; set; }
    public required Appointment Appointment { get; set; }
    public float Amount { get; set; } = 20;
}