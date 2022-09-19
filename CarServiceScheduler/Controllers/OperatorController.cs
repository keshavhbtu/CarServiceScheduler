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
    public class OperatorController : Controller
    {
        private readonly IOperatorBusinessService _operatorService;
        public OperatorController(IOperatorBusinessService operatorService)
        {
            _operatorService = operatorService;
        }
        // GET All Appointment for a operator 
        [HttpGet("{appointmentdate}/{operatorId}")]
        public ActionResult<IEnumerable<Appointment>> Get(string appointmentdate,int operatorId)
        {
            var result = _operatorService.GetAllAppointments(DateTime.Parse(appointmentdate.Replace('-', '/')), operatorId);
            return Ok(result);
        }

    }
}
