using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decopack.Servicios.Singleton
{
    public class SingletonIdioma
    {

        private SingletonIdioma()
        {

        }

        private static SingletonIdioma _Instance = null;

        public static SingletonIdioma Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SingletonIdioma();
                return _Instance;
            }
        }

        //public Idioma _Idioma = null;

        //public void Login(Idioma idioma)
        //{
        //    _Idioma = idioma;
        //}

        //public void Logout(Idioma idioma)
        //{
        //    _Idioma = null;
        //}
    }
}
