using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Interfaces
{
    public interface IWebRequestService
    {
        public Task<string> ProcessWebRequest(string url, HttpMethod httpMethod, Object request);
    }
}
