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
    public class SelectCommand : TopPersistenciaCommands
    {
        public DataRow[] buscar(string nombreTabla, string campo, string valor)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);
            DataColumn column = tabla.Columns[campo];
            string type = (column.DataType.Name).ToUpper();
            DataRow[] rows;
            if (type.Equals("STRING"))
                rows = tabla.Select(campo + " = '" + valor + "'");
            else
                rows = tabla.Select(campo + " = " + valor);

            return rows;

        }

        public DataRow obtenerUno(string nombreTabla, string campo, string valor)
        {
            DataRow[] rows = buscar(nombreTabla, campo, valor);

            if (rows.Count() != 1) return null;

            DataRow result = rows[0];

            return result;

        }

        public DataRow[] obtenerTodos(string nombreTabla)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);

            DataRow[] rows = tabla.Select();

            return rows;

        }

        public int obtenerMaximo(string nombreTabla, string campo)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);

            int max = Convert.ToInt32(tabla.AsEnumerable()
                        .Max(row => row[campo]));

            return max;
        }

        public DataRow obtenerUno(string nombreTabla, Dictionary<string, string> campoValor)
        {
            Modelo modelo = Modelo.getInstance();
            DataTable tabla = modelo.obtenerTabla(nombreTabla);
            string busqueda = "";
            foreach (KeyValuePair<string, string> kv in campoValor)
            {
                DataColumn column = tabla.Columns[kv.Key];
                string type = (column.DataType.Name).ToUpper();
                if (type.Equals("STRING"))
                    busqueda = busqueda + kv.Key + "='" + kv.Value + "' AND ";
                else
                    busqueda = busqueda + kv.Key + "=" + kv.Value + " AND ";
            }
            busqueda = busqueda.Remove(busqueda.Length - 4);

            DataRow[] rows;
            rows = tabla.Select(busqueda);

            if (rows.Length > 0) return rows[0];

            return null;
        }
    }
}
