using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModel;

namespace BankLayer.Interface
{
    public interface IAccountBusinessLogic
    {
        public Task<IEnumerable<UsersViewModel>> AccountsGet();
        public  Task<UsernewModel> AccountsGetByID(int id);
        public IActionResult AccountInsert(UsersViewModel user);
        public void AccountDelete(int id);

    }
}
