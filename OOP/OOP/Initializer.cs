using Microsoft.AspNetCore.Cors.Infrastructure;
using OOP.DAL.Interface;
using OOP.DAL.Repositories;
using OOP.Domain.Entity;
using OOP.Service.Implementations;
using OOP.Service.Interfaces;

namespace OOP
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseRepository<Orders>, OrderRepository>();
            services.AddScoped<IBaseRepository<Client>, ClientRepository>();
            services.AddScoped<IBaseRepository<EmployeeInProject>, EmployeeInProjectRepository>();
           
        }

        public static void InitializeServices(this IServiceCollection services)
        {
          
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmployeeInProjectService, EmployeeInProjectService>();
        }
    }
}
