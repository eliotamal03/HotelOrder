using HotelOrder.Core.IRepositories;
using HotelOrder.Core.Models.BusinessModel;
using HotelOrder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HotelOrder.Repositories
{
    public class DiningRepository : IDiningRepository
    {
        private HotelOrderDbContext _context;

        public DiningRepository(HotelOrderDbContext context)
        {
            _context = context;
        }

        public List<tables> GetTablesList()
        {
            List<tables> tableLst = new List<tables>();
            var dbLst = _context.StaticDiningTables.Select(a => a).ToList();
            foreach (var item in dbLst)
            {
                tables table = new tables();
                table.table_name = item.DiningTableName;
                table.table_id = item.DiningTableId;
                tableLst.Add(table);
            }
            return tableLst;
        }
    }
}
