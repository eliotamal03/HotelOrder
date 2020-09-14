using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelOrder.Controllers
{
    [Route("v1")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [Route("dining/menuheaders")]
        public List<menuheaders> GetTables()
        {
            List<menuheaders> headers = new List<menuheaders>();
            headers = _menuService.GetMenuheaders();
            return headers;
        }

        [HttpGet]
        [Route("dining/{table_id}/{menu_header_name}/menu")]
        public List<menu> GetTables(int table_id, string menu_header_name)
        {
            List<menu> headers = new List<menu>();
            headers = _menuService.GetMenuByTableIdandHeader(table_id, menu_header_name);
            return headers;
        }

        [HttpPost]
        [Route("menu/{order_number}/items")]
        public string SaveMenuItems(List<menucart> cartLst, string order_number)
        {
            string order_num = string.Empty;
            order_number = order_number == "empty" ? "" : order_number;
            List<menucart> orderidLst = _menuService.SaveMenuItems(cartLst, order_number);
            if(orderidLst !=null && orderidLst.Count>0)
            {
                foreach(var items in orderidLst)
                {
                    order_num = items.order_number;
                    break;
                }
            }
            return order_num;
        }
    }
}
