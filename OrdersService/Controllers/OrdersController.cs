using Microsoft.AspNetCore.Mvc;
using OrdersService.Models;

namespace OrdersService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> Orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.Now,
                CustomerName = "John Doe",
                Products = new List<OrderProduct>
                {
                    new OrderProduct { ProductId = 1, ProductName = "Laptop", Price = 1200 },
                    new OrderProduct { ProductId = 2, ProductName = "Mouse", Price = 25 }
                }
            }
        };

        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(Orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == id);
            return order != null ? Ok(order) : NotFound();
        }
    }
}
