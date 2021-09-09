//using CapaDeSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    class TablaCliente : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            DataRow row = dataTable.NewRow();
            row["cuit"] = "20116045800";
            row["razonSocial"] = "Interbanking SA";
            row["categoria"] = "Responsable Inscripto";
            row["direccion"] = "san juan 3232";
            row["localidad"] = "CABA";
            row["provincia"] = "CABA";
            row["telefono"] = "11544556445";
            row["celular"] = "116859552";
            row["email"] = "rrhh@interbanking.ar";
            dataTable.Rows.Add(row);

            row = dataTable.NewRow();
            row["cuit"] = "20116045810";
            row["razonSocial"] = "Prisma MP";
            row["categoria"] = "Resposable Inscripto";
            row["direccion"] = "Manuel Castro 433";
            row["localidad"] = "CABA";
            row["provincia"] = "CABA";
            row["telefono"] = "1154453232";
            row["celular"] = "116323232";
            row["email"] = "administracion@primamp.com.ar";
            dataTable.Rows.Add(row);


            //SeguridadDeDatos.encriptarTabla(dataTable);

        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("Empleado");
            DataColumn cuit = tabla.Columns.Add("cuit", typeof(String));
            cuit.AllowDBNull = false;
            cuit.Unique = true;

            tabla.Columns.Add("razonSocial", typeof(String));
            tabla.Columns.Add("categoria", typeof(String));
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
