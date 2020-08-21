using HotelOrder.Core.Models.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Core.IRepositories
{
    public interface IDiningRepository
    {
        List<tables> GetTablesList();
    }
}
