using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.Models.BusinessModel
{
    public class menucart
    {
        public int menu_id { get; set; }
        public string menu_name { get; set; }

        public string menu_preference { get; set; }

        public string order_number { get; set; }

        public int order_id { get; set; }

        public int order_tracking_id { get; set; }

        public int order_status_id { get; set; }

        public int quantity { get; set; }

        public int dining_table_id { get; set; }
    }
}
