using Microsoft.EntityFrameworkCore;
using Onlin_Exam.DBContext;
using Onlin_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onlin_Exam.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private OnlineDbContext _context;
        private DbSet<T> table = null;
        // private GenericRepository<T> repository;

        public GenericRepository(GenericRepository<T> repository)
        {
            _context = new OnlineDbContext();
            table = _context.Set<T>();
        }

        public GenericRepository(OnlineDbContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            table.Remove(item);
        }

        public List<T> GetAll()
        {
            return table.ToList();
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] including)
        {
            var query = table.AsQueryable();
            if (including != null)
            {
                foreach (var include in including)
                    query = query.Include(include);
            }
            return query;
        }


        public T GetById(int id)
        {
            return table.Find(id);
        }

        public void Insert(T model)
        {
            table.Add(model);
        }

        public T InsertWithReturn(T model)
        {
            table.Add(model);
            return model;
        }

        public List<T> InsertWithRange(List<T> models)
        {
            table.AddRange(models);
            return models;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T model)
        {
            table.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking();
        }

        public T GetOne(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).FirstOrDefault();
        }

        public IList<T> GetList(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).ToList();
        }

        public IList<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).ToList();
        }

       

        //search params   
        //public List<T> GetList<T>(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes) where T : class
        //{
        //    var query = _db.Set<T>().AsNoTracking();
        //    foreach (var include in includes)
        //        query = query.Include(include);
        //    return query.Where(where).ToList();
        //}
        //public List<T> GetList<T>(Expression<Func<T, bool>> where, params string[] includes) where T : class
        //{
        //    var query = _db.Set<T>().AsNoTracking();
        //    foreach (var include in includ
        //}
    }
}
