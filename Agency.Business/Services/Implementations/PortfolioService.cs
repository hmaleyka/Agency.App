using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.PortfolioVM;
using Agency.Core.Entities;
using Agency.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementations
{
	public class PortfolioService : IPortfolioService
	{
		public readonly IPortfolioRepository _repo;

		public PortfolioService(IPortfolioRepository repo)
		{
			_repo = repo;
		}
	
		public async Task<Portfolio> Create(CreatePortfolioVM portfoliovm , string path)
		{
			Portfolio portfolio = new Portfolio()
			{
				Title = portfoliovm.Title,
				Description = portfoliovm.Description,
				ImgUrl = path,
			};
			await _repo.Create(portfolio);
		    await _repo.SaveChanges();	
			return portfolio;
        }

		public async Task<Portfolio> Delete( int Id )
		{
			Portfolio portfolio = await _repo.GetByIdAsync(Id);
			_repo.Delete(portfolio);
			_repo.SaveChanges();
			return portfolio;
		}

		public async Task<IEnumerable<Portfolio>> GetAllAsync()
		{
			var portfolios = await _repo.GetAllAsync();
			return portfolios;
		}

        public async Task<Portfolio> GetById(int id)
        {
          var portfolio = await _repo.GetByIdAsync(id);
			return portfolio;
        }
		      
        public async Task<Portfolio> Update(UpdatePortfolioVM portfoliovm ,  string path )
		{

            Portfolio portfolios = await _repo.GetByIdAsync(portfoliovm.Id);
			portfolios.Title = portfoliovm.Title;
			portfolios.Description = portfoliovm.Description;
			portfolios.ImgUrl = path;
		     _repo.Update(portfolios);
			 await _repo.SaveChanges();
			return portfolios;
		}
	}
}
