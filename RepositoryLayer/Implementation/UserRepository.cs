using Entities.Models;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
    public class UserRepository : Repository<UserModel>,IUserRepository
    {
        public UserRepository(BankContext bankContext) : base(bankContext) { 
        
        }
    }
}
