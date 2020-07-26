using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderTracking = new HashSet<OrderTracking>();
        }

        public int OrderId { get; set; }
        public int? Quantity { get; set; }
        public int? DiningTableId { get; set; }
        public int? MenuId { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }
        public string OrderNumber { get; set; }

        public virtual StaticDiningTables DiningTable { get; set; }
        public virtual StaticMenus Menu { get; set; }
        public virtual ICollection<OrderTracking> OrderTracking { get; set; }
    }
}
