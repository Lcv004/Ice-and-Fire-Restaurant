using System.Collections.Generic;
using IFR.Entity;

namespace IFR.Services.Repositories
{
    public class InventoryRepository : IRepository<long, Inventory>
    {
        Dictionary<long, Inventory> _inventoryDictionary;
        long _id;

        public InventoryRepository()
        {
             _inventoryDictionary = new Dictionary<long, Inventory>();
             _id = 0;
        }

        public void Add(Inventory entity)
        {
            _id ++;
            _inventoryDictionary.Add(_id, entity);
        }

        public void Remove(long key)
        {
            if (_inventoryDictionary.ContainsKey(key))
            {
                _inventoryDictionary.Remove(key);
            }
        }

        public Inventory Get(long key)
        {
            return _inventoryDictionary[key];
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _inventoryDictionary.Values;
        }
    }
}
