using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IBaseRepo<T> where T :BaseModel
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(string id);
    }
}
