using ApplicantTracker.InfraStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ApplicantTracker.Data.AppTrackEntities;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Objects;

namespace ApplicantTracker.InfraStructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new apptrackEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToList<T>();
            }
            return list;
        }

        public async Task<IList<T>> GetAllAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            dynamic list = null;
            using (var context = new apptrackEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .ToListAsync<T>();
            }
            return await list;
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            using (var context = new apptrackEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery
                    .AsNoTracking()
                    .Where(where)
                    .ToList<T>();
            }
            return list;
        }


        public Task<IList<T>> GetListAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {

            throw new NotImplementedException();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;
            using (var context = new apptrackEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                item = dbQuery
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(where); //Apply where clause
            }
            return item;
        }


        public virtual Task<T> GetSingleAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            return Task.FromResult(GetSingle(where, navigationProperties));


        }

        public void Add(params T[] items)
        {
            using (var context = new apptrackEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
        }
        public virtual async Task AddAsync(params T[] items)
        {
            using (var context = new apptrackEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Added;
                }
                await context.SaveChangesAsync();
            }
        }
        public async Task<T> AddSingleAsync(T item)
        {
            using (var context = new apptrackEntities())
            {
                context.Set<T>().Add(item);
                await context.SaveChangesAsync();
                return item;
            }
        }

        public void Update(params T[] items)
        {
            using (var context = new apptrackEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                context.SaveChanges();
            }
        }
        public virtual async Task UpdateAsync(params T[] items)
        {
            using (var context = new apptrackEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                await context.SaveChangesAsync();
            }
        }

        public void Remove(params T[] items)
        {
            using (var context = new apptrackEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                context.SaveChanges();
            }
        }
        public virtual async Task RemoveAsync(params T[] items)
        {
            try
            {

                using (var context = new apptrackEntities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (DbEntityValidationException e)
            {
            }
        }

        public virtual async Task<IEnumerable<SearchApplicant_Result>> SearchApplicantAsync(string searchText, string status, string company, string experience, string createdBy, string salary, string location, string industry, string days, int? startRecord, int? pageLimit, int totalRecord)
        {
            dynamic result = null;
            try
            {
                ObjectParameter Output = new ObjectParameter("TotalRecord", typeof(Int32));
                using (var context = new apptrackEntities())
                {
                    await Task.Run(() =>
                    {
                        result = context.SearchApplicant(searchText, status, company, experience, createdBy, salary, location, industry, days, startRecord, pageLimit, Output).ToList();
                    });

                    totalRecord = Convert.ToInt32(Output.Value);
                }
                return result;

            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
