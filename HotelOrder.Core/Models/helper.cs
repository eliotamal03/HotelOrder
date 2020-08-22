using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelOrder.Core.Models
{
    public class helper
    {
        public string GetPreferenceName(int id)
        {
            using (var _context = new HotelOrderDbContext())
            {
                string name = _context.StaticPreferences.Where(a => a.PreferenceId.Equals(id)).Select(a => a.PreferenceName).SingleOrDefault();
                return name;
            }
        }

        public string GetHeaderName(int id)
        {
            using (var _context = new HotelOrderDbContext())
            {
                string name = _context.StaticMenuHeaders.Where(a => a.MenuHeaderId.Equals(id)).Select(a => a.MenuHeaderName).SingleOrDefault();
                return name;
            }
        }

        public string GetStatusName(int id)
        {
            using (var _context = new HotelOrderDbContext())
            {
                string name = _context.StaticOrdersStatus.Where(a => a.OrderStatusId.Equals(id)).Select(a => a.StatusName).SingleOrDefault();
                return name;
            }
        }

        public string GetMenuName(int id)
        {
            using (var _context = new HotelOrderDbContext())
            {
                string name = _context.StaticMenus.Where(a => a.MenuId.Equals(id)).Select(a => a.MenuName).SingleOrDefault();
                return name;
            }
        }

    }
}
