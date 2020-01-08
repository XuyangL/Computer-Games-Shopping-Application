using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class Account
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public Account(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
