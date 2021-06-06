using System.Collections.Generic;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class MenuRepository : IRepository<long, Menu>
    {
        Dictionary<long, Menu> _menuDictionary;
        long _id;

        private MenuRepository()
        {
             _menuDictionary = new Dictionary<long, Menu>();
             _id = 0;
        }

        public void Add(Menu entity)
        {
            _id ++;
            _menuDictionary.Add(_id, entity);
        }

        public void Remove(long key)
        {
            if (_menuDictionary.ContainsKey(key))
            {
                _menuDictionary.Remove(key);
            }
        }

        public Menu Get(long key)
        {
            return _menuDictionary[key];
        }

        public IEnumerable<Menu> GetAll()
        {
            return _menuDictionary.Values;
        }
    }
}
