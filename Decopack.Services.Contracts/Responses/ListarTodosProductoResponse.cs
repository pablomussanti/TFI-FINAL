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
    public partial class ListarTodosProductoResponse
    {
        [DataMember]
        public List<Producto> Result { get; set; }
    }
}
