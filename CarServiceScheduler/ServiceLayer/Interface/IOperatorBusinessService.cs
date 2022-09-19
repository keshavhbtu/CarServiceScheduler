using System;
using System.Collections.Generic;
using CarServiceScheduler.Models;

namespace CarServiceScheduler.ServiceLayer.Interface
{
    public interface IOperatorBusinessService
    {
        IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int customerId);
    }
}
