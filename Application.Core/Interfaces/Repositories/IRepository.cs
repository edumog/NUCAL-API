using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Application.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Add(T entity);
        void Delete(T entity);
        Task<List<T>> GetAllEntities();
        Task<T> GetEntityById(string id);
        void update(T entity);
    }
}
