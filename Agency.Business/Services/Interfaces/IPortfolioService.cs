using Agency.Business.ViewModels.PortfolioVM;
using Agency.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
	public interface IPortfolioService
	{

		Task<IEnumerable<Portfolio>> GetAllAsync();
		Task<Portfolio> GetById(int id);
		Task<Portfolio> Create(CreatePortfolioVM portfoliovm , string path );
		Task<Portfolio> Update(UpdatePortfolioVM portfoliovm, string path);
		Task<Portfolio> Delete(int Id);

	}
}
