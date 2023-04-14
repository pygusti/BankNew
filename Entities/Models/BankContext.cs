using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountModel>()
                .HasOne(b => b.User)
                .WithMany(ba => ba.Accounts)
                .HasForeignKey(b=>b.UserId);

        }
        public DbSet<UserModel> userModels { get; set; }
        public DbSet<UsernewModel> User { get; set; }
        public DbSet<AccountModel> Account { get; set; }

    }
}
