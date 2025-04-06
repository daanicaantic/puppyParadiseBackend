using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccessLayer.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly PuppyParadiseContext _puppyParadiseContext;

        public Repository(PuppyParadiseContext puppyParadiseContext) 
        { 
            _puppyParadiseContext = puppyParadiseContext; 
        }

        public async Task<T> GetById(int id)
        {
            var obj = await _puppyParadiseContext.Set<T>().FindAsync(id);
            return obj;
        }
        public async Task<List<T>> GetAll()
        {
            return await _puppyParadiseContext.Set<T>().ToListAsync();
        }
        public async Task Add(T obj)
        {
            await this._puppyParadiseContext.Set<T>().AddAsync(obj);
        }
        public void Delete(T obj)
        {
            this._puppyParadiseContext.Set<T>().Remove(obj);
        }
        public void Update(T obj)
        {
            this._puppyParadiseContext.Set<T>().Update(obj);
        }
    }
}
