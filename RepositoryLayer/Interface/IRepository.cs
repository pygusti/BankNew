using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IRepository<T> where T: class
    {
       public Task<IEnumerable<T>> Get();
       public Task<T> GetById(int id); 
       public void Insert(T entity);
       public  void Update(T entity);
       public void Delete(int id);
       
    }
}
