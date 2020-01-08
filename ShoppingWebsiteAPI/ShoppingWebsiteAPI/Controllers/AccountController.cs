using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    //deal with the account request
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public AccountManager am = new AccountManager();

        // add new       
        // POST api/account      
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostAccount")]
        public StatusCodeResult PostAccount([FromBody] Account a)
        {
            if (a == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            if(am.CheckUserNameExist(a.Name))
            {
                am.AddAccount(a);
                return new StatusCodeResult(200); //created             
            }

            else { return new Microsoft.AspNetCore.Mvc.BadRequestResult(); }
        }

        // add new or edit         
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostAccount2")]
        public StatusCodeResult PostAccount2([FromBody] Account a)
        {
            if (a == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            if (am.CheckAccount(a))
            {
                return new StatusCodeResult(200);           
            }

            else { return new Microsoft.AspNetCore.Mvc.BadRequestResult(); }
        }
    }
}