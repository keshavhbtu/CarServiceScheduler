using System;
using System.Collections.Generic;
using CarServiceScheduler.Models;

namespace CarServiceScheduler.DataLayer.Interface
{
    public interface ICustomerDataService
    {
        IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate,int customerId);
    }
}
