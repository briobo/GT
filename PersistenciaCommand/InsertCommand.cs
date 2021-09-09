using CapaDeSeguridad;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaCommands
{
    public class InsertCommand : TopPersistenciaCommands
    {
        public void insertar(string nombreTabla, DataRow nuevaRow)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);
            tabla.Rows.Add(nuevaRow);

        }
    }
}
