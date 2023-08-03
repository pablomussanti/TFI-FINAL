using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Bitacora
{

    public abstract class Bitacorageneral
    {
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        private DateTime _fecha;
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        private string _descripcion;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        private string _tipo;

        public string tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                _tipo = value;
            }
        }

        private string _user;

        public string user
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        private string _Id;

        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
            }
        }
    }

}
