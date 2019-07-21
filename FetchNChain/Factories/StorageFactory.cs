using FetchNChain.StorageTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource
{
    public class StorageFactory
    {
        public AbstractReadOnlyStorage<T> GetROStorageByType<T>(StorageTypeEnum type)
        {
            switch (type)
            {              
                case StorageTypeEnum.WebService:
                    return new WebServiceStorage<T>(0, PermissionsEnum.ReadOnly);
            }

            return null;
        }

        public AbstractReadWriteStorage<T> GetRWStorageByType<T>(StorageTypeEnum type)
        {
            switch (type)
            {
                case StorageTypeEnum.FileSystem:
                    return new FileSystemStorage<T>(1, PermissionsEnum.ReadWrite);
                case StorageTypeEnum.Memory:
                    return new MemoryStorage<T>(4, PermissionsEnum.ReadOnly);            
            }

            return null;
        }
    }
}
