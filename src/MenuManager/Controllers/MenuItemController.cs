using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MenuManager.Infrastructure;
using MenuManager.Services;
using Microsoft.AspNetCore.Authorization;
using MenuManager.Services.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuManager.Controllers
{
    [Route("api/[controller]")]
    public class MenuItemController : Controller
    {
        private MenuManagerService _menuManagerService;
        public MenuItemController(MenuManagerService mis)
        {
            _menuManagerService = mis;
        }

        [HttpGet]
        public IList<MenuItemDTO> Get()
        {
            return _menuManagerService.GetAllMenuItems();
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult PostMenuItem([FromBody]MenuItemDTO menuItem)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _menuManagerService.AddMenuItem(menuItem);

            return Ok();
        }

        [HttpGet("categories")]
        public IList<CategoryDTO> GetCategories()
        {
            return _menuManagerService.GetCategories(); 
        }
    }
    
}