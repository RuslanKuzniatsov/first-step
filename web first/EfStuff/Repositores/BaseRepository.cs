using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using web_first.EfStuff.DbModel;

namespace web_first.EfStuff.Repositores
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected WebContext _webContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(WebContext context)
        {
            _webContext = context;
            _dbSet = _webContext.Set<T>();
        }



        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Get(int id)
        {
            return _dbSet
                .FirstOrDefault(x => x.Id == id);
        }

        public void Save(T model)
        {
            _dbSet.Add(model);
            _webContext.SaveChanges();
        }

        public void Remove(T model)
        {
            _dbSet.Remove(model);
            _webContext.SaveChanges();
        }
    }
}
