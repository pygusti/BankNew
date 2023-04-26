using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
////This file represnts interface for unit of work where we are mentioning all methods or repositories required
namespace UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IBankRepository  bankRepository { get; }
        ICustomerRepository customerRepository { get; }

        IAccountsRepository AccountsRepository { get; }
        int Complete();
        
    }

}
