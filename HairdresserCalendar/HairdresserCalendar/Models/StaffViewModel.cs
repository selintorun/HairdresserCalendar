using HairdresserCalendar.Data.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Models
{
    public class StaffViewModel
    {
        public User User { get; set; }
        public IEnumerable<User> Hairdressers { get; set; }
        public List<SelectListItem> HairdressersSelectList { get; internal set; }
    }
}
