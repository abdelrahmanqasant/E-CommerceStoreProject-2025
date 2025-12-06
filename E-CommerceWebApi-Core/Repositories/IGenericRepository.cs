using E_CommerceWebApi_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
       
        Task<IReadOnlyList<T?>> ListAsync(ISpecification<T> spec);
        Task<T?> GetEntityWithSpecification(ISpecification<T> spec);
        Task<TResult?> GetEntityWithSpecification<TResult>(ISpecification<T, TResult> spec);
        Task<IReadOnlyList<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec);
        Task<T?> GetByIdAsync(int id);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        bool Exists(int id);
        Task<bool> SaveAllAsync();
        Task<int> CountAsync(ISpecification<T> spec);

    }
}
