using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class StaticMenus
    {
        public StaticMenus()
        {
            Orders = new HashSet<Orders>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public decimal? Price { get; set; }
        public int? PreferenceId { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }
        public int? MenuHeaderId { get; set; }

        public virtual StaticMenuHeaders MenuHeader { get; set; }
        public virtual StaticPreferences Preference { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
