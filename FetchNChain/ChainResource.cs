using FetchNChain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChainResource
{
    public class ChainResource<T> : IChainResource<T> 
    {
        StorageFactory factory = new StorageFactory();
       
        public Task<T> Get()
        {          
            Task<T> extractedData = null;

            // TODO : 1.Read From Memory

            // 2.Read From FileSystem               

            // extractedData = ReadFromFileSystem();

            // 3.Read From WebService

            if (extractedData == null)
            {
                extractedData = ReadFromWebService();

                //if (extractedData != null)
                //{
                //    // 3.1 Save in Memory MAX 1 Hour

                //    // 3.2 Save in File System for MAX 4 Hours 
                //    bool success = SaveInFileSystem(extractedData.Result);
                //    if (!success)
                //    {
                //        // TODO THROW
                //    }
                //}

            }

            return extractedData;
        }



        private void ReadFromMemory()
        {
            // TODO
        }

        private Task<T> ReadFromFileSystem()
        {
            Task<T> extractedData = null;
            var fileSystemStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.FileSystem);
            if (fileSystemStorage == null)
            {
                throw new Exception("Failed to create FileSystem Storage Object");
            }

            extractedData = fileSystemStorage.ReadData();

            return extractedData;
        }

        private Task<T> ReadFromWebService()
        {

            Task<T> extractedData = null;
            var webServiceStorage = factory.GetROStorageByType<T>(StorageTypeEnum.WebService);
            extractedData = webServiceStorage.ReadData();
            return extractedData;                  
        }



        /// <summary>
        /// 
        /// </summary>
        private void SaveInMemory()
        {
            // TODO
        }

        private bool SaveInFileSystem(T streamDataToWrite)
        {
            var fileSystemStorage = factory.GetRWStorageByType<T>(StorageTypeEnum.FileSystem);
            bool success = fileSystemStorage.WriteData(streamDataToWrite);
            if (!success)
            {
                throw new Exception("Failed to write data to File System");
            }

            return success;
        }

    }
}
