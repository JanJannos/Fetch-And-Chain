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
    public enum StorageTypeEnum
    {
        Memory,
        FileSystem,
        WebService
    }

    public enum PermissionsEnum
    {
        ReadOnly,
        ReadWrite
    }

    public abstract class AbstractStorage
    {
        public PermissionsEnum Permissions { get; set; }
        public int ExpirationInterval { get; set; }
    }

}
