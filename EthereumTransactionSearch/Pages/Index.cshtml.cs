using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthereumTransactionSearch.Models;
using EthereumTransactionSearch.Interfaces;
using EthereumTransactionSearch.DTOs;

namespace EthereumTransactionSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEtherService _etherService;
        [BindProperty]
        public UserDetailsModel userDetailsModel { get; set; }
        public UserSearchResultModel UserSearchResultModel { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IEtherService etherService)
        {
            _logger = logger;
            _etherService = etherService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (userDetailsModel != null)
            {
                //Call Ether Service
                var request = new GetTransactionByHashRequest()
                {
                    id = 1,
                    transactionHash = new string[] { userDetailsModel.EtherHashAddress }
                };

                var result = await _etherService.GetTransactionByHashAddress(request);
                if (result!=null)
                {
                    UserSearchResultModel = new UserSearchResultModel()
                    {
                        Blockhash = result?.Value?.BlockHash,
                        BlockNumber = result?.Value?.BlockNumber,
                        From = result?.Value?.From,
                        Gas = result?.Value?.Gas,
                        Value = result?.Value?.Value,
                        Hash = result?.Value?.Hash,
                        To = result?.Value?.To
                    };

            }
            }
            return Page();
        }
    }
}
