
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.Entity
{
		public 	class Client
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Client_id { get; set; }
		public string name { get; set; }
		public string contact_information { get; set; }
		public string contract { get; set; }

	}
}
