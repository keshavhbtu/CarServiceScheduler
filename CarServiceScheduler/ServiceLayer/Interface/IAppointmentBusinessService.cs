using System;
using System.Collections.Generic;
using CarServiceScheduler.Models;

namespace CarServiceScheduler.ServiceLayer.Interface
{
    public interface IAppointmentBusinessService
    {
        IEnumerable<int> GetAvailableTimeSlots(DateTime appointmentdate, int operatorid);
        void AddAppointment(Appointment appointment);
        void RescheduleAppointment(int appointmentid, Appointment appointment);
        void CancelAppointment(int appointmentid);
    }
}
