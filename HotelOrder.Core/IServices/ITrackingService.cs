using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IServices
{
    public interface ITrackingService
    {
        List<menutracking> GetOrderTracking(int table_id, string order_number);
        void SaveOrderTracking(int table_id, string order_number);
    }
}
