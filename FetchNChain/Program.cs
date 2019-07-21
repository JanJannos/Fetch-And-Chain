using ChainResource;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FetchNChain
{
    class Program
    {
        static void Main(string[] args)
        {
            ChainResource<ExchangeRateList> testChainResource = new ChainResource<ExchangeRateList>();
            Task<ExchangeRateList> taskChain = testChainResource.Get();
            taskChain.Wait();
            ExchangeRateList results = taskChain.Result;
            if (results != null)
            {
                Console.WriteLine("\nThe rates are :\n");
                foreach (var rate in results.Rates)
                {
                    Console.WriteLine("{0}:{1}", rate.Key, rate.Value);
                }
            }
        }



    }
}
