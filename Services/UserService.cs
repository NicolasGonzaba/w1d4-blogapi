using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w1d4_blogapi.Models.DTO;

namespace w1d4_blogapi.Services
{
    public class UserService
    {

        private readonly Context _context;
        public UserService(Context context)
        {
            _context=context;
        }
        internal bool AddUser(CreateAccountDTO userToAdd)
        {
            throw new NotImplementedException();
        }
    }
}