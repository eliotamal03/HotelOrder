using HotelOrder.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelOrder.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        public UserRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
