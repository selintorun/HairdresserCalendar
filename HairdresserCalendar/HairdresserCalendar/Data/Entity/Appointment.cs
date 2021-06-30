using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Data.Entity
{
    public class Appointment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string Description { get; set; }
    }
}
