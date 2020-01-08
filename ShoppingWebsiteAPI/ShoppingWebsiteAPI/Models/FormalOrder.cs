using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class FormalOrder
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string OrderTime { get; set; }

        public IEnumerable<ItemLog> ItemList { get; set; }
        public int TotalPriceOrder { get; set; }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardDate { get; set; }
        public string CardCvv { get; set; }

        public string ShippingName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingZipCode { get; set; }

        public FormalOrder(string name, IEnumerable<ItemLog> itemList, int totalPriceOrder, string cardHolderName, string cardNumber, string cardDate, string cardCvv, string shippingName, string shippingAddress, string shippingZipCode)
        {
            Id = Guid.NewGuid().ToString("N");
            Name = name;

            var timeUtc = DateTime.UtcNow;
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, easternZone);

            OrderTime = easternTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            ItemList = itemList;
            TotalPriceOrder = totalPriceOrder;
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            CardDate = cardDate;
            CardCvv = cardCvv;
            ShippingName = shippingName;
            ShippingAddress = shippingAddress;
            ShippingZipCode = shippingZipCode;
        }
    }
}

