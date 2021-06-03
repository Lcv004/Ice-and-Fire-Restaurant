using System.Collections.Generic;

namespace IFR.Services.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Remove(TEntity entity);
        TEntity Get(long id);
        IEnumerable<TEntity> GetAll();
    }
}
