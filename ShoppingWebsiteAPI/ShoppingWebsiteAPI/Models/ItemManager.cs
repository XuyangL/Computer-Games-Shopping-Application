using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShoppingWebsiteAPI.Models
{
    public class ItemManager
    {
        public List<Item> _items;
        //private readonly string rootpath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin", StringComparison.CurrentCulture));

        public ItemManager()
        {
            _items = ReadItemsList().ToList();
        }

        public IEnumerable<ItemCore> GetAllItems()
        {
            var itemCore = new List<ItemCore>();

            foreach(Item i in _items)
            {
                itemCore.Add(new ItemCore(i.Id, i.Name, i.Price,i.Discount));
            }

            return itemCore;
        }

        public IEnumerable<Item> GetItemById(int id)
        {
            return _items.Where(s => s.Id == id).ToList();
        }

        private void WriteItemsList(IEnumerable<Item> items)
        {
            var output = JsonConvert.SerializeObject(items);
            string path = "D:/home/site/wwwroot/Database/items.json";
            File.WriteAllText(path, output);
        }

        private IEnumerable<Item> ReadItemsList()
        {
            string path = "D:/home/site/wwwroot/Database/items.json";
            return JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(path));
        }

    }
}
