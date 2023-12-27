﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Domain.Enum;

namespace OOP.Domain.Response
{

	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Description { get; set; }

		public StatusCode StatusCode { get; set; }

		public T Data { get; set; }
	}

	public interface IBaseResponse<T>
	{
		string Description { get; }
		StatusCode StatusCode { get; }
		T Data { get; }
	}
	
}
