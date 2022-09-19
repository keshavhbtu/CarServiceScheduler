using System;
using System.Collections.Generic;
using CarServiceScheduler.Models;

namespace CarServiceScheduler.ServiceLayer.Interface
{
    public interface ICustomerBusinessService
    {
        IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int customerId);
    }
}
