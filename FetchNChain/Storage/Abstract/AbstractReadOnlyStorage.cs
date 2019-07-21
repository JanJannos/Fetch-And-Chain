using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource
{
    public abstract class AbstractReadOnlyStorage<T> : AbstractStorage
    {
        public abstract Task<T> ReadData();
    }

}
