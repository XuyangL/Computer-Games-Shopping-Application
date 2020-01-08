using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingWebsiteAPI.Models
{
    public class ItemCore
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Discount { get; set; }

        public ItemCore(int id, string name, int price, int discount)
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
        }
    }
}
