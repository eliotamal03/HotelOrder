using HotelOrder.Core.IRepositories;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelOrder.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private HotelOrderDbContext _context;

        public MenuRepository(HotelOrderDbContext context)
        {
            _context = context;
        }
        public List<menu> GetMenuByTableId(int table_id)
        {
            List<menu> menuLst = new List<menu>();
            var dbLst = _context.StaticMenus.Select(a => a).ToList();
            foreach (var item in dbLst)
            {
                menu menu = new menu()
                {
                    menu_header_name = item.MenuHeader.MenuHeaderName,
                    menu_name = item.MenuName,
                    preference_name = item.Preference.PreferenceName,
                    menu_id = item.MenuId,

                };
                menuLst.Add(menu);
            }
            return menuLst;
        }

        public List<menu> GetMenuByTableIdandHeader(int table_id, string menu_header_name)
        {
            List<menu> menuLst = new List<menu>();
            int menuheaderId = _context.StaticMenuHeaders.Where(a => a.MenuHeaderName.ToLower().Equals(menu_header_name.ToLower())).Select(
                a => a.MenuHeaderId
                ).SingleOrDefault();
            var dbLst = _context.StaticMenus.Select(a => a).Where(a => a.MenuHeaderId.Equals(menuheaderId)).ToList();
            foreach (var item in dbLst)
            {
                menu menu = new menu()
                {
                    menu_header_name = GetHeaderName(item.MenuHeaderId ?? 0),
                    menu_name = item.MenuName,
                    preference_name = GetPreferenceName(item.PreferenceId ?? 0),
                    menu_id = item.MenuId,
                };
                menuLst.Add(menu);
            }
            return menuLst;
        }

        public List<menuheaders> GetMenuheaders()
        {
            List<menuheaders> menuLst = new List<menuheaders>();
            var dbLst = _context.StaticMenuHeaders.Select(a => a).ToList();
            foreach (var item in dbLst)
            {
                menuheaders menu = new menuheaders()
                {
                    menu_header_name = item.MenuHeaderName,
                    menu_header_id = item.MenuHeaderId

                };
                menuLst.Add(menu);
            }
            return menuLst;
        }

        public List<menucart> SaveMenuItems(List<menucart> menucartLst, string ordernum)
        {
            List<menucart> menuLst = new List<menucart>();
            if (!string.IsNullOrWhiteSpace(ordernum))
            {
                menucartLst.OrderByDescending(a=>a.order_id);
                List<Orders> dborder = _context.Orders.Where(a => a.OrderNumber.Equals(ordernum)).Select(a => a).OrderByDescending(a=>a.OrderId).ToList();
                List<Orders> orderLst = new List<Orders>();
                if (dborder != null && dborder.Count > 0)
                {
                    int count = 0;
                    foreach (var items in menucartLst)
                    {
                        if (items.order_id.Equals(dborder[count].OrderId))
                        {
                            menucart cart = new menucart();
                            Orders dborderItem = _context.Orders.Where(a => a.OrderId.Equals(items.order_id)).Select(a => a).SingleOrDefault();
                            dborderItem.DiningTableId = items.dining_table_id;
                            dborderItem.MenuId = items.menu_id;
                            dborderItem.Quantity = items.quantity;
                            _context.SaveChanges();
                            cart.order_id = dborderItem.OrderId;
                            cart.order_status_id = items.order_status_id;
                            cart.order_tracking_id = items.order_tracking_id > 0 ? items.order_tracking_id : 0;
                            menuLst.Add(cart);
                        }
                        count++;
                    }

                }
            }
            else
            {
                List<Orders> orderLst = new List<Orders>();
                string order_number = string.Empty;
                foreach (var items in menucartLst)
                {
                    menucart cart = new menucart();
                    Orders menucart = new Orders();
                    menucart.DiningTableId = items.dining_table_id;
                    menucart.MenuId = items.menu_id;
                    menucart.Quantity = items.quantity;
                    if (string.IsNullOrWhiteSpace(order_number) && order_number == "")
                    {
                        menucart.OrderNumber = "ORD-" + Guid.NewGuid().ToString();
                        order_number = menucart.OrderNumber;
                    }
                    else
                    {
                        menucart.OrderNumber = order_number;
                    }
                    _context.Orders.Add(menucart);
                    _context.SaveChanges();
                    _context.Entry<Orders>(menucart).State = EntityState.Detached;
                    cart.order_id = menucart.OrderId;
                    cart.order_status_id = items.order_status_id;
                    cart.order_tracking_id = items.order_tracking_id > 0 ? items.order_tracking_id : 0;
                    menuLst.Add(cart);
                }
            }
            return menuLst;
        }

        public string GetHeaderName(int id)
        {
            string name = _context.StaticMenuHeaders.Where(a => a.MenuHeaderId.Equals(id)).Select(a => a.MenuHeaderName).SingleOrDefault();
            return name;
        }

        public string GetPreferenceName(int id)
        {
            string name = _context.StaticPreferences.Where(a => a.PreferenceId.Equals(id)).Select(a => a.PreferenceName).SingleOrDefault();
            return name;
        }
    }
}
