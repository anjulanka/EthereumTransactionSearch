using EthereumTransactionSearch.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Interfaces
{
    public interface IEtherService
    {
        Task<GetBlockByNumberResponse> GetBlockByNumber(GetBlockByNumberRequest getBlockByNumberRequest);
    }
}
