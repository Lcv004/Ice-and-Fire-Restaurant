using System.Collections.Generic;

namespace IFR.Services.Repositories
{
    public interface IRepository<TKey, TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TKey key);
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
    }
}
