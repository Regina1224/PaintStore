using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;


namespace PaintStore.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // mock data
        private static List<Order> _orders = new List<Order>
        {
            new Order(1, 1, 261.25m)
            {
                PaintProducts = new List<PaintProduct>
                {
                    new PaintProduct(1, "White Primer", 50m, "Base coat paint"),
                    new PaintProduct(2, "Red Gloss", 80m, "High gloss paint")
                }
            },
            new Order(2, 1, 83.60m)
            {
                PaintProducts = new List<PaintProduct>
                {
                    new PaintProduct(2, "Red Gloss", 80m, "High gloss paint")
                }
            },
            new Order(3, 2, 125.40m)
            {
                PaintProducts = new List<PaintProduct>
                {
                    new PaintProduct(3, "Gray Matte", 120m, "Matte finish paint")
                }
            }
        };

        // GET api/order
        [HttpGet]
        public IActionResult GetAllOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = _orders.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(result);
        }

        // GET api/order/pricerange?min=50&max=200
        [HttpDelete("pricerange")]
        public IActionResult GetOrdersByPriceRange([FromQuery] decimal min, [FromQuery
        ] decimal max)
        {
            var result = _orders.Where(o=>o.TotalPrice >= min & o.TotalPrice <= max).ToList();
            return Ok(result);
            
        }

        // GET api/order/bypaint/{paintId}
        [HttpGet("bypaint/{paintId}")]
        public IActionResult GetOrdersByPaintId(int paintId)
        {
            var result = _orders.Where(o=>o.PaintProducts.Any(p=>p.Id == paintId)).ToList();
            return Ok(result);
        }

        // GET api/order/byuser/{userId}
        [HttpGet("byuser/{userId}")]
        public IActionResult GetOrdersByUserId (int userId)
        {
            var result = _orders.Where(o=>o.UserId == userId).ToList();
            return Ok(result);
        }

        // GET api/order/lastmonth
        [HttpGet("lastmonth")]
        public IActionResult GetLastMonthOrders()
        {
            var lastMonth = DateTime.UtcNow.AddMonths(-1);
            var result = _orders.Where(o=>o.CreatedDate >= lastMonth).ToList();
            return Ok(result);
        }

        // GET api/order/bydate?date=2026-06-27
        [HttpGet("bydate")]
        public IActionResult GetOrdersByDate([FromQuery] DateTime date)
        {
            var result = _orders.Where(o=>o.CreatedDate == date.Date).ToList();
            return Ok(result);
        }
        
    }
}
