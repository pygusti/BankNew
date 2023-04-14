using Entities.Models;
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
        private readonly BankContext _context;
        public UnitOfWork(BankContext context)
        {
            _context = context;
            bankRepository = new BankRepository(_context);
            customerRepository = new CustomerRepository(_context);
            UserRepository = new UserRepository(_context);
        }
        public IBankRepository bankRepository { get; private set; }
        public ICustomerRepository customerRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
