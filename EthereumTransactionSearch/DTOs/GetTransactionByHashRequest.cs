using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.DTOs
{
    public class GetTransactionByHashRequest
    {
        public GetTransactionByHashRequest()
        {
            this.id = 1;
            this.methodName = "eth_getTransactionByHash";
            this.Version = "2.0";
        }
        public int id { get; set; }
        [JsonPropertyName("params")]
        public string[] transactionHash { get; set; }
        [JsonPropertyName("method")]
        public string methodName { get; set; }
        [JsonPropertyName("jsonrpc")]
        public string Version { get; set; }
    }
}
