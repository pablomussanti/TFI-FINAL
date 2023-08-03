using Decopack.Servicios.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json.Linq;
using FireSharp.Config;

namespace Decopack.DAL
{

    public class BitacoraDAL
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://tfiuai-4be2c-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

    public void Create(Bitacora Bitacora)
        {

            client = new FireSharp.FirebaseClient(config);
            var data = Bitacora;
            PushResponse response = client.Push("Bitacora/", data);
            data.Id = response.Result.Name;
            SetResponse setResponse = client.Set("Bitacora/"+data.Id, data);

        }

        public List<Bitacora> Read()
        {

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Bitacora");
            dynamic data = JsonConvert.DeserializeObject<dynamic>((response.Body));
            List<Bitacora> Bitacoras = new List<Bitacora>();
            foreach (var item in data)
            {
                Bitacoras.Add(JsonConvert.DeserializeObject<Bitacora>(((JProperty)item).Value.ToString()));
            }
            return Bitacoras;
        }
    }
}
