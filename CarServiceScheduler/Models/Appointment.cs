using System;
namespace CarServiceScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int OperatorId { get; set; }
        public int CustomerId { get; set; }
        public int TimeSlot { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
