using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeOfMana.Dependencies
{
    public interface IRepository
    {
        void Add<T>(T item) where T : class;

        void Remove<T>(T item) where T : class;

        T Get<T>(Func<T, bool> predicate) where T : class;

        IQueryable<T> Get<T>() where T : class;
    }
}
