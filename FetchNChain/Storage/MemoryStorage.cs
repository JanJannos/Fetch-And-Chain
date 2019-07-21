using ChainResource;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchNChain.StorageTypes
{
    public class MemoryStorage<T> : AbstractReadWriteStorage<T>
    {
        public MemoryStorage(int _expirationInterval, PermissionsEnum _permission)
        {
            this.ExpirationInterval = _expirationInterval;
            this.Permissions = _permission;
        }

        public override Task<T> ReadData()
        {
            throw new NotImplementedException();
        }

        public override bool WriteData(T stream)
        {
            throw new NotImplementedException();
        }
    }
}
