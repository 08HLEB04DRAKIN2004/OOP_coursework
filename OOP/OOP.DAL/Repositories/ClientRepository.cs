using Microsoft.EntityFrameworkCore;
using OOP.DAL.Interface;
using OOP.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OOP.DAL.Repositories
{
	public class ClientRepository : IBaseRepository<Client>
	{
		
			private readonly ApplicationDbContext _db;

			public ClientRepository(ApplicationDbContext db)
			{
				_db = db;
			}

			public async Task Create(Client entity)
			{
				await _db.clients.AddAsync(entity);
				await _db.SaveChangesAsync();
			}

			public IQueryable<Client> GetAll()
			{
				return _db.clients;
			}

			public async Task Delete(Client entity)
			{
				_db.clients.Remove(entity);
				await _db.SaveChangesAsync();
			}

			public async Task<Client> Update(Client entity)
			{
				_db.clients.Update(entity);
				await _db.SaveChangesAsync();

				return entity;
			}
		}
	}

