using System;
using System.Collections.Generic;

namespace PolicyAPI.Models
{
    public class User
    {
        public User()
        {
            Permissions = new List<Tuple<string, string>>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<Tuple<string, string>> Permissions { get; set;} 
    }
}