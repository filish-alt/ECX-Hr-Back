
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.Models;
using ECX.HR.Domain;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECXHRDbContext _context;

        public GenericRepository()
        {
        }

        public GenericRepository(ECXHRDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

       

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        

        public async Task Update(T entity)
        {
           
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
        
    }
}
