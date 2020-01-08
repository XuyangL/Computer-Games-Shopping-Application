using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class Order
    {
        [Required]
        public string Name { get; set; }

        public IEnumerable<ItemLog> ItemList { get; set; }
        public int TotalPriceOrder { get; set; }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardCvv { get; set; }

        public string ShippingName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingZipCode { get; set; }



    }
}
