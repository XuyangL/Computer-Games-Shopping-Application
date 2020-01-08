using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    //deal with the item request
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public ItemManager im = new ItemManager();

        // GET api/items     
        [HttpGet]
        public IEnumerable<ItemCore> Get()
        {
            return im.GetAllItems();
        }

        //by Id 
        // GET api/items/id         
        [HttpGet("{id}")]
        public async Task<IEnumerable<Item>> Get(int id)
        {
            return await GetAsync(id);
        }

        private Task<IEnumerable<Item>> GetAsync(int id)
        {
            return Task.FromResult(im.GetItemById(id));
        }
    }
}