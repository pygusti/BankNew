using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using UnitOfWork.Interfaces;
using ViewModels.ViewModel;
////this controller is made to understand unit of work 
///Here we are using unit of work save changes 
///we are not saving any changes or making any tranctions in controller instead we are calling complete method of 
///unit of work to save changes 
///note :this is used to make single transation to databse instead of mutliple transactions.
namespace Bank_Updated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("Balance")]
        public int Balance(UsersViewModel customer)
        {
            return _unitOfWork.bankRepository.GetBalance(customer);
        }
        [HttpPost]
        [Route("withdraw")]
        public int withdraw(string withdrawamt,UsersViewModel customer)
        {
            int withdrawamount = Int16.Parse(withdrawamt);
            int balance=_unitOfWork.bankRepository.GetBalance(customer);
            if (withdrawamount > 0 && balance >= withdrawamount)
            {
                balance = balance - withdrawamount;
                _unitOfWork.bankRepository.Accountdedectamount(withdrawamount,customer);
                _unitOfWork.Complete();
                return withdrawamount;
            }
            return 0;
        }
        [HttpPost]
        [Route("addmoney")]
        public int addMoney(string addamount, UsersViewModel customer)
        {
            int limit = 1000;
            int Additionamount = Int16.Parse(addamount);
            int balance = _unitOfWork.bankRepository.GetBalance(customer);
            if (Additionamount > 0 && Additionamount <= limit)
            {
                balance = balance + Additionamount;
                _unitOfWork.bankRepository.AccountAddamount(Additionamount, customer);
                _unitOfWork.Complete();
                return Additionamount;
            }
            return 0;
        }

        [HttpGet]

        public IActionResult GetCustomerTransactions([FromQuery] int count)
        {
            try
            {
                var CustomerBalance = _unitOfWork.customerRepository.CustomerTransaction(count);
                _unitOfWork.Complete();
                return Ok(CustomerBalance);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
            
        }
        [HttpPost]

        public IActionResult InsertTransactions(UserModel user)
        {
            try
            {
                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }


    }
}
