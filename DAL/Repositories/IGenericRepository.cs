using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IGenericRepository<T> where T : class
    {
        //Create:
        void InsertOne(T entity);
        void InsertMany(IQueryable<T> entities);

        //Read:
        T ReadOne(object entityKey);
        //Expression (ifade): Bu kısma bir lampda ifadesi (x=>x...) yazıldığında kabul edilecektir. 
        IQueryable<T> ReadMany(Expression<Func<T, bool>> expression = null);
        bool Exists(object entityKey);
        bool Exists(T entity);

        //Update:
        void UpdateOne(object entityKey, T entity);
        void UpdateMany(IQueryable<T> entities);

        //Delete:
        void DeleteOne(T entity);
        void DeleteOne(object entityKey);
        void DeleteMany(IQueryable<T> entities);
    }
}
