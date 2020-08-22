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
    public class TrackingController : ControllerBase
    {
        private readonly ITrackingService _trackService;

        public TrackingController(ITrackingService trackService)
        {
            _trackService = trackService;
        }
        [HttpGet]
        [Route("order/{table_id}/{order_number}/tracking")]
        public List<menutracking> GetOrders(int table_id, string order_number)
        {
            List<menutracking> trackingLst = new List<menutracking>();
            trackingLst = _trackService.GetOrderTracking(table_id, order_number);
            return trackingLst;
        }

        [HttpPost]
        [Route("order/{table_id}/{order_number}/tracking")]
        public bool SaveOrderItems(int table_id, string order_number)
        {
            bool isSaved = false;
            order_number = order_number == "empty" ? "" : order_number;
            _trackService.SaveOrderTracking(table_id, order_number);
            return isSaved;
        }
    }
}
