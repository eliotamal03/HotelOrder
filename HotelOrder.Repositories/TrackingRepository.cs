using HotelOrder.Core.IRepositories;
using HotelOrder.Core.Models;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using Microsoft.EntityFrameworkCore;
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
                    helper help = new helper();
                    var orderTrackingLst = from ot in _context.OrderTracking
                                           join ord in _context.Orders on ot.OrderId equals ord.OrderId
                                           where (ot.OrderId.Equals(item) && ord.OrderId.Equals(item))
                                           select new menutracking
                                           {

                                               menu_name = help.GetMenuName(ord.MenuId ?? 0),
                                               quantity = ord.Quantity ?? 0,
                                               status_name = help.GetStatusName(ot.OrderStatusId ?? 0),
                                               menu_preference = help.GetPreferenceName(ord.MenuId ?? 0)

                                           };
                    menutrackLst.AddRange(orderTrackingLst.ToList());
                }
            }
            return menutrackLst;
        }

        public void SaveOrderTracking(int table_id, string order_number)
        {
            List<int> orderidLst = new List<int>();
            orderidLst = _context.Orders.Where(a => a.OrderNumber.Equals(order_number)
            && a.DiningTableId.Equals(table_id)).Select(a => a.OrderId).ToList();

            List<menutracking> menutrackLst = new List<menutracking>();

            if (orderidLst != null && orderidLst.Count > 0)
            {
                foreach (var item in orderidLst)
                {
                    OrderTracking track = _context.OrderTracking.Where(a => a.OrderId.Equals(item)).Select(a => a).SingleOrDefault();
                    if (track != null)
                    {
                        track.OrderStatusId = 2;
                        _context.SaveChanges();
                        _context.Entry<OrderTracking>(track).State = EntityState.Detached;
                    }
                }
            }

        }


    }
}
