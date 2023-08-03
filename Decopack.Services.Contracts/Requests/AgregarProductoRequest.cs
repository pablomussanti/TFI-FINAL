using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts.Requests
{
    [DataContract]
    public partial class AgregarProductoRequest
    {
        [DataMember]
        public Producto Producto { get; set; }
    }
}
