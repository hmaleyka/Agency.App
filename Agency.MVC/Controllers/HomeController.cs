using Agency.Business.ViewModels;
using Agency.DAL.Context;
using Agency.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agency.MVC.Controllers
{
	public class HomeController : Controller
	{
		public readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{

			HomeVM homevm = new HomeVM()
			{
				portfolios = _context.portfolio.ToList(),
			};
			return View(homevm);
		}

		
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}