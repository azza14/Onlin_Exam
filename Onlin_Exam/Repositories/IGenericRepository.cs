using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onlin_Exam.Repositories
{
  public  interface IGenericRepository<T> where T :class 
    {
        public List<T> GetAll();
        public T GetById( int id);
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public IList<T> GetByCondition(Expression<Func<T, bool>> expression);        
        public void Insert( T model);
        public void Update( T model);
        public void Delete( int id);
        public void Save( );

    }
}
