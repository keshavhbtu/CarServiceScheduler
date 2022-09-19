using System;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using Microsoft.Extensions.Configuration;

namespace CarServiceScheduler.DataLayer
{
    public class CustomerDataService : BaseDataAccess, ICustomerDataService
    {
        private readonly IConfiguration _configuration;
        public CustomerDataService(IConfiguration configuration) : base(configuration)
        {

        }

        public IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate,int customerId)
        {
            string query = "Select * from Appointment where CustomerId=@customerId AND AppointmentDate=@appointmentdate";
            var parameters = new { customerId = customerId , appointmentdate = appointmentdate.Date};

            return ExecuteQuery<Appointment>(query, parameters);
        }
    
    }
}
