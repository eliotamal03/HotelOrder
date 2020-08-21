using HotelOrder.Core.IRepositories;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelOrder.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly HotelOrderDbContext _context;
        public OrderRepository(HotelOrderDbContext context)
        {
            _context = context;
        }
        public List<menucart> GetOrderItems(int table_id, string order_number)
        {
            List<menucart> menuLst = new List<menucart>();
            var dbLst = _context.Orders.Select(a => a).Where(a => a.DiningTable.DiningTableId.Equals(table_id)
            && a.OrderNumber.Equals(order_number)).ToList();
            foreach (var item in dbLst)
            {
                menucart menu = new menucart()
                {
                    dining_table_id = item.DiningTableId ?? 0,
                    menu_id = item.MenuId ?? 0,
                    quantity = item.Quantity ?? 0,
                    order_id = item.OrderId,
                    order_number = item.OrderNumber,

                };
                menuLst.Add(menu);
            }
            return menuLst;
        }

        public void SaveOrderItems(List<OrderTracking> orderIdLst)
        {
            foreach (var items in orderIdLst)
            {
                if (items.OrderTrackingId > 0)
                {
                    OrderTracking order = _context.OrderTracking.Where(a => a.OrderTrackingId.Equals(items.OrderTrackingId)).SingleOrDefault();                    
                    order.OrderId = items.OrderId;
                    order.OrderStatusId = items.OrderStatusId != 1 ? items.OrderStatusId : 1;
                    _context.SaveChanges();
                    _context.Entry<OrderTracking>(order).State = EntityState.Detached;
                }
                else
                {
                    OrderTracking order = new OrderTracking();
                    order.OrderId = items.OrderId;
                    order.OrderStatusId = items.OrderStatusId != 1 ? items.OrderStatusId : 1;
                    _context.OrderTracking.Add(order);
                    _context.SaveChanges();
                    _context.Entry<OrderTracking>(order).State = EntityState.Detached;
                }
               
            }
        }
    }
}
