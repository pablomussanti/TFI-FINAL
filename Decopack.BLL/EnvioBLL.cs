using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class EnvioBLL
    {
        public Envio Create(Envio Envio)
        {
            Envio result = default(Envio);
            var EnvioDAL = new EnvioDAL();

            result = EnvioDAL.Create(Envio);
            return result;
        }

        public List<Envio> ListarTodos()
        {
            List<Envio> result = default(List<Envio>);

            var EnvioDAL = new EnvioDAL();
            result = EnvioDAL.Read();
            return result;

        }

        public Envio GetByID(int ID)
        {
            Envio result = default(Envio);
            var EnvioDAL = new EnvioDAL();

            result = EnvioDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Envio Envio)
        {
            var EnvioDAL = new EnvioDAL();
            try
            {
                EnvioDAL.Update(Envio);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al editar el elemento");
                return false;
            }

        }

        public bool Delete(int ID)
        {
            var EnvioDAL = new EnvioDAL();
            try
            {
                EnvioDAL.Delete(ID);
                return true;
            }
            catch
            {
                Console.WriteLine("Error al eliminar el elemento");
                return false;
            }

        }
    }
}
