using System.Collections.Generic;

namespace IFR.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(long key);
        TEntity Get(long key);
        IEnumerable<TEntity> GetAll();
    }
}
