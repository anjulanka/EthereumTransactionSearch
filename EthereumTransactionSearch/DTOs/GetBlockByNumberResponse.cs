using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.DTOs
{
    public class GetBlockByNumberResponse
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("result")]
        public BlockByNumberResultObject BlockByNumberResultObject { get; set; }
    }
    public class BlockByNumberResultObject
    {
        [JsonPropertyName("transactions")]
       public List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        [JsonPropertyName("blockHash")]
        public string BlockHash { get; set; }
        [JsonPropertyName("blockNumber")]
        public string BlockNumber { get; set; }
        [JsonPropertyName("from")]
        public string From { get; set; }
        [JsonPropertyName("gas")]
        public string Gas { get; set; }
        [JsonPropertyName("gasPrice")]
        public string GasPrice { get; set; }
        [JsonPropertyName("hash")]
        public string Hash { get; set; }
        [JsonPropertyName("input")]
        public string Input { get; set; }
        [JsonPropertyName("nonce")]
        public string Nonce { get; set; }
        [JsonPropertyName("r")]
        public string R { get; set; }
        [JsonPropertyName("s")]
        public string S { get; set; }
        [JsonPropertyName("to")]
        public string To { get; set; }
        [JsonPropertyName("transactionIndex")]
        public string TransactionIndex { get; set; }
        [JsonPropertyName("v")]
        public string V { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}


