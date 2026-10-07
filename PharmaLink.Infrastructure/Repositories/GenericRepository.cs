using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Contracts;
using PharmaLink.Infrastructure.Data.DbContext;

namespace PharmaLink.Infrastructure.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly PharmaDbContext dbContext;
        public GenericRepository(PharmaDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync() => await dbContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T?> GetByIdAsync(TKey id) => await dbContext.Set<T>().FindAsync(id);
        public async Task AddAsync(T entity) => await dbContext.Set<T>().AddAsync(entity);
        public void Update(T entity) => dbContext.Set<T>().Update(entity);
        public void Delete(T entity) => dbContext.Set<T>().Remove(entity);
    }
}
