using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    class TablaGrupoModulos : Tabla, TablaInterface
    {
        public void insertarValoresPorDefecto(DataTable dataTable)
        {
            agregarRelacion(dataTable, "Administradores", "Administrador", "111");
            agregarRelacion(dataTable, "Administradores", "Usuarios", "111");
            agregarRelacion(dataTable, "Administradores", "Grupos", "111");
            agregarRelacion(dataTable, "Administradores", "Copias de seguridad", "111");

            agregarRelacion(dataTable, "Basico", "Sesion", "111");
            agregarRelacion(dataTable, "Basico", "Perfil", "111");
            agregarRelacion(dataTable, "Basico", "Cerrar sesion", "111");

            agregarRelacion(dataTable, "Alta de datos", "Cliente", "111");
            agregarRelacion(dataTable, "Alta de datos", "Nuevo cliente", "111");
            agregarRelacion(dataTable, "Alta de datos", "Talentos", "111");
            agregarRelacion(dataTable, "Alta de datos", "Nuevo talento", "111");

            agregarRelacion(dataTable, "Sistemas", "Proyecto", "111");
            agregarRelacion(dataTable, "Sistemas", "Nuevo proyecto", "111");
            agregarRelacion(dataTable, "Sistemas", "listado proyectos", "111");

            agregarRelacion(dataTable, "Informes", "Informes", "111");
            agregarRelacion(dataTable, "Informes", "Dashboard", "111");

            agregarRelacion(dataTable, "RRHH", "Solicitudes", "111");
            agregarRelacion(dataTable, "RRHH", "Abiertas", "111");
            agregarRelacion(dataTable, "RRHH", "Cerradas", "111");
            agregarRelacion(dataTable, "RRHH", "Listado de clientes", "111");
            agregarRelacion(dataTable, "RRHH", "Listado de clientes", "111");


        }

        private static void agregarRelacion(DataTable dataTable, string grupo, string modulo, string permisos)
        {
            DataRow row = dataTable.NewRow();
            row["grupo"] = grupo;
            row["modulo"] = modulo;
            row["permisos"] = permisos;
            dataTable.Rows.Add(row);
        }

        public DataTable obtenerTabla()
        {
            DataTable tabla = new DataTable("GrupoModulos");
            tabla.Columns.Add("grupo", typeof(String));
            tabla.Columns.Add("modulo", typeof(String));
            tabla.Columns.Add("permisos", typeof(String));

            return tabla;
        }
    }
}
