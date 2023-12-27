using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace OOP.Domain.Entity
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int department_id { get; set; }

        [Required]
        public string name { get; set; }
    }
}