using System;
using System.Collections.Generic;

namespace HotelOrder.Models
{
    public partial class StaticPreferences
    {
        public StaticPreferences()
        {
            StaticMenus = new HashSet<StaticMenus>();
        }

        public int PreferenceId { get; set; }
        public string PreferenceName { get; set; }
        public DateTime? CreatedTimeStamp { get; set; }
        public DateTime? UpdatedTimeStamp { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<StaticMenus> StaticMenus { get; set; }
    }
}
