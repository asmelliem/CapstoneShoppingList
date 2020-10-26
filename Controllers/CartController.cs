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
    public class CartController : Controller
    {
        private readonly ShoppingListContext _context;

        public CartController(ShoppingListContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            return View(new Cart());
        }

        [HttpPost]
        public async Task<IActionResult> Cart(int orderId)
        {
            var order = await _context.Orders.Where(o => o.OrderId == orderId).ToListAsync();
            var cart = new Cart();
            var productIds = order.Select(p => p.ProductId);
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();
            foreach (var orderItem in products)
            {
                var quantity = order.First(o => o.ProductId == orderItem.Id).Quantity;
                cart.Total += orderItem.Price * quantity ?? 0;
                cart.Products.Add(MapProduct(orderItem, quantity));
            }    
            return View(cart);
        }

        private OrderProduct MapProduct(Products orderItem, int? quantity)
        {
            var orderProduct = new OrderProduct();
            orderProduct.Name = orderItem.Name;
            orderProduct.Price = orderItem.Price ?? 0;
            orderProduct.Quantity = quantity ?? 0;
            return orderProduct;
        }
    }
}
