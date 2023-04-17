using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLayer.Interface
{
    public interface ICustomerBusinessLogic
    {
        public  Task<IEnumerable<UserModel>> GetAll();
        public Task<UserModel> GetByID(int id);
        public IActionResult Insert(UserModel user);
        public void Delete(int id);
        public IActionResult Put(UserModel user);

    }
}
