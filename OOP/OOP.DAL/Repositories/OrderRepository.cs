using Microsoft.EntityFrameworkCore;
using OOP.DAL.Interface;
using OOP.Domain.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OOP.DAL.Repositories
{
    public class OrderRepository : IBaseRepository<Orders>
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Orders entity)
        {
            await _db.orders.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Orders> GetAll()
        {
            return _db.orders;
        }

        public async Task Delete(Orders entity)
        {
            _db.orders.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Orders> Update(Orders entity)
        {
            _db.orders.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
