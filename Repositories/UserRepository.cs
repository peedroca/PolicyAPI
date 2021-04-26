using System;
using System.Collections.Generic;
using System.Linq;
using PolicyAPI.Models;

namespace PolicyAPI.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User 
            { 
                Id = 1, 
                Username = "batman", 
                Password = "batman", 
                Role = "admin",
                Permissions = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("listar", "Produtos"),
                    new Tuple<string, string>("listar", "Pedidos"),
                }
            });
            
            users.Add(new User 
            { 
                Id = 2, 
                Username = "robin", 
                Password = "robin", 
                Role = "default",
                Permissions = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("listar", "Produtos")
                }
            });
      
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}