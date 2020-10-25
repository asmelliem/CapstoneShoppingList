using System;
using System.Collections.Generic;
using System.Dynamic;
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

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var orderItem = await GetOrderItem();
            return View(orderItem);
        }

        [HttpPost]
        public async Task<IActionResult> Products(int quantity, int orderProduct, int? orderId)
        {          

            if (!orderId.HasValue)
            {
                var orders = await this._context.Orders.MaxAsync(o => o.OrderId);
                orderId = orders + 1;                
            }
            var orderTableId = await this._context.Orders.MaxAsync(o => o.Id);
            await _context.Orders.AddAsync(new Orders() { OrderId = orderId, ProductId = orderProduct, Quantity = quantity, Id = orderTableId + 1 });
            await _context.SaveChangesAsync();

            var orderItem = await GetOrderItem();
            orderItem.Orderid = orderId;
            return View(orderItem);
        }

        private async Task<OrderItem> GetOrderItem()
        {
            var products = await _context.Products.Select(p => new Products { Id = p.Id, Name = p.Name, Price = p.Price }).ToListAsync();
            var orderItem = new OrderItem() { Products = products };
            return orderItem;
        }
    }
}
