using System;
using System.Collections.Generic;

namespace ToDo.Repositories
{

    public interface IToDoRepository<T1,T2> where T1: class{
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetByID(T2 id);
        Task<T1> Insert(T1 entity);
        Task Delete(T2 id);
        Task Save();

    }
}