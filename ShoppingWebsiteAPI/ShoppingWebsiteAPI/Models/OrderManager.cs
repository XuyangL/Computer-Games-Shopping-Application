using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebsiteAPI.Models
{
    public class OrderManager
    {
        public List<Order> _order;
        
        public OrderManager()
        {
            var data = ReadTempOrderList();

            if (data == null)
                _order = new List<Order>();

            else _order = data.ToList();
        }

        public void AddOrder(Order orderlist)
        {
            var o = _order.FirstOrDefault(order => order.Name == orderlist.Name);

            if (o == null) //not exist,add this new order
            {
                _order.Add(orderlist);

                WriteTempOrderList(_order);

            }
            else  //exist, update the order
            {
                o.ItemList = orderlist.ItemList;
                o.TotalPriceOrder = orderlist.TotalPriceOrder;

                WriteTempOrderList(_order);
            }
        }

        public IEnumerable<Order> GetOrder(string name)
        {
            return _order.Where(order => order.Name== name).ToList();
        }

        public void WriteTempOrderList(IEnumerable<Order> orders)
        {
            var output = JsonConvert.SerializeObject(orders);
            string path = "D:/home/site/wwwroot/Database/tempOrders.json";
            File.WriteAllText(path, output);
        }

        public IEnumerable<Order> ReadTempOrderList()
        {
            string path = "D:/home/site/wwwroot/Database/tempOrders.json";
            return JsonConvert.DeserializeObject<List<Order>>(File.ReadAllText(path));
        }
    }
}
