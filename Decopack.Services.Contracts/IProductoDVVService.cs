using Decopack.EE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Services.Contracts
{
    public interface IProductoDVVService
    {
        List<ProductoDVV> ListarTodos();
        ProductoDVV Create(ProductoDVV ProductoDVV);
        bool Edit(ProductoDVV ProductoDVV);
        ProductoDVV GetByID(int ID);
        bool Delete(int ID);
    }
}
