using System;
using System.Collections.Generic;
using System.Linq;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using CarServiceScheduler.ServiceLayer.Interface;

namespace CarServiceScheduler.ServiceLayer
{
    public class AppointmentBusinessService: IAppointmentBusinessService
    {
        private readonly IAppointmentDataService _appointmentDataService;
        public AppointmentBusinessService(IAppointmentDataService appointmentDataService)
        {
            _appointmentDataService = appointmentDataService;
        }

        public IEnumerable<int> GetAvailableTimeSlots(DateTime appointmentdate, int operatorid)
        {
            IEnumerable<int> bookedSlots = new List<int>();
            IList<int> allTimeSlots = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                allTimeSlots.Add(i);
            }
            if (operatorid == 0) bookedSlots = _appointmentDataService.GetBookedTimeSlots(appointmentdate);
            if (operatorid != 0) bookedSlots = _appointmentDataService.GetBookedTimeSlots(appointmentdate, operatorid);
            return allTimeSlots.Except(bookedSlots);
          

        }
        public  void AddAppointment(Appointment appointment)
        {
            if (appointment.OperatorId != 0)
            {
                 _appointmentDataService.AddAppointment(appointment.CustomerId, appointment.TimeSlot, appointment.AppointmentDate, appointment.OperatorId);
            }else
                 _appointmentDataService.AddAppointment(appointment.CustomerId, appointment.TimeSlot, appointment.AppointmentDate);

            return;

        }
        public void RescheduleAppointment(int appointmentid, Appointment appointment)
        {
            if (appointment.OperatorId != 0)
            {
                _appointmentDataService.RescheduleAppointment(appointmentid,appointment.TimeSlot, appointment.AppointmentDate, appointment.OperatorId);
            }
            else
                _appointmentDataService.RescheduleAppointment(appointmentid, appointment.TimeSlot, appointment.AppointmentDate);

            return;

        }
 
        public void CancelAppointment(int appointmentid)
        {
            _appointmentDataService.CancelAppointment(appointmentid);
            return;
        }
    }
}
