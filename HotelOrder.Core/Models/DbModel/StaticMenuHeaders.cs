using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class StaticMenuHeaders
    {
        public StaticMenuHeaders()
        {
            StaticMenus = new HashSet<StaticMenus>();
        }

        public int MenuHeaderId { get; set; }
        public string MenuHeaderName { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StaticMenus> StaticMenus { get; set; }
    }
}
