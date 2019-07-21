using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

namespace FetchNChain
{
    public class HttpRequester
    {       
        /// <summary>
        /// Gets a url and fetches all the data from it
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async static Task<T> GetData<T>(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<T>(content);
            Console.Write(responseData);
            return responseData;
        }
    }
}
