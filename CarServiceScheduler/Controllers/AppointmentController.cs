using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CarServiceScheduler.Models;
using CarServiceScheduler.ServiceLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarServiceScheduler.Controllers
{
    [Route("api/[controller]")]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentBusinessService _appointmentService;
        public AppointmentController(IAppointmentBusinessService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        
        // GET Available slots
        [HttpGet("{appointmentdate}/{operatorid:int=0}")]
        public ActionResult<IEnumerable<int>> Get(string appointmentdate, int operatorid=0)
        {
            var result = _appointmentService.GetAvailableTimeSlots(DateTime.Parse(appointmentdate.Replace('-', '/')), operatorid);
            return Ok(result);
        }
        
        // Book Appointment
        [HttpPost]
        public void Post([FromBody] Appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
            return;
        }

        // Reschedule Appointment
        [HttpPut("{appointmentid}")]
        public void Put(int appointmentid, [FromBody] Appointment appointment)
        {
            _appointmentService.RescheduleAppointment(appointmentid,appointment);
            return;
        }

        // Cancel Appointment
        [HttpDelete("{appointmentid}")]
        public void Delete(int appointmentid)
        {
            _appointmentService.CancelAppointment(appointmentid);
            return;
        }
    }
}
