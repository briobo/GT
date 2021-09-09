using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    public class TablaGrupos : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["grupo"] = "Administradores";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "Alta de datos";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "Sistemas";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "RRHH";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "Informes";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "Invitados";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "Basico";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "GrupoPrueba";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["grupo"] = "OtroGrupoPrueba";
            dataTable.Rows.Add(row);
        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("Grupos");
            DataColumn grupo = tabla.Columns.Add("grupo", typeof(String));
            grupo.AllowDBNull = false;
            grupo.Unique = true;

            return tabla;
        }
    }
}
