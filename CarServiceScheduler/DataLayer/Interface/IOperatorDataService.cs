using System;
using System.Collections.Generic;
using CarServiceScheduler.Models;

namespace CarServiceScheduler.DataLayer.Interface
{
    public interface IOperatorDataService
    {
        IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int operatorId);

    }
}
