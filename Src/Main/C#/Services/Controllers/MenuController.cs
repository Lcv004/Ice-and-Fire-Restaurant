using IFR.Entity;
using IFR.Services.Repositories;
using System.Collections.Generic;

namespace IFR.Services.Controllers
{
    public class MenuController
    {
        MenuRepository _menuRepository;

        public MenuController(MenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        
        public void Add(Menu entity)
        {
            _menuRepository.Add(entity);
        }
        public void Remove(long key)
        {
            _menuRepository.Remove(key);
        }
        public Menu Get(long key)
        {
            return _menuRepository.Get(key);
        }
        public IEnumerable<Menu> GetAll()
        {
            return _menuRepository.GetAll();
        }
    }
}
