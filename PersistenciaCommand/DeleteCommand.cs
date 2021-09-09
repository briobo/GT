using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaCommands
{
    public class DeleteCommand : TopPersistenciaCommands
    {
        public void eliminar(string nombreTabla, string campo, string valor)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);
            SelectCommand select = new SelectCommand();
            DataRow[] rows = select.buscar(nombreTabla, campo, valor);
            foreach (DataRow item in rows)
            {
                item.Delete();
            }
        }
    }
}
