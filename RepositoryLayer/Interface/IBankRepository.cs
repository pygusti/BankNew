using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IBankRepository : IRepository<UserModel>
    {
       IEnumerable<UserModel> BankTransaction(int count);
    }
}
