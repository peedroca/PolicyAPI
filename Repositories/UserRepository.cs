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
                    new Tuple<string, string>("permissao", "listar_pedido"),
                    new Tuple<string, string>("permissao", "listar_etiqueta")
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

            users.Add(new User 
            { 
                Id = 3, 
                Username = "superman", 
                Password = "superman", 
                Role = "default",
                Permissions = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("permissao", "Orcamento")
                }
            });
      
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}