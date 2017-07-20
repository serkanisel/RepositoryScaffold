using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace A.Blog.Data.Repository
{
    public class BlogRepository : IRepository
    {
        private NORTHWNDEntities _context;

        public BlogRepository()
        {
            _context = new NORTHWNDEntities();
        }
        public IQueryable<T> All<T>() where T : class
        {
            return _context.Set<T>();
        }

        public IQueryable<T> AllIncluding<T>(params Expression<Func<T, object>>[] include) where T : class
        {
            IQueryable<T> retVal = _context.Set<T>();

            foreach (var item in include)
            {
                retVal = retVal.Include(item);
            }

            return retVal;
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }
    }
}