using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    public class TablaUsuarioGrupos : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            agregarRelacion(dataTable, "admin", "Administradores");
            agregarRelacion(dataTable, "admin", "Basico");
            agregarRelacion(dataTable, "admin", "Alta de datos");
            agregarRelacion(dataTable, "admin", "RRHH");
            agregarRelacion(dataTable, "admin", "Sistemas");
            agregarRelacion(dataTable, "admin", "Informes");

            agregarRelacion(dataTable, "invitado", "Basico");
            agregarRelacion(dataTable, "master", "Administradores");
            agregarRelacion(dataTable, "master", "Basico");
        }

        private static void agregarRelacion(DataTable dataTable, string usuario, string grupo)
        {
            DataRow row = dataTable.NewRow();
            row["usuario"] = usuario;
            row["grupo"] = grupo;
            dataTable.Rows.Add(row);
        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("UsuarioGrupos");
            tabla.Columns.Add("usuario", typeof(String));
            tabla.Columns.Add("grupo", typeof(String));

            return tabla;
        }
    }
}
