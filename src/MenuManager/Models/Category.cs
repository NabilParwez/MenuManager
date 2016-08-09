using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuManager.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<MenuItem> MenuItems { get; set; }

    }
}
