using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class StaticOrdersStatus
    {
        public StaticOrdersStatus()
        {
            OrderTracking = new HashSet<OrderTracking>();
        }

        public int OrderStatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<OrderTracking> OrderTracking { get; set; }
    }
}
