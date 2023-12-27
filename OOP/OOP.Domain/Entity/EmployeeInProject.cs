using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OOP.Domain.Entity
{
    public class EmployeeInProject 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assignment_id { get; set; }
        public int project_id { get; set; }
        public int employee_id { get; set; }
        public int role_id { get; set; }
        [ForeignKey("project_id")]
        public Project Project { get; set; }
        [ForeignKey("employee_id")]
        public Employee Employee { get; set; }
        [ForeignKey("role_id")]
        public ProjectRole Role { get; set; }
    }
}