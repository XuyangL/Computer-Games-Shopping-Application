using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    //deal with the temp order request
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderManager om = new OrderManager();

        // by name        
        //// GET api/order/name         
        [HttpGet("{name}")]
        public async Task<IEnumerable<Order>> Get(string name)
        {
            return await GetAsync(name);
        }

        private Task<IEnumerable<Order>> GetAsync(string name)
        {
            return Task.FromResult(om.GetOrder(name));
        }

        // add new or update order       
        // POST api/order      
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostOrder")]
        public StatusCodeResult PostOrder([FromBody] Order o)
        {
            if (o == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            else
            {
                om.AddOrder(o);
                return new StatusCodeResult(200); //created             
            }
        }
    }
}