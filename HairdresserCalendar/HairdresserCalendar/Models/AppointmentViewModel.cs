using System;

namespace HairdresserCalendar
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
        public string Hairdresser { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Color { get; internal set; }
    }
}