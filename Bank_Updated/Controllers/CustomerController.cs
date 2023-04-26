using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Entities.Models;
using RepositoryLayer.Interface;
using UnitOfWork.Interfaces;
using RepositoryLayer.Implementation;
using BankLayer.Implementaion;
using BankLayer.Interface;

namespace Bank_Updated.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBusinessLogic customerbusinessLogic;
        public CustomerController(ICustomerBusinessLogic businessLogic) 
        { 
            this.customerbusinessLogic = businessLogic;
        }
      
        // GET: api/Login
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await customerbusinessLogic.GetAll();
        }
     
        [HttpGet("{id}")]
        public async Task<UserModel> GetByID(int id)
        {
            return await customerbusinessLogic.GetByID(id);
        }
       
        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Insert(UserModel user)
        {
            return customerbusinessLogic.Insert(user);
        }

        // DELETE: api/Login/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerbusinessLogic?.Delete(id);
        }
       
        [HttpPut("{id}")]
        public IActionResult Put(UserModel user)
        {
           return customerbusinessLogic.Put(user);    
        }

    }
}
