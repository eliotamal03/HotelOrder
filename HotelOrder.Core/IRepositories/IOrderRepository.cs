using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IRepositories
{
    public interface IOrderRepository
    {
        void SaveOrderItems(List<OrderTracking> orderIdLst);
        List<menucart> GetOrderItems(int table_id, string order_number);
    }
}
