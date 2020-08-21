using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IServices
{
    public interface IDiningService
    {
        List<tables> GetTablesList();
    }
}
