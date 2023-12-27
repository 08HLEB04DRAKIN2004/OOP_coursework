using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,
        InternalServerError = 500,
		Success = 501,
		Error = 502,
		NotFound = 503,
        UserNotFound = 0,
        UserAlreadyExists = 1
    }
}
