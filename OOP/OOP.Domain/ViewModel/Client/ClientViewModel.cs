using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class ClientViewModel
{
	[Required(ErrorMessage = "Please enter a client ID")]
    [Display(Name = "Client ID")]
    public int ClientId { get; set; }

    [Required(ErrorMessage = "Имя клиента обязательно")]
	public string Name { get; set; }

	[Required(ErrorMessage = "Контактная информация обязательна")]
	public string ContactInformation { get; set; }

	[Required(ErrorMessage = "Договор обязателен")]
	public string Contract { get; set; }
}

