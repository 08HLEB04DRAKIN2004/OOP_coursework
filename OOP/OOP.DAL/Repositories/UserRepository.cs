using OOP.DAL.Interface;
using OOP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DAL.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<User> GetAll()
        {
            return _db.users;
        }

        public async Task Delete(User entity)
        {
            _db.users.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Create(User entity)
        {
            await _db.users.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<User> Update(User entity)
        {
            _db.users.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
