//using CapaDeSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    class TablaEstadoProyecto : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["codigo"] = "1";
            row["descripcion"] = "Ingresado";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["codigo"] = "2";
            row["descripcion"] = "Ingresado Aprobado";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["codigo"] = "3";
            row["descripcion"] = "Iniciado";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["codigo"] = "4";
            row["descripcion"] = "Finalizado";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["codigo"] = "5";
            row["descripcion"] = "Finalizado Aprobado";
            dataTable.Rows.Add(row);

            //SeguridadDeDatos.encriptarTabla(dataTable);

        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("EstadoProyecto");
            DataColumn cuit = tabla.Columns.Add("codigo", typeof(String));
            cuit.AllowDBNull = false;
            cuit.Unique = true;

            tabla.Columns.Add("descripcion", typeof(String));
            
            return tabla;
        }
    }

}
