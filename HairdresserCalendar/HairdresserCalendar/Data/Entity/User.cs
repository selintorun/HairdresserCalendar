using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Data.Entity
{
    public class User : IdentityUser
    {
        public bool IsHairdresser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Color { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
