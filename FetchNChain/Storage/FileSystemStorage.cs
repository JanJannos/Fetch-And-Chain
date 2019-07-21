using ChainResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace FetchNChain.StorageTypes
{
    public class FileSystemStorage<T> : AbstractReadWriteStorage<T>
    {
        private String SERIALIZERPATH = @"C:\Test\myserializationtest.xml";

        public FileSystemStorage(int _expirationInterval, PermissionsEnum _permission)
        {
            this.ExpirationInterval = _expirationInterval;
            this.Permissions = _permission;
        }

        public override Task<T> ReadData()
        {          
            if (File.Exists(this.SERIALIZERPATH))
            {
                using (FileStream fs = new FileStream(SERIALIZERPATH, FileMode.Open)) //double check that...
                {
                    XmlSerializer _xSer = new XmlSerializer(typeof(T));

                    var myObject = _xSer.Deserialize(fs);

                    return Task.FromResult((T)myObject);
                }
            }

            return null;
        }       

        public override bool WriteData(T stream)        
        {
            try
            {            
                using (FileStream fs = new FileStream(SERIALIZERPATH, FileMode.Create))
                {
                    XmlSerializer xSer = new XmlSerializer(typeof(T));

                    xSer.Serialize(fs, stream);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    
    }
}
