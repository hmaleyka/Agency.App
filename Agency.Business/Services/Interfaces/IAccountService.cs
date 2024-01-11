using Agency.Business.ViewModels.AccountVM;
using Agency.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Interfaces
{
    public interface IAccountService
    {

        Task Register(RegisterVM registervm);
        Task Login (LoginVM loginvm);
        void LogOut ();
    }
}
