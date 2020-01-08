using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class ItemLog
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public int Qty { get; set; }

        [Required]
        public int TotalPrice { get; set; }

        public ItemLog(int id, string name, int price, int discount, int qty, int totalPrice)
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
            Qty = qty;
            TotalPrice = totalPrice;
        }
    }
}
