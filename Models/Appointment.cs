using System.ComponentModel.DataAnnotations;

namespace QuickConsult.Models;

public class Appointment
{
    [Key]
    public Guid Id { get; set; }
    public required User Doctor { get; set; }
    public Guid DoctorId { get; set; }
    public required User Patient { get; set; }
    public Guid PatientId { get; set; }
    public DateTime DateTime { get; set; }
    public required string MeetLink { get; set; }
    public required string Remarks { get; set; }
    public string? AiSummary { get; set; }
    public string? Referral { get; set; }
    public Appointment? PreviousAppointment { get; set; }
    public Guid? PreviousAppointmentId { get; set; }
    public Appointment? NextAppointment { get; set; }
    public Guid? NextAppointmentId { get; set; }
}