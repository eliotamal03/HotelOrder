using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelOrder.Controllers
{
    [Route("v1")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("order/{table_id}/{order_number}/items")]
        public List<menucart> GetOrders(int table_id, string order_number)
        {
            List<menucart> headers = new List<menucart>();
            headers = _orderService.GetOrderItems(table_id,order_number);
            return headers;
        }

        [HttpPost]
        [Route("order/{order_number}/items")]
        public bool SaveOrderItems(List<menucart> cartLst, string order_number)
        {
            bool isSaved = false;
            order_number = order_number == "empty" ? "" : order_number;
            _orderService.SaveOrderItems(order_number, cartLst);
            return isSaved;
        }
    }
}
