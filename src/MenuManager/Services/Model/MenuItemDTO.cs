using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuManager.Services.Model
{
    public class MenuItemDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Calories { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
