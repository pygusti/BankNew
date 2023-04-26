using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModel;

namespace RepositoryLayer.Interface
{
    public interface IBankRepository : IRepository<UserModel>
    {
        IEnumerable<UserModel> BankTransaction(int count);
        int GetBalance(UsersViewModel user);
        int Accountdedectamount(int withdrawamount, UsersViewModel customer);
        int AccountAddamount(int withdrawamount, UsersViewModel customer);
    }
}
