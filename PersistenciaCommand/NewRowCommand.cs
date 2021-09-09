using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaCommands
{
    public class NewRowCommand : TopPersistenciaCommands
    {
        public DataRow obtenerNuevaRow(string nombreTabla)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);

            return tabla.NewRow();
        }
    }
}