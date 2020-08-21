using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.Models.BusinessModel
{
    public class menutracking
    {
        public int menu_id { get; set; }
        public string menu_name { get; set; }

        public string menu_preference { get; set; }

        public int quantity { get; set; }
        public int status_id { get; set; }

        public string status_name { get; set; }
    }
}
