using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id); 
        Task<List<T>> GetAll();
        Task Add(T obj);
        void Delete(T obj);
        void Update(T obj);
    }
}
