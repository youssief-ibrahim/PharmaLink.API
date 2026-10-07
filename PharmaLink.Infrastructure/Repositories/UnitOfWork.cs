using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;
using PharmaLink.Domain.Contracts;
using PharmaLink.Infrastructure.Data.DbContext;

namespace PharmaLink.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PharmaDbContext dbContext;
        private readonly Dictionary<Type, object> _repositories = [];

        public UnitOfWork(PharmaDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IGenericRepository<T, TKey> GetRepository<T, TKey>() where T : BaseEntity<TKey>
        {
            var type = typeof(T);
            if (_repositories.TryGetValue(type, out object? repository))
            {
                return (IGenericRepository<T, TKey>)repository!;
            }
            var newRepository = new GenericRepository<T, TKey>(dbContext);
            _repositories[type] = newRepository;
            return newRepository;
        }

        public async Task<int> SaveChangeAsync() => await dbContext.SaveChangesAsync();
    }
}
