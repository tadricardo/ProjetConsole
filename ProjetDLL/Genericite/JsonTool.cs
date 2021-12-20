using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
    public class JsonTool
    {
        public static string ToJson<T>(T p)
        {
            string result = null;
            DataContractJsonSerializer ser = new DataContractJsonSerializer(p.GetType());
            MemoryStream flux = new MemoryStream();
            ser.WriteObject(flux, p);
            result = Encoding.UTF8.GetString(flux.ToArray());

            return result;
        }
    }
}
