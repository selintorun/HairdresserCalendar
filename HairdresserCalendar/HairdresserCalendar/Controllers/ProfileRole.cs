using HairdresserCalendar.Data.Entity;
using HairdresserCalendar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Controllers
{
    public class ProfileRole : Controller
    {
        private UserManager<User> _userManager;
        public ProfileRole(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            User user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            if (user==null)
            {
                return RedirectToAction("Login", "Account");
                //return View();
            }

            if (_userManager.IsInRoleAsync(user, "Staff").Result)
            {
                var hairdressers = _userManager.Users.Where(x => x.IsHairdresser);
                StaffViewModel model = new StaffViewModel()
                {
                    User = user,
                    Hairdressers = hairdressers,
                    HairdressersSelectList = hairdressers.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Staff", model);
            }
            else
            {
                var hairdressers = _userManager.Users.Where(x => x.IsHairdresser);
                StaffViewModel model = new StaffViewModel()
                {
                    User = user,
                    Hairdressers = hairdressers,
                    HairdressersSelectList = hairdressers.Select(n => new SelectListItem
                    {
                        Value = n.Id,
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Hairdresser", model);
            }

        }

        public IActionResult Staff()
        {
            return View();
        }

        public IActionResult Hairdresser()
        {
            return View();
        }
    }
}
