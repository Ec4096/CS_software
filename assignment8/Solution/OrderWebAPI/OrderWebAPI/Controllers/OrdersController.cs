using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OrderWebAPI.Models;
using OrderWebAPI.Services;

namespace OrderWebAPI.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly OrderService orderService = new OrderService();

        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return orderService.QueryOrders(o => true);
        }

        [HttpGet]
        public IHttpActionResult GetOrder(int id)
        {
            var order = orderService.QueryOrders(o => o.OrderId == id).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult AddOrder(Order order)
        {
            try
            {
                orderService.AddOrder(order);
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(Order order)
        {
            try
            {
                orderService.UpdateOrder(order);
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            try
            {
                orderService.RemoveOrder(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
