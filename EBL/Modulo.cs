using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public class Modulo : TopEBL
    {
        private string nombre;
        private string permisos;

        public Modulo(string nombre, string permisos)
        {
            this.nombre = nombre;
            this.permisos = permisos;
        }

        public string getNombre()
        {
            return nombre;
        }
        public string getPermisos()
        {
            return permisos;
        }

        public void setPermisos(string permisos)
        {
            this.permisos = permisos;
        }
    }
}
