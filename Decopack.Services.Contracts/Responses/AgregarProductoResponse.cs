using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts.Responses
{
    [DataContract]
    public partial class AgregarProductoResponse
    {
        [DataMember]
        public Producto Result { get; set; }

        public int Total { get; set; }

        public string Message { get; set; }

    }
}
