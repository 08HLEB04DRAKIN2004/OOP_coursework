using OOP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.ViewModel.EmployeesInProject
{
    public class EmployeeInProjectViewModel
    {
        public int assignment_id { get; set; }

        [Required(ErrorMessage = "Поле 'project_id' обязательно для заполнения.")]
        public int project_id { get; set; }

        [Required(ErrorMessage = "Поле 'employee_id' обязательно для заполнения.")]
        public int employee_id { get; set; }

        [Required(ErrorMessage = "Поле 'role_id' обязательно для заполнения.")]
        public int role_id { get; set; }

        public Project Project { get; set; }
        public Employee Employee { get; set; }
        public ProjectRole Role { get; set; }
    }

}
