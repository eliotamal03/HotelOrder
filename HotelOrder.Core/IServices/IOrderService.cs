using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IServices
{
    public interface IOrderService
    {
        void SaveOrderItems(string order_number,List<menucart> orderIdLst);
        List<menucart> GetOrderItems(int table_id, string order_number);
    }
}
