using FetchNChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource
{
    public interface IChainResource<T> 
    {
        Task<T> Get();
    }
}
