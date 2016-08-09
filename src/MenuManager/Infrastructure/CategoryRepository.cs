using MenuManager.Data;
using MenuManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuManager.Infrastructure
{
    public class CategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IQueryable<Category> GetCategory(string name)
        {
            return
                from c in _db.Categories
                where c.Name == name
                select c;
        }

        public IQueryable<Category> GetCategories()
        {
            return
                from c in _db.Categories
                select c;
        }
    }
}
