using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Models
{
    public class AddOrUpdateAppointmentViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Description { get; set; }
    }
}
