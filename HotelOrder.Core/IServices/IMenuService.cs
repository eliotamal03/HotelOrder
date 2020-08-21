using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IServices
{
    public interface IMenuService
    {
        List<menu> GetMenuByTableId(int table_id);
        List<menu> GetMenuByTableIdandHeader(int table_id, string menu_header_name);

        List<menuheaders> GetMenuheaders();

        List<menucart> SaveMenuItems(List<menucart> menucartLst, string ordernum);

    }
}
