using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.ModeloTablas
{
    public class Tabla
    {
        public static IEnumerable<Type> clases()
        {
            var assembly = typeof(Tabla).Assembly;
            IEnumerable<Type> types = assembly.GetTypes().Where(t => t.BaseType == typeof(Tabla));

            return types;
        }
    }
}
