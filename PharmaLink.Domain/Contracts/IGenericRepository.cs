using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PharmaLink.Domain.Common;

namespace PharmaLink.Domain.Contracts
{
    public interface IGenericRepository<T,TKey> where T : BaseEntity<TKey>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        //Task<IReadOnlyList<T>> GetAllWithSpecificationAsync(ISpecification<T, TKey> specification);
        Task<T?> GetByIdAsync(TKey id);
        //Task<T?> GetByIdWithSpecificationAsync(ISpecification<T, TKey> specification);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        //Task<int> CountAsync(ISpecification<T, TKey> specification);
    }
}
