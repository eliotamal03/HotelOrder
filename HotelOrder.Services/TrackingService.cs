using HotelOrder.Core.IRepositories;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Services
{
    public class TrackingService : ITrackingService
    {
        private readonly ITrackingRepository _trackingRepository;
        public TrackingService(ITrackingRepository trackingRepository)
        {
            _trackingRepository = trackingRepository;
        }

        public List<menutracking> GetOrderTracking(int table_id, string order_number)
        {
            throw new NotImplementedException();
        }

        public void SaveOrderTracking(int table_id, string order_number)
        {
            throw new NotImplementedException();
        }
    }
}
