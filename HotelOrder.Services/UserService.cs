using HotelOrder.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Services
{
    public class UserService : IUserService
    {
        private readonly IUserService _userService;
        public UserService(IUserService userService)
        {
            _userService = userService;
        }
    }
}
