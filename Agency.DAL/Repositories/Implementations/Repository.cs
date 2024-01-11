using Agency.Core.Entities.Base;
using Agency.DAL.Context;
using Agency.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repositories.Implementations
{
	public  class Repository<T> : IRepository<T> where T : BaseEntity, new()
	{

		private readonly AppDbContext _context;
		private readonly DbSet<T> _table;
		public Repository(AppDbContext context)
		{
			_context = context;
			_table = _context.Set<T>();
		}
		//public DbSet<T> Table = _context.Set<T>();

		
		public async Task Create(T entity)
		{
			await _table.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_table.Remove(entity);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _table.ToListAsync();
		}

        public async  Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task SaveChanges()
		{
			await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			_table.Update(entity);
		}
	}
}
