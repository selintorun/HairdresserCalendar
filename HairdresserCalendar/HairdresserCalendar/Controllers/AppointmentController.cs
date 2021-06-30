using HairdresserCalendar.Data;
using HairdresserCalendar.Data.Entity;
using HairdresserCalendar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult GetAppointments()
        {
            var model = _context.Appointments
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Hairdresser = x.User.Name + " " + x.User.Surname,
                    CustomerName = x.CustomerName,
                    CustomerSurname= x.CustomerSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });
            
            return Json(model);
        }

        public JsonResult GetAppointmentsByHairdresser(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
                .Include(x => x.User).Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Hairdresser = x.User.Name + " " + x.User.Surname,
                    CustomerName = x.CustomerName,
                    CustomerSurname = x.CustomerSurname,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Description = x.Description,
                    Color = x.User.Color,
                    UserId = x.User.Id
                });

            return Json(model);
        }

        [HttpPost]
        public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentViewModel model)
        {
            if (model.Id == 0)
            {
                Appointment entity = new Appointment()
                {
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CustomerName = model.CustomerName,
                    CustomerSurname = model.CustomerSurname,
                    Description = model.Description,
                    UserId = model.UserId
                    
                };

                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.Appointments.SingleOrDefault(x => x.Id == model.Id);
                
                if (entity == null)
                {
                    return Json("Güncelleme işlemi başarısız!");
                }

                entity.UpdatedDate = DateTime.Now;
                entity.CustomerName = model.CustomerName;
                entity.CustomerSurname = model.CustomerSurname;
                entity.Description = model.Description;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.UserId = model.UserId;

                _context.Update(entity);
                _context.SaveChanges();
            }

            return Json("200");
        }

        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _context.Appointments.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return Json("Silinecek kayıt bulunamadı.");
            }

            _context.Remove(entity);
            _context.SaveChanges();

            return Json("200");
        }

    }
}