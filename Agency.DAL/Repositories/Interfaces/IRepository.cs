using Agency.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.DAL.Repositories.Interfaces
{
	public interface IRepository<T> where T : BaseEntity , new ()
	{

		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync (int id);
		Task Create(T entity);
		void Update(T entity);
		void Delete(T entity);
		Task SaveChanges();

	}
}
