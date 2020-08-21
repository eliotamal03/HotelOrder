using HotelOrder.Core.IRepositories;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelOrder.Repositories
{
    public class TrackingRepository : ITrackingRepository
    {
        private readonly HotelOrderDbContext _context;
        public TrackingRepository(HotelOrderDbContext context)
        {
            _context = context;
        }
        public List<menutracking> GetOrderTracking(int table_id, string order_number)
        {
            List<int> orderidLst = new List<int>();
            orderidLst = _context.Orders.Where(a => a.OrderNumber.Equals(order_number)
            && a.DiningTableId.Equals(table_id)).Select(a => a.OrderId).ToList();

            List<menutracking> menutrackLst = new List<menutracking>();

            if (orderidLst != null && orderidLst.Count > 0)
            {
                foreach (var item in orderidLst)
                {
                    var orderTrackingLst = from ot in _context.OrderTracking
                                           join ord in _context.Orders on ot.OrderId equals ord.OrderId
                                           where (ot.OrderId.Equals(item) && ord.OrderId.Equals(item))
                                           select new menutracking
                                           {
                                               menu_name = ord.OrderId.ToString(),
                                               quantity = ord.Quantity ?? 0,
                                               status_name = ot.OrderStatusId.ToString(),
                                               menu_preference = ord.MenuId.ToString()

                                           };
                    menutrackLst = orderTrackingLst.ToList();
                }
            }
            return menutrackLst;
        }

        public void SaveOrderTracking(int table_id, string order_number)
        {
            //List<OrderTracking> orderTrackingLst = _context.OrderTracking.Select(a => a).
            //    Where(a=>a.OrderNumber.Equals(order_number)).ToList();

            //foreach(var items in orderTrackingLst)
            //{
            //    items.OrderStatusId = 4;
            //}
            //_context.SaveChanges();
        }
    }
}
