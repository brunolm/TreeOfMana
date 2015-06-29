using System.Data.Entity;

namespace TreeOfMana.Dependencies
{
    public interface IApplicationContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
