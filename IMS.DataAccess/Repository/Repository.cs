using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includProp);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includProp);
                }
            }

            return query.FirstOrDefault();
        }


        public bool Remove(Guid id)
        {
            try
            {
                T entity = dbSet.Find(id);
                Remove(entity);

                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                dbSet.Remove(entity);
                return true ;

            }catch (Exception ex)
            {
                return false ;
            }
        }

        public bool RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                dbSet.RemoveRange(entity);
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
    }
    
}
