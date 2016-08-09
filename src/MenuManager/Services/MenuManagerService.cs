using MenuManager.Infrastructure;
using MenuManager.Models;
using MenuManager.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuManager.Services
{
    public class MenuManagerService
    {
        private MenuItemRepository _menuItemRepo;
        private CategoryRepository _categoryRepo;
        public MenuManagerService(MenuItemRepository mir, CategoryRepository cr)
        {
            _categoryRepo = cr;
            _menuItemRepo = mir;

        }

        public IList<MenuItemDTO> GetAllMenuItems()
        {
            return (from mi in _menuItemRepo.GetAllMenuItems()
                    select new MenuItemDTO()
                    {
                        Name = mi.Name,
                        Price = mi.Price,
                        Description = mi.Description,
                        Calories = mi.Calories,
                        ImageUrl = mi.ImageUrl,
                        CategoryName = mi.Category.Name
                    }).ToList();
        }
        public void AddMenuItem(MenuItemDTO dto)
        {
            var dbMenuItem = new MenuItem()
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Calories = dto.Calories,
                ImageUrl = dto.ImageUrl,
                CategoryId = _categoryRepo.GetCategory(dto.CategoryName).First().Id
            };

            _menuItemRepo.AddMenuItem(dbMenuItem);
        }

        public IList<CategoryDTO> GetCategories()
        {
           
            return (from c in _categoryRepo.GetCategories()
                    select new CategoryDTO()
                    {
                        Name = c.Name
                    }).ToList();
        }
    }
}
