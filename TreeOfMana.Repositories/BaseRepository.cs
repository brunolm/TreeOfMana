using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TreeOfMana.Dependencies;

namespace TreeOfMana.Repositories
{
    [Export(typeof(IRepository))]
    public class BaseRepository : IRepository
    {
        protected IApplicationContext context;

        [ImportingConstructor]
        public BaseRepository(IApplicationContext context)
        {
            this.context = context;
        }

        public void Add<T>(T item)
            where T: class
        {
            context.Set<T>().Add(item);
        }

        public void Remove<T>(T item)
            where T: class
        {
            context.Set<T>().Remove(item);
        }

        public T Get<T>(Func<T, bool> predicate)
            where T: class
        {
            return context.Set<T>().FirstOrDefault(predicate);
        }

        public IQueryable<T> Get<T>()
            where T : class
        {
            return context.Set<T>().AsQueryable();
        }
    }
}
