using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    //deal with the formal order request
    [Route("api/[controller]")]
    [ApiController]
    public class FormalOrderController : ControllerBase
    {
        [HttpGet]
        [HttpGet("{name}")]
        public IEnumerable<FormalOrder> Get(string name)
        {
            FormalOrderManager fom = new FormalOrderManager(name);
            return fom.GetAllOrders(name);
        }

        // by name and order id        
        //// GET api/order/GetFormal         
        [HttpPost]
        [Route("[action]")]
        [ActionName("GetFormalOrder")]
        public async Task<IEnumerable<FormalOrder>> GetFormalOrder([FromBody] OrderRequest or)
        {
            return await GetFormalAsync(or);
        }

        private Task<IEnumerable<FormalOrder>> GetFormalAsync(OrderRequest or)
        {
            FormalOrderManager fom = new FormalOrderManager(or.Name);
            return Task.FromResult(fom.GetFormalOrder(or.Id));
        }

        // add new formal order       
        // POST api/formalorder      
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostFormalOrder")]
        public StatusCodeResult PostFormalOrder([FromBody] Order o)
        {
            if (o == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            else
            {
                FormalOrderManager fom = new FormalOrderManager(o.Name);
                fom.AddFormalOrder(o);
                return new StatusCodeResult(200); //created             
            }
        }
    }
}