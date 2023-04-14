using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BankContext _context;
        private DbSet<T> _dbSet ;
        public Repository(BankContext bankContext)
        {
            _context = bankContext;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            T existing = _dbSet.Find(id);
            if(existing == null)
            {
                throw new KeyNotFoundException();
            }
            _dbSet.Remove(existing);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }


    }
}
