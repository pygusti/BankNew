using Entities.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
