using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class Item
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int Discount { get; set; }

        public int Rank { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

        public string ReleaseDate { get; set; }

        public string Type { get; set; }

        public string Language { get; set; }

        public bool SupportController { get; set; }

        public Item(int id, string name, int price, int discount, int rank, string developer, string publisher, string releaseDate, string type, string language, bool supportController)
        {
            Id = id;
            Name = name;
            Price = price;
            Discount = discount;
            Rank = rank;
            Developer = developer;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            Type = type;
            Language = language;
            SupportController = supportController;
        }
    }
}
