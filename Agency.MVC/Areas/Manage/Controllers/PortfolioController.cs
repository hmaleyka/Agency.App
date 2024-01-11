using Agency.Business.Helpers;
using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.PortfolioVM;
using Microsoft.AspNetCore.Mvc;

namespace Agency.MVC.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class PortfolioController : Controller
	{
		private readonly IPortfolioService _service;
		private readonly IWebHostEnvironment _env;

		public PortfolioController(IPortfolioService service, IWebHostEnvironment env)
		{
			_service = service;
			_env = env;
		}

		public async Task<IActionResult> Index()
		{
		  var portfolios = await _service.GetAllAsync();
			return View(portfolios);
		}

		public async Task<IActionResult> Create ()
		{
			return View ();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreatePortfolioVM portfolioVM)
		{
			
			string path =  portfolioVM.Image.Upload(_env.WebRootPath, @"\Upload\Picture\");

			_service.Create(portfolioVM, path);
			return RedirectToAction("Index");
		}
        public async Task<IActionResult> Update()
        {
            return View();
        } 
		[HttpPost]
        public async Task<IActionResult> Update (UpdatePortfolioVM portfolioVM)
		{
			string path = portfolioVM.Image.Upload(_env.WebRootPath, @"\Upload\Picture\");
			await _service.Update(portfolioVM, path);
            return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete ( int id)
		{
			await _service.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
