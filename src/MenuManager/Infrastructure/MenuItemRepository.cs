using MenuManager.Data;
using MenuManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuManager.Infrastructure
{
    public class MenuItemRepository
    {
        private ApplicationDbContext _db;
        public MenuItemRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public IQueryable<MenuItem> GetAllMenuItems()
        {
            return
                from mi in _db.MenuItems
                select mi;
        }

        public void AddMenuItem(MenuItem menuItem)
        {
            _db.MenuItems.Add(menuItem);
            _db.SaveChanges();
        }
    }

}