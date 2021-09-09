//using CapaDeSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    public class TablaEmpleado : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["legajo"] = 1;
            row["nombre"] = "Roberto";
            row["apellido"] = "Perez";
            row["dni"] = 29886116;
            row["tipo_contratacion"] = "efectivo";
            row["direccion"] = "Bulnes 433";
            row["localidad"] = "CABA";
            row["provincia"] = "CABA";
            row["telefono"] = "1154453232";
            row["celular"] = "116323232";
            row["email"] = "rperez@gmail.com";

            dataTable.Rows.Add(row);

            //SeguridadDeDatos.encriptarTabla(dataTable);

        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("Empleados");
            DataColumn id = tabla.Columns.Add("legajo", typeof(int));
            id.AllowDBNull = false;
            id.Unique = true;
            id.AutoIncrement = true;

            tabla.Columns.Add("nombre", typeof(String));
            tabla.Columns.Add("apellido", typeof(String));
            tabla.Columns.Add("dni", typeof(float));
            tabla.Columns.Add("tipo_contratacion", typeof(String));
            tabla.Columns.Add("direccion", typeof(String));
            tabla.Columns.Add("localidad", typeof(String));
            tabla.Columns.Add("provincia", typeof(String));
            tabla.Columns.Add("telefono", typeof(String));
            tabla.Columns.Add("celular", typeof(String));
            tabla.Columns.Add("email", typeof(String));


            return tabla;
        }
    }
}
