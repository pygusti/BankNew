using Entities.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModel;

namespace RepositoryLayer.Implementation
{
    public class BankRepository :  Repository<UserModel>, IBankRepository
    {
        BankContext _context;
        public BankRepository(BankContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<UserModel> BankTransaction(int count)
        {
            return _context.userModels.OrderByDescending(d => d.Userid).Take(count).ToList();
        }
        public int GetBalance(UsersViewModel user)
        {
            IEnumerable<AccountModel> codeval=_context.Account.Where(d => d.UserId==user.UserId).ToList();
            return _context.Account.First(c => c.UserId == user.UserId).balance;
        }
        public int Accountdedectamount(int withdrawamount, UsersViewModel customer)
        {
            try
            {
                 (from p in _context.Account
                 where p.UserId == customer.UserId
                 select p)
                .ToList()
                .ForEach(x => x.balance = x.balance - withdrawamount);
                //_context.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
            return 1;
        }

        public int AccountAddamount(int addamount, UsersViewModel customer)
        {
            try
            {
                (from p in _context.Account
                 where p.UserId == customer.UserId
                 select p)
                .ToList()
                .ForEach(x => x.balance = x.balance + addamount);
            }
            catch 
            { 
                return 0;
            }
            return 1;
        }
    }
}
