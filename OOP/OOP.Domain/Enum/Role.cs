using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.Enum
{

	public enum Role
	{
		[Display(Name = "Клиент")]
		User = 0,
		[Display(Name = "Модератор")]
		Moderator = 1,
		[Display(Name = "Админ")]
		Admin = 2,
	}
}
