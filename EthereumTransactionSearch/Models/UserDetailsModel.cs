using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Models
{
    public class UserDetailsModel
    {
        [Required]
        public string EtherHashAddress { get; set; }
        [Required]
        public int EtherBlock { get; set; }

    }
}
