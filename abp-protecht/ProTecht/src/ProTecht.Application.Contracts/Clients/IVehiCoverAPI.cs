using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProTecht.Shared.RequestDTOs;
using Refit;

namespace ProTecht.Clients
{
    public interface IVehiCoverAPI
    {
        [Post("")]
        Task<int> GetQuoteAsync(QuoteRequestDto body);
    }
}
