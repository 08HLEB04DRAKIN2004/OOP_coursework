using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace OOP.Domain.Entity
{
    public class MediaResource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int resource_id { get; set; }

        [Required]
        public string name { get; set; }

        public string type { get; set; }
        public string url { get; set; }

        [ForeignKey("project_id")]
        public Project project { get; set; }

    }
}