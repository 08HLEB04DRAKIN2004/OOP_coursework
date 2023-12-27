using OOP.Domain.Entity;
using OOP.Domain.Response;
using OOP.Domain.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(int id);
    }
}
