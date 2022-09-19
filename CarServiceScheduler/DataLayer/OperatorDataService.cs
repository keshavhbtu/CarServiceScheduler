using System;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using Microsoft.Extensions.Configuration;
namespace CarServiceScheduler.DataLayer
{
    public class OperatorDataService : BaseDataAccess, IOperatorDataService
    {
        private readonly IConfiguration _configuration;
        public OperatorDataService(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int operatorId)
        {
            string query = "Select * from Appointment where OperatorId=@operatorId AND AppointmentDate=@appointmentdate";
            var parameters = new { operatorId = operatorId, appointmentdate = appointmentdate.Date };

            return ExecuteQuery<Appointment>(query, parameters);
        }

    }
}
