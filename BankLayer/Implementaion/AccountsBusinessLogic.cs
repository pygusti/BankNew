using AutoMapper;
using BankLayer.Interface;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using ViewModels.ViewModel;

namespace BankLayer.Implementaion
{
    public class AccountsBusinessLogic : IAccountBusinessLogic
    {
        IUnitOfWork _unitOfWork;

        public AccountsBusinessLogic(IUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<UsernewModel> AccountsGetByID(int id)
        {
            return await _unitOfWork.AccountsRepository.GetById(id);
        }
        public async Task<IEnumerable<UsersViewModel>> AccountsGet()
        {
            var mapper = AppMapper.config();
            IEnumerable<UsernewModel> Accounts= await _unitOfWork.AccountsRepository.Get();
            IEnumerable<UsersViewModel> AccountsDTO = mapper.Map<IEnumerable<UsernewModel>,IEnumerable<UsersViewModel>>(Accounts);
            return AccountsDTO;
        }
        public IActionResult AccountInsert(UsersViewModel user)
        {
            var mapper = AppMapper.config();
            UsernewModel AccountsDTO=mapper.Map<UsersViewModel, UsernewModel>(user);
            _unitOfWork.AccountsRepository.Insert(AccountsDTO);
            return new StatusCodeResult(statusCode:200);
        }

        public void AccountDelete(int id)
        {
            _unitOfWork.AccountsRepository.Delete(id);      
        }


    }
}
