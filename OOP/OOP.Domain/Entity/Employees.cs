using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OOP.Domain.Entity
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int employee_id { get; set; }

        [Required]
        public string name { get; set; }

        public string position { get; set; }
        public decimal? salary { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        [ForeignKey("departament_id")]
        public Department department { get; set; }
    }
}