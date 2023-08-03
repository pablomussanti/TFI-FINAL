using Decopack.EE;
using Decopack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.BLL
{
    public partial class EmpleadoBLL
    {
        public Empleado Create(Empleado Empleado)
        {
            Empleado result = default(Empleado);
            var EmpleadoDAL = new EmpleadoDAL();

            result = EmpleadoDAL.Create(Empleado);
            return result;
        }

        public List<Empleado> ListarTodos()
        {
            List<Empleado> result = default(List<Empleado>);

            var EmpleadoDAL = new EmpleadoDAL();
            result = EmpleadoDAL.Read();
            return result;

        }

        public Empleado GetByID(int ID)
        {
            Empleado result = default(Empleado);
            var EmpleadoDAL = new EmpleadoDAL();

            result = EmpleadoDAL.ReadBy(ID);
            return result;
        }

        public bool Edit(Empleado Empleado)
        {
            var EmpleadoDAL = new EmpleadoDAL();
            try
            {
                EmpleadoDAL.Update(Empleado);
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
            var EmpleadoDAL = new EmpleadoDAL();
            try
            {
                EmpleadoDAL.Delete(ID);
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
