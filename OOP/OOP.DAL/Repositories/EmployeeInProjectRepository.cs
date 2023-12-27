using OOP.DAL.Interface;
using OOP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DAL.Repositories
{
    public class EmployeeInProjectRepository : IBaseRepository<EmployeeInProject>
    {
        private readonly ApplicationDbContext _db;

        public EmployeeInProjectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(EmployeeInProject entity)
        {
            await _db.employeesInProject.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<EmployeeInProject> GetAll()
        {
            return _db.employeesInProject;
        }

        public async Task Delete(EmployeeInProject entity)
        {
            _db.employeesInProject.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<EmployeeInProject> Update(EmployeeInProject entity)
        {
            _db.employeesInProject.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }

}
