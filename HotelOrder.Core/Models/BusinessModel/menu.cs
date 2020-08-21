using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.Models.BusinessModel
{
    public class menu
    {
        public int menu_id { get; set; }
        public string menu_name { get; set; }
        public string menu_header_name { get; set; }
        public string preference_name { get; set; }

        public int table_id { get; set; }
    }
}
