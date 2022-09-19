using System;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using CarServiceScheduler.ServiceLayer.Interface;

namespace CarServiceScheduler.ServiceLayer
{
    public class CustomerBusinessService : ICustomerBusinessService
    {
        private readonly ICustomerDataService _customerDataService;
        public CustomerBusinessService(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        public IEnumerable<Appointment> GetAllAppointments(DateTime appointmentdate, int customerId)
        {
            
            return _customerDataService.GetAllAppointments(appointmentdate, customerId);

        }

    }
}
