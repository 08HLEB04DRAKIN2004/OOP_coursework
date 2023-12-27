using OOP.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.Entity
{
    public class User
    {
        public int user_id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; } // Добавлено поле для номера телефона
        public string Email { get; set; } // Добавлено поле для электронной почты
        public Role Role { get; set; }
    }
}
