using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaCommands
{
    public class TransactionCommand : TopPersistenciaCommands
    {
        public void commit()
        {
            Modelo modelo = Modelo.getInstance();
            modelo.persistirModelo();

        }

        public void rollback()
        {
            Modelo modelo = Modelo.getInstance();
            modelo.rollback();

        }
    }
}
