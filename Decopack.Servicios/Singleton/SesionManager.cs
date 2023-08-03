using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Singleton
{
    public class SesionManager
    {
        private SesionManager()
        {

        }

        private static SesionManager _Instance = new SesionManager();

        public static SesionManager Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SesionManager();
                return _Instance;
            }
        }

        public Usuario _user = null;

        public void Login(Usuario user)
        {
            _user = user;
        }

        public void Logout(Usuario user)
        {
            _user = null;
        }
    }
}
