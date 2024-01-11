using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.AccountVM;
using Agency.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Agency.Business.Helpers;

namespace Agency.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {

        private readonly UserManager<AppUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly SignInManager<AppUser> _signinmanager;
        public AccountService(UserManager<AppUser> usermanager, RoleManager<IdentityRole> rolemanager )
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        public Task Login(LoginVM loginvm)
        {
            throw new NotImplementedException();
        }

        public async void LogOut()
        {
           await _signinmanager.SignOutAsync();
        }

        public async Task Register(RegisterVM registervm)
        {
            AppUser user = new AppUser()
            {
                Name = registervm.Name,
                Email = registervm.Email,
                Surname = registervm.Surname,
                UserName = registervm.Username
            };

            var result = await _usermanager.CreateAsync(user, registervm.Password);

            if (result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    return;
                }
            }

            //await _signinmanager.SignInAsync(user, false);
            //await _usermanager.AddToRoleAsync(user, UserRole.Admin.ToString()); 
                       
        }
    }
}
