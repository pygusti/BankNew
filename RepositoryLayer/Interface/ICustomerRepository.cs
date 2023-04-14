using Entities.Models;
using RepositoryLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface ICustomerRepository : IRepository<UserModel>
    {
        IEnumerable<UserModel> CustomerTransaction(int count);
    }
}
