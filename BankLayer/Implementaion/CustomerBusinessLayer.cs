using BankLayer.Interface;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
////this layer is business middle layer where we are injecting unit of work  
///by using  unit of work we are calling instances of repositories i.e (UserRepository)
namespace BankLayer.Implementaion
{
    
    public class CustomerBusinessLayer:ICustomerBusinessLogic
    {
        IUnitOfWork _unitOfWork;
        public CustomerBusinessLayer(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _unitOfWork.UserRepository.Get();
            
        }
        public async Task<UserModel> GetByID(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }
        public IActionResult Insert(UserModel user)
        {
            try
            {
                _unitOfWork.UserRepository.Insert(user);
                _unitOfWork.Complete();
                return new StatusCodeResult(statusCode: 200);
            }
            catch (Exception ex)
            {

                return new StatusCodeResult(statusCode: 500);
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.UserRepository.Delete(id);
            _unitOfWork.Complete();
        }
        public IActionResult Put(UserModel user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Complete();
            return new StatusCodeResult(statusCode: 200);
        }
    }
}
