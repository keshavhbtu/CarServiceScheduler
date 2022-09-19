using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceScheduler.Models;
using CarServiceScheduler.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarServiceScheduler.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerBusinessService _customerService;
        public CustomerController(ICustomerBusinessService customerService)
        {
            _customerService = customerService;
        }
        // GET Appointments for customer to view/cancel/reschedule
        [HttpGet("{appointmentdate}/{customerId}")]
        public ActionResult<IEnumerable<Appointment>> Get(string appointmentdate, int customerId)
        {
            var result = _customerService.GetAllAppointments(DateTime.Parse(appointmentdate.Replace('-', '/')),customerId);
            return Ok(result);
        }
    }
}
