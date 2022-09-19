using System;
using System.Collections.Generic;

namespace CarServiceScheduler.DataLayer.Interface
{
    public interface IAppointmentDataService
    {
        IEnumerable<int> GetBookedTimeSlots(DateTime appointmentdate);
        IEnumerable<int> GetBookedTimeSlots(DateTime appointmentdate, int operatorid);
        
        void AddAppointment(int CustomerId,int TimeSlot, DateTime AppointmentDate,int OperatorId);
        void AddAppointment(int CustomerId, int TimeSlot, DateTime AppointmentDate);
        void RescheduleAppointment(int appointmentid, int TimeSlot, DateTime AppointmentDate, int OperatorId);
        void RescheduleAppointment(int appointmentid, int TimeSlot, DateTime AppointmentDate);
        void CancelAppointment(int appointmentid);
    }
}
