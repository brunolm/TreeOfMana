using System;
using System.Data.Entity;

namespace TreeOfMana.Dependencies
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        bool DeleteDatabase();
    }
}
