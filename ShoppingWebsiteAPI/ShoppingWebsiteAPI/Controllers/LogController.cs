using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebsiteAPI.Models;

namespace ShoppingWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        [HttpGet]
        [HttpGet("{name}")]
        public IEnumerable<Log> Get(string name)
        {
            LogManager lm = new LogManager(name);
            return lm.GetLogs(name);
        }

        // add new log record       
        // POST api/log      
        [HttpPost]
        [Route("[action]")]
        [ActionName("PostLogRecord")]
        public StatusCodeResult PostLogRecord([FromBody] Log l)
        {
            if (l == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }

            else
            {
                LogManager lm = new LogManager(l.UserName);
                lm.AddLog(l);
                return new StatusCodeResult(200); //created             
            }
        }
    }
}