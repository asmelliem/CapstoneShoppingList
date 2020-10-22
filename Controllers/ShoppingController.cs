using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapstoneShoppingList.Context;
using CapstoneShoppingList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CapstoneShoppingList.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly ShoppingListContext _context;

        public ShoppingController(ShoppingListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Products()
        {
            var products = await _context.Products.Select(p => new Products { Id = p.Id, Name = p.Name, Price = p.Price }).ToListAsync();
            return View(products);
        }
    }
}
