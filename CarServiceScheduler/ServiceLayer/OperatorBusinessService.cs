using System;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using CarServiceScheduler.ServiceLayer.Interface;
namespace CarServiceScheduler.ServiceLayer
{
    public class OperatorBusinessService : IOperatorBusinessService
    {
        private readonly IOperatorDataService _operatorDataService;
        public OperatorBusinessService(IOperatorDataService operatorDataService)
        {
            _operatorDataService = operatorDataService;
        }

        public IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int operatorId)
        {

            return _operatorDataService.GetAllAppointments(appointmentdate, operatorId);

        }

    }
}
