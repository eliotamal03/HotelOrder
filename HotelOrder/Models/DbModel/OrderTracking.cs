using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class OrderTracking
    {
        public int OrderTrackingId { get; set; }
        public int? OrderStatusId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Orders OrderNumberNavigation { get; set; }
        public virtual StaticOrdersStatus OrderStatus { get; set; }
    }
}
