using HotelOrder.Core.IRepositories;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Services
{
    public class MenuService :IMenuService
    {
        private readonly IMenuRepository _menuRepo;
        public MenuService(IMenuRepository menuRepo)
        {
            _menuRepo = menuRepo;
        }

        public List<menu> GetMenuByTableId(int table_id)
        {
            return _menuRepo.GetMenuByTableId(table_id);
        }

        public List<menu> GetMenuByTableIdandHeader(int table_id, string menu_header_name)
        {
            return _menuRepo.GetMenuByTableIdandHeader(table_id, menu_header_name);
        }

        public List<menuheaders> GetMenuheaders()
        {
            return _menuRepo.GetMenuheaders();
        }

        public List<menucart> SaveMenuItems(List<menucart> menucartLst, string ordernum)
        {
            return _menuRepo.SaveMenuItems(menucartLst, ordernum);
        }
    }
}
