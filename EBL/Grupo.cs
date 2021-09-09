using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public class Grupo : TopEBL
    {
        private string nombre;
        private List<EBL.Modulo> modulos;

        public Grupo()
        {
            modulos = new List<EBL.Modulo>();
        }


        public Grupo(string nombre, List<Modulo> modulos)
        {
            this.nombre = nombre;
            this.modulos = modulos;
        }

        public string getGrupo()
        {
            return nombre;
        }

        public List<Modulo> getModulos()
        {
            return modulos;
        }
    }
}
