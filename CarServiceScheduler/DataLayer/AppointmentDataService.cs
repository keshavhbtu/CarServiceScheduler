using System;
using System.Collections.Generic;
using CarServiceScheduler.DataLayer.Interface;
using CarServiceScheduler.Models;
using Microsoft.Extensions.Configuration;

namespace CarServiceScheduler.DataLayer
{
    public class AppointmentDataService:BaseDataAccess,IAppointmentDataService
    {
        private readonly IConfiguration _configuration;
        public AppointmentDataService(IConfiguration configuration) : base(configuration)
        {
            
        }
        
        public IEnumerable<int> GetBookedTimeSlots(DateTime appointmentdate)
        {
            string query = "Select TimeSlot from Appointment where AppointmentDate= @appointmentdate group by timeslot having count(*)=(Select count(1) from Operator)";
            var parameters = new { appointmentdate = appointmentdate.Date};

            return ExecuteQuery<int>(query, parameters);
        }
        public IEnumerable<int> GetBookedTimeSlots(DateTime appointmentdate, int operatorid)
        {
            string query = "Select TimeSlot from Appointment where AppointmentDate= @appointmentdate and operatorid= @operatorid";
            var parameters = new { appointmentdate = appointmentdate.Date, operatorid = operatorid };

            return ExecuteQuery<int>(query, parameters);

        }
        public void AddAppointment(int CustomerId, int TimeSlot, DateTime AppointmentDate, int OperatorId)
        {
            string query = "INSERT INTO [Appointment] VALUES(@OperatorId, @CustomerId, @AppointmentDate, @TimeSlot)";
            var parameters = new { AppointmentDate = AppointmentDate.Date, OperatorId = OperatorId, CustomerId = CustomerId , TimeSlot = TimeSlot };
            ExecuteNonQuery(query, parameters);
            return;

        }
        public void AddAppointment(int CustomerId, int TimeSlot, DateTime AppointmentDate)
        {
            string query = "INSERT INTO [Appointment] VALUES((Select top 1 Id from operator where Id not in (Select OperatorId from Appointment where TimeSlot = @TimeSlot and AppointmentDate = @AppointmentDate)), @CustomerId, @AppointmentDate,@TimeSlot)";
            var parameters = new { AppointmentDate = AppointmentDate.Date, CustomerId = CustomerId, TimeSlot = TimeSlot };
            ExecuteNonQuery(query, parameters);
            return;

        }

        public void RescheduleAppointment(int appointmentid, int TimeSlot, DateTime AppointmentDate, int OperatorId)
        {
            string query = "UPDATE [Appointment] SET TimeSlot=@TimeSlot, AppointmentDate=@AppointmentDate, OperatorId=@OperatorId WHERE Id=@appointmentid";
            var parameters = new { AppointmentDate = AppointmentDate.Date, OperatorId = OperatorId, appointmentid = appointmentid, TimeSlot = TimeSlot };
            ExecuteNonQuery(query, parameters);
            return;

        }
        public void RescheduleAppointment(int appointmentid, int TimeSlot, DateTime AppointmentDate)
        {
            string query = "UPDATE [Appointment] SET TimeSlot=@TimeSlot, AppointmentDate=@AppointmentDate, OperatorId=(Select top 1 Id from operator where Id not in (Select OperatorId from Appointment where TimeSlot = @TimeSlot and AppointmentDate = @AppointmentDate)) WHERE Id=@appointmentid";
            var parameters = new { AppointmentDate = AppointmentDate.Date, appointmentid = appointmentid, TimeSlot = TimeSlot };
            ExecuteNonQuery(query, parameters);
            return;

        }

        public void CancelAppointment(int appointmentid)
        {
            string query = "Delete From [Appointment] where Id=@appointmentid";
            var parameters = new { appointmentid = appointmentid };
            ExecuteNonQuery(query, parameters);
            return;
        }
    }
}
