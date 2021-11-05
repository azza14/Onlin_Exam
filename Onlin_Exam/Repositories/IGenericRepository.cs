using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Online_Exam.Repositories
{
  public  interface IGenericRepository<T> where T :class 
    {
        List<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] including);
        T GetById( int id);
        void Insert( T model);
        T InsertWithReturn(T model);
        List<T> InsertWithRange(List<T> models);
        void Update( T model);
        void Delete( int id);
        void Save( );
        bool IsExists(Expression<Func<T, bool>> expression);
        T GetOne(Expression<Func<T, bool>> expression);
        IList<T> GetList(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IList<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}
