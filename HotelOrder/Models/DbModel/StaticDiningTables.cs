using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class StaticDiningTables
    {
        public StaticDiningTables()
        {
            Orders = new HashSet<Orders>();
        }

        public int DiningTableId { get; set; }
        public string DiningTableName { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
