using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public class TopEBL
    {
        public float normalizarNumero(float numero)
        {
            return (float)Math.Round(numero * 100f) / 100f;
        }
    }
}
