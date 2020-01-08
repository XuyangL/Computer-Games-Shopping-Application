using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingWebsiteAPI.Controllers
{
    //deal with the image request
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //by Id 
        // GET api/image/id         
        [HttpGet("{id}")]
        public async Task<IActionResult>  Get(int id)
        {
            //string rootpath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var image = System.IO.File.OpenRead("D:/home/site/wwwroot/Resources/" + id.ToString() + ".jpg");
            return await Task.Run(() => File(image, "image/jpeg"));  //return the image file to the client

        }
    }
}
