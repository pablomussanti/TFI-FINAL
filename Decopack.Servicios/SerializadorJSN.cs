using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Decopack.Servicios
{
    public class SerializadorJSN
    {
        public void Serialize(string path, object obj)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter writer = new StreamWriter(fs);
            JsonSerializer serializer = new JsonSerializer();
            using (writer)
                serializer.Serialize(writer, obj);
            writer.Close();
            fs.Close();
        }
    }
}
