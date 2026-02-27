using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w1d4_blogapi.Models
{
    public class UserModel
    {
        public int Id  { get; set; }
        public string? Username { get; set; }
        public string? Salt { get; set; }
        public string? Hash { get; set; }   
    }
}