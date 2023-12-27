using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.ViewModel.UserViewModel
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public int User_Id { get; set; }

        [Required(ErrorMessage = "Укажите роль")]
        [Display(Name = "Роль")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Укажите логин")]
        [Display(Name = "Логин")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Укажите e-mail")]
        [EmailAddress(ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; } 
    }
}
