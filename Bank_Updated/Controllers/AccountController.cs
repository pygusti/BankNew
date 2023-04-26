using AutoMapper;
using BankLayer.Interface;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels.ViewModel;

namespace Bank_Updated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountBusinessLogic _accountBusinessLogic;
        public AccountController(IAccountBusinessLogic accountBusinessLogic) 
        { 
        _accountBusinessLogic = accountBusinessLogic;
        }

        [HttpGet]
        public async Task<IEnumerable<UsersViewModel>> AccountsGet()
        {
            return await _accountBusinessLogic.AccountsGet();
        }

        [HttpGet("{id}")]
        public async Task<UsernewModel> AccountsGetByID(int id)
        {
              return await _accountBusinessLogic.AccountsGetByID(id);
        }

        [HttpPost]
        public IActionResult AccountInsert(UsersViewModel user)
        {
            return _accountBusinessLogic.AccountInsert(user);
        }

        [HttpDelete("{id}")]
        public void AccountDelete(int id)
        {
            _accountBusinessLogic.AccountDelete(id);
        }
    }
}
