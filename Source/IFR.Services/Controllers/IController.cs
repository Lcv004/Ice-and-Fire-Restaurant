using System.Collections.Generic;

namespace IFR.Services.Controllers
{
    public interface IController<TKey, TEntity>
    {
        void Add(TEntity entity);
        void Remove(TKey key);
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();
    }
}
