using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebsiteAPI.Models
{
    public class LogManager
    {
        public List<Log> _log;

        public LogManager(string name)
        {
            _log = ReadLogList(name);

            if (_log == null)
                _log = new List<Log>();
        }

        public void AddLog(Log l)
        {
            l.LogTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            _log.Add(l);

            WriteLogList(_log, l.UserName);
        }

        public IEnumerable<Log> GetLogs(string name)
        {
            return _log;
        }

        private void WriteLogList(IEnumerable<Log> logs, string name)
        {
            var output = JsonConvert.SerializeObject(logs);
            string path = "D:/home/site/wwwroot/Database/Logs/" + name + ".json";
            File.WriteAllText(path, output);
        }

        private List<Log> ReadLogList(string name)
        {
            string path = "D:/home/site/wwwroot/Database/Logs/" + name + ".json";

            if (File.Exists(path))
            {
                return JsonConvert.DeserializeObject<List<Log>>(File.ReadAllText(path));
            }
            else
            {
                File.Create(path).Close();
                return new List<Log>();
            }
        }
    }
}
