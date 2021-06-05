using EthereumTransactionSearch.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Services
{
    public class WebRequestService: IWebRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<IWebRequestService> _logger;
        public WebRequestService(HttpClient httpClient, ILogger<IWebRequestService> logger)
        {
            _httpClient = httpClient;
            logger = _logger;
        }

        public async Task<string> ProcessWebRequest(string url, HttpMethod httpMethod, Object request)
        {

            HttpResponseMessage response;
            try
            {
                if (httpMethod == HttpMethod.Get)
                {
                    response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string reader = await response.Content.ReadAsStringAsync();
                        return reader;
                    }
                }

                if (httpMethod == HttpMethod.Post)
                {
                    //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    response = await _httpClient.PostAsJsonAsync(url, request);
                    if (response.IsSuccessStatusCode)
                    {
                        string reader = await response.Content.ReadAsStringAsync();
                        return reader;
                    }
                }
            }
            catch(Exception e)
            {
                //log errors
                _logger.LogError(e,e.Message);
            }
            
            return null;
        }
    }
}
