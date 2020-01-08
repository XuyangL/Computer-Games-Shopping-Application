using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShoppingWebsiteAPI.Models
{
    public class Log
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Record { get; set; }

        [Required]
        public string LogTime { get; set; }

        public Log(string userName, string record, string logTime)
        {
            UserName = userName;
            Record = record;
            LogTime = logTime;
        }
    }
}
