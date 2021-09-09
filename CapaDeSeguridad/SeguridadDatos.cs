using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDeSeguridad
{
    public class SeguridadDeDatos
    {
        private static Dictionary<string, string[]> datosACifrar;

        private static void initialize()
        {
            datosACifrar = new Dictionary<string, string[]>();

            datosACifrar["Empresa"] = new string[]
                                        { "razonSocial","direccion","localidad","provincia","telefono","celular","email"};
        }


        private static void cifrarDatosDe(DataTable table, DataRow row)
        {
            if (datosACifrar == null) initialize();
            if (!datosACifrar.ContainsKey(table.TableName)) return;

            string[] columnas = datosACifrar[table.TableName];
            foreach (String columna in columnas)
            {
                row[columna] = CifradoBidireccional.Encrypt(row[columna].ToString());
            }
        }


        private static void descrifrarDatosDe(DataTable table, DataRow row)
        {
            if (datosACifrar == null) initialize();
            if (!datosACifrar.ContainsKey(table.TableName)) return;

            string[] columnas = datosACifrar[table.TableName];
            foreach (String columna in columnas)
            {
                row[columna] = CifradoBidireccional.Decrypt(row[columna].ToString());
            }

            return;
        }

        public static void desencriptarTabla(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                descrifrarDatosDe(table, row);
            }
        }

        public static void encriptarTabla(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                cifrarDatosDe(table, row);
            }
        }
    }
}
