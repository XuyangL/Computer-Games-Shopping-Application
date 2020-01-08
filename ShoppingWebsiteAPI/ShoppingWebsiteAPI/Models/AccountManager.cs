using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingWebsiteAPI.Models
{
    public class AccountManager
    {
        public Hashtable _account;
        //private readonly string rootpath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));

        public AccountManager()
        {

            _account = ReadAccountList();

            if (_account == null)
                _account = new Hashtable();
        }

        public bool CheckUserNameExist(string userName)
        {
            if (_account[userName] != null)
            {
                return false;
            }
            else return true;
        }

        public void AddAccount(Account a)
        {
            _account[a.Name] = a.Password;
            WriteAccountList(_account);
        }

        public bool CheckAccount(Account a)
        {
            if ((string)_account[a.Name] != a.Password)
            {
                return false;
            }

            else return true;
        }

        private void WriteAccountList(Hashtable accounts)
        {
            var output = JsonConvert.SerializeObject(accounts);
            string path = "D:/home/site/wwwroot/Database/accounts.json";
            File.WriteAllText(path, output);
        }

        private Hashtable ReadAccountList()
        {
            string path = "D:/home/site/wwwroot/Database/accounts.json";
            return JsonConvert.DeserializeObject<Hashtable>(File.ReadAllText(path));
        }
    }
}
