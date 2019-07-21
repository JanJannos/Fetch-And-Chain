using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FetchNChain
{
    public class ExchangeRateList
    {
        [XmlElementAttribute(Order = 1)]
        [JsonPropertyAttribute("rates")]
        public Dictionary<String, Double> Rates { get; set; }
    }
}