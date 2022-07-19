using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual void DeleteMany(IQueryable<T> entities)
        {
            //Belirtilen T tablosundan entities olarak belirtilen tüm dataları siler.
            if (entities.Count() > 0)
            {
                _set.RemoveRange(entities);
                _context.SaveChanges();
            }
        }

        public virtual void DeleteOne(T entity)
        {
            if (entity != null)
            {
                _set.Remove(entity);
                _context.SaveChanges();
            }
        }

        public virtual void DeleteOne(object entityKey)
        {
            if (entityKey != null)
            {
                DeleteOne(ReadOne(entityKey));
                _context.SaveChanges();
            }
        }

        public virtual bool Exists(object entityKey)
        {
            return entityKey != null && ReadOne(entityKey) != null;
        }

        public virtual bool Exists(T entity)
        {
            //Any: Belirtilen ifade sağlanıyorsa yani ilgili kayıt varsa true döner, aksi halde false döner. Kısacası bu kayıt bu tabloda var mı anlamına gelir.
            return entity != null && _set.Any(x => x.Equals(entity));
        }

        public virtual void InsertMany(IQueryable<T> entities)
        {
            if (entities.Count() > 0)
            {
                _set.AddRange(entities);
                _context.SaveChanges();
            }
        }

        public virtual void InsertOne(T entity)
        {
            if (entity != null)
            {
                _set.Add(entity);
                _context.SaveChanges();
            }
        }

        public virtual IQueryable<T> ReadMany(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return _set;
            }
            else
            {
                return _set.Where(expression);
            }
        }

        public virtual T ReadOne(object entityKey)
        {
            return _set.Find(entityKey);
        }

        public virtual void UpdateMany(IQueryable<T> entities)
        {
            if (entities.Count() > 0)
            {
                foreach (var entity in entities)
                {
                    _context.Entry(entity).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
        }

        public virtual void UpdateOne(object entityKey, T entity)
        {
            var orj_entity = ReadOne(entityKey);
            _context.Entry(orj_entity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
