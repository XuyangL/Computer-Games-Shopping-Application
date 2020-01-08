using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebsiteAPI.Models
{
    public class FormalOrderManager
    {
        public List<FormalOrder> _formalOrder;

        public FormalOrderManager(string name)
        {
            _formalOrder = ReadFormalOrderList(name);

            if (_formalOrder == null)
                _formalOrder = new List<FormalOrder>();
        }

        public void AddFormalOrder(Order orderlist)
        {
            OrderManager om = new OrderManager();      
            var o = om._order.FirstOrDefault(order => order.Name == orderlist.Name);

            if (o == null)
            {
                return;
            }
            else
            {
                om._order.Remove(o);
                om.WriteTempOrderList(om._order);

                FormalOrder fo = new FormalOrder(orderlist.Name, orderlist.ItemList, orderlist.TotalPriceOrder,orderlist.CardHolderName,orderlist.CardNumber,orderlist.CardDate,orderlist.CardCvv,orderlist.ShippingName,orderlist.ShippingAddress,orderlist.ShippingZipCode);
                _formalOrder.Add(fo);

                WriteFormalOrderList(_formalOrder, orderlist.Name);
            }

        }

        public IEnumerable<FormalOrder> GetAllOrders(string name)
        {
            return _formalOrder;
        }

        public IEnumerable<FormalOrder> GetFormalOrder(string Id)
        {
            IEnumerable<FormalOrder> fol = _formalOrder.Where(fo => fo.Id == Id).ToList();
            return fol;
        }



        private void WriteFormalOrderList(IEnumerable<FormalOrder> formalOrder, string name)
        {
            var output = JsonConvert.SerializeObject(formalOrder);
            string path = "D:/home/site/wwwroot/Database/Orders/" + name + ".json";
            File.WriteAllText(path, output);
        }

        private List<FormalOrder> ReadFormalOrderList(string name)
        {
            string path = "D:/home/site/wwwroot/Database/Orders/" + name + ".json";

            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<List<FormalOrder>>(File.ReadAllText(path));
            }
            else
            {
                File.Create(path).Close();
                return new List<FormalOrder>();
            }
        }
    }
}
