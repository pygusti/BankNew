﻿using Entities.Models;
using RepositoryLayer.Implementation;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Interfaces
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly BankContext _bankcontext;
        public UnitOfWork(BankContext context)
        {
            _bankcontext = context;
            bankRepository = new BankRepository(_bankcontext);
            customerRepository = new CustomerRepository(_bankcontext);
            UserRepository = new UserRepository(_bankcontext);
        }
        public IBankRepository bankRepository { get; private set; }
        public ICustomerRepository customerRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public int Complete()
        {
            return _bankcontext.SaveChanges();
        }
        public void Dispose()
        {
            _bankcontext.Dispose();
        }
    }
}
