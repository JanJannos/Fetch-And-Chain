using ChainResource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;


namespace FetchNChain.StorageTypes
{     

    public class WebServiceStorage<T> : AbstractReadOnlyStorage<T>
    {           
        public WebServiceStorage(int _expirationInterval, PermissionsEnum _permission)
        {
            this.ExpirationInterval = _expirationInterval;
            this.Permissions = _permission;
        }

        public override Task<T> ReadData()
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;
            string app_id = confCollection["app_id"].Value;
            string package = confCollection["latestJson"].Value;
            string baseURL = confCollection["openExchangeBasicUrl"].Value;
            string url = string.Format("{0}{1}?app_id={2}", baseURL, package, app_id);

            Task<T> result = HttpRequester.GetData<T>(url);
            return result;
        }        
    }
}
