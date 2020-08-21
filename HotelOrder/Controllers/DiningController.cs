using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelOrder.Core.IServices;
using HotelOrder.Core.Models.BusinessModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace HotelOrder.Controllers
{
    [Route("v1")]
    [ApiController]
    public class DiningController : ControllerBase
    {
        private readonly IDiningService _diningService;
        public DiningController(IDiningService diningService)
        {
            _diningService = diningService;
        }

        [HttpGet]
        [Route("dining/tables")]
        public List<tables> GetTables()
        {
            List<tables> tables = new List<tables>();
            tables = _diningService.GetTablesList();
            return tables;
        }

    }
}
