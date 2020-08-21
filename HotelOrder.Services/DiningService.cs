using HotelOrder.Core.IRepositories;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Services
{
    public class DiningService : IDiningService
    {
        private readonly IDiningRepository _diningRepository;
        public DiningService(IDiningRepository diningRepository)
        {
            _diningRepository = diningRepository;
        }

        public List<tables> GetTablesList()
        {
            List<tables> tableLst = _diningRepository.GetTablesList();
            return tableLst;
        }
    }
}
