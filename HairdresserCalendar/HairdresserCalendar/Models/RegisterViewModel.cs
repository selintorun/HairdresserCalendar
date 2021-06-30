using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HairdresserCalendar.Models
{
    public class RegisterViewModel
    {
        [Required (ErrorMessage ="Kullanıcı adı boş bırakılamaz.")]
        [Display(Name="Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyisim alanı boş bırakılamaz.")]
        [Display(Name = "Soyisim")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email alanını kontrol ediniz.")]
        public string Email { get; set; }

        [Display(Name = "Salon No")]
        public string Color { get; set; }

        [Display(Name = "Uzman Girişi")]
        public bool IsHairdresser { get; set; }
    }
}
