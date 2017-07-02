using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicantTracker.InfraStructure.Interfaces
{
    public interface IRepository<T> where T:class
    {
        //Normal Operations
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);

        //Async operations
        Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetListAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<T> GetSingleAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        Task AddAsync(params T[] items);
        Task UpdateAsync(params T[] items);
        Task RemoveAsync(params T[] items);
        Task<T> AddSingleAsync(T item);

    }
}
