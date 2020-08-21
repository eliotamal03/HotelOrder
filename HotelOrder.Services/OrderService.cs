using HotelOrder.Core.IRepositories;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMenuRepository _menuRepo;
        public OrderService(IOrderRepository orderRepo, IMenuRepository menuRepo)
        {
            _orderRepo = orderRepo;
            _menuRepo = menuRepo;

        }

        public List<menucart> GetOrderItems(int table_id, string order_number)
        {
            return _orderRepo.GetOrderItems(table_id, order_number);
        }

        public void SaveOrderItems(string order_number, List<menucart> menucartLst)
        {
            List<OrderTracking> lstorderTracking = new List<OrderTracking>();
            List<menucart> orderIdLst = _menuRepo.SaveMenuItems(menucartLst, order_number);
            foreach (var items in orderIdLst)
            {
                OrderTracking track = new OrderTracking();
                track.OrderId = items.order_id;
                track.OrderTrackingId = items.order_tracking_id;
                track.OrderStatusId = items.order_status_id;
                lstorderTracking.Add(track);
            }
            _orderRepo.SaveOrderItems(lstorderTracking);
        }
    }
}
