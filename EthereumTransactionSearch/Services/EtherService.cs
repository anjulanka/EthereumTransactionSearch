using EthereumTransactionSearch.DTOs;
using EthereumTransactionSearch.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace EthereumTransactionSearch.Services
{
    public class EtherService : IEtherService
    {

        private readonly IWebRequestService _webRequestService;
        private readonly ILogger<IEtherService> _logger;
        public EtherService(IWebRequestService webRequestService, ILogger<IEtherService> logger)
        {
            _webRequestService = webRequestService;
            _logger = logger;
        }

        public async Task<GetBlockByNumberResponse> GetBlockByNumber(GetBlockByNumberRequest getBlockByNumberRequest)
        {
            GetBlockByNumberResponse getBlockByNumberResponse    = null;

            try
            {
                var content = new StringContent(JsonSerializer.Serialize(getBlockByNumberRequest));

                //Auth is already passing /22b2ebe2940745b3835907b30e8257a4 in the URL
                var requestResult = await _webRequestService.ProcessWebRequest("https://mainnet.infura.io/v3/22b2ebe2940745b3835907b30e8257a4", HttpMethod.Post, getBlockByNumberRequest);

                getBlockByNumberResponse = (GetBlockByNumberResponse)JsonSerializer.Deserialize(requestResult, typeof(GetBlockByNumberResponse));

            }
            catch (Exception e)
            {
                // Log error     
                _logger.LogError(e, e.Message);
            }

            return getBlockByNumberResponse;
        }

      
    }
}
