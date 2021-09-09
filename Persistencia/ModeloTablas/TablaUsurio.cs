using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    class TablaUsuario : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["usuario"] = "admin";
            row["clave"] = "$MYHASH$V1$10000$qadHSB/WdQTHkj5bkYGJMehJIgzWuRJfM+3hQz3iQHJ0Ta9G"; //admin
            row["fechaUltimoLogin"] = DateTime.Now;
            row["cantidadMaximaDeReintentos"] = 3;
            row["reintentos"] = 0;
            row["usuarioBloqueado"] = false;
            row["telefono"] = "+5491165253695";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["usuario"] = "invitado";
            row["clave"] = "$MYHASH$V1$10000$qadHSB/WdQTHkj5bkYGJMehJIgzWuRJfM+3hQz3iQHJ0Ta9G";
            row["fechaUltimoLogin"] = DateTime.Now;
            row["cantidadMaximaDeReintentos"] = 3;
            row["reintentos"] = 0;
            row["usuarioBloqueado"] = false;
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["usuario"] = "master";
            row["clave"] = "$MYHASH$V1$10000$biPFvrjSBy02kwJPy12U90NJm9n4bX2snDKUuxzbszdw3oJ9"; //Master2020.
            row["fechaUltimoLogin"] = DateTime.Now;
            row["cantidadMaximaDeReintentos"] = 3;
            row["reintentos"] = 0;
            row["usuarioBloqueado"] = false;
            row["telefono"] = "+5491165859614";
            dataTable.Rows.Add(row);

        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("Usuarios");
            DataColumn usuario = tabla.Columns.Add("usuario", typeof(String));
            usuario.AllowDBNull = false;
            usuario.Unique = true;

            tabla.Columns.Add("clave", typeof(String));
            tabla.Columns.Add("fechaUltimoLogin", typeof(DateTime));
            tabla.Columns.Add("cantidadMaximaDeReintentos", typeof(Int32));
            tabla.Columns.Add("reintentos", typeof(Int32));
            tabla.Columns.Add("usuarioBloqueado", typeof(Boolean));
            tabla.Columns.Add("telefono", typeof(String));

            return tabla;
        }
    }
}
