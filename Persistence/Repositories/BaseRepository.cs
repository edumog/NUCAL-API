using Microsoft.EntityFrameworkCore;
using NUCAL.Application.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUCAL.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext dbContext { get; set; }

        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("Repository null");
        }

        public async Task<T> Add(T entity)
        {
            var entityCreated = await dbContext.Set<T>().AddAsync(entity);
            return entityCreated.Entity;
        }

        public void Delete(T entity) => dbContext.Entry(entity).State = EntityState.Deleted;

        public async Task<List<T>> GetAllEntities() => await dbContext.Set<T>().ToListAsync();

        public async Task<T> GetEntityById(string id) => await dbContext.Set<T>().FindAsync(id);

        public void update(T entity) => dbContext.Entry(entity).State = EntityState.Modified;
    }
}
