using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w1d4_blogapi.Models.DTO;
using w1d4_blogapi.Services.Context;

namespace w1d4_blogapi.Services
{
    public class UserService
    {

        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context=context;
        }
        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}