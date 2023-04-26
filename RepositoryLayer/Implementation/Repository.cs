using AutoMapper;
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
        private readonly BankContext _bankcontext;
        private DbSet<T> _banktableSet;
        public Repository(BankContext bankContext)
        {
            _bankcontext = bankContext;
            _banktableSet = _bankcontext.Set<T>();
        }
        public async Task<IEnumerable<T>> Get()
        {
            await _banktableSet.ToListAsync();
            return await _banktableSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _banktableSet.FindAsync(id);
        }

        public void Insert(T entity)
        {
            _banktableSet.Add(entity);
            _bankcontext.SaveChanges();       
        }
        public void Update(T entity)
        {
            _banktableSet.Attach(entity);
            _bankcontext.Entry(entity).State = EntityState.Modified;
            _bankcontext.SaveChanges();
        }
        public void Delete(int id)
        {
            T existing = _banktableSet.Find(id);
            if(existing == null)
            {
                throw new KeyNotFoundException();
            }
            _banktableSet.Remove(existing);
            _bankcontext.SaveChanges();
        }
        public void Save()
        {
            _bankcontext.SaveChanges();
        }


    }
}
