using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.AccountVM;
using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity.Core.Mapping;

namespace Agency.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        public IActionResult Register ()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM registervm)
        {            
           await _service.Register(registervm);
            return RedirectToAction("Index" , "Home");
        }
    }
}
