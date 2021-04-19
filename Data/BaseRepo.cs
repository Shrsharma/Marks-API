using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseModel
    {
        private readonly AppContext _context;

        public BaseRepo(AppContext context)
        {
            this._context = context;
        }
        public async Task Delete(string id)
        {
            var studentModel = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(studentModel);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(string id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

    }
}
