using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.DTOs
{
    public class GetBlockByNumberRequest
    {
        public GetBlockByNumberRequest()
        {
            this.Id = 1;
            this.MethodName = "eth_getBlockByNumber";
            this.Version = "2.0";
        }
        
        [JsonIgnore]
        public string BlockNumber { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("params")]
        public Object[] Params => new object[] { this.BlockNumber, true };

        [JsonPropertyName("method")]
        public string MethodName { get; set; }
        
        [JsonPropertyName("jsonrpc")]
        public string Version { get; set; }
    }

    //public class Params
    //{
    //    //[JsonPropertyName("")]
    //    public string BlockNumber { get; set; }
    //    //[JsonPropertyName("")]
    //    public bool IsFullTransactionLog { get; set; }
    //}
}
