using IFR.Entity;
using IFR.Services.Repositories;
using System.Collections.Generic;

namespace IFR.Services.Controllers
{
    public class InventoryController
    {
        InventoryRepository _inventoryRepository;

        public InventoryController(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        
        public void Add(Inventory entity)
        {
            _inventoryRepository.Add(entity);
        }
        public void Remove(long key)
        {
            _inventoryRepository.Remove(key);
        }
        public Inventory Get(long key)
        {
            return _inventoryRepository.Get(key);
        }
        public IEnumerable<Inventory> GetAll()
        {
            return _inventoryRepository.GetAll();
        }
    }
}
