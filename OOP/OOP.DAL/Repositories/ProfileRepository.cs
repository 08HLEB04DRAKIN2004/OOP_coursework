//using OOP.DAL.Interface;
//using OOP.Domain.Entity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace OOP.DAL.Repositories
//{
//    public class ProfileRepository : IBaseRepository<Profile>
//    {
//        private readonly ApplicationDbContext _dbContext;

//        public ProfileRepository(ApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task Create(Profile entity)
//        {
//            await _dbContext.profiles.AddAsync(entity);
//            await _dbContext.SaveChangesAsync();
//        }

//        public IQueryable<Profile> GetAll()
//        {
//            return _dbContext.profiles;
//        }

//        public async Task Delete(Profile entity)
//        {
//            _dbContext.profiles.Remove(entity);
//            await _dbContext.SaveChangesAsync();
//        }

//        public async Task<Profile> Update(Profile entity)
//        {
//            _dbContext.profiles.Update(entity);
//            await _dbContext.SaveChangesAsync();

//            return entity;
//        }
//    }
//}
