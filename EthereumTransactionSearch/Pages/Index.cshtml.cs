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
                UserSearchResultModel = new UserSearchResultModel();

                var request = new GetBlockByNumberRequest()
                {
                    BlockNumber = String.Format("0X{0:X}", userDetailsModel.EtherBlock)
                };

                var result = await _etherService.GetBlockByNumber(request);

                //Find whether the input transaction is in the current ether Block
                if (result.BlockByNumberResultObject != null)
                {
                    var getTransactionDetails = result.BlockByNumberResultObject.Transactions.FirstOrDefault(s => s.Hash == userDetailsModel.EtherHashAddress.Trim());

                    if (getTransactionDetails != null)
                    {
                        UserSearchResultModel = new UserSearchResultModel()
                        {
                            Blockhash = getTransactionDetails.BlockHash,
                            BlockNumber = getTransactionDetails.BlockNumber,
                            From = getTransactionDetails.From,
                            Gas = getTransactionDetails.Gas,
                            Value = getTransactionDetails.Value,
                            Hash = getTransactionDetails.Hash,
                            To = getTransactionDetails.To,
                            IsSearchCompleted = true
                        };

                    }

                }

            }
            return Page();
        }
    }
}
