using CapaDeSeguridad;
using PersistenciaCommands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class Cliente : TopMapper
    {

        public List<EBL.Cliente> obtenerTodo()
        {
            List<EBL.Cliente> objs = new List<EBL.Cliente>();
            SelectCommand select = new SelectCommand();
            DataRow[] rows = select.obtenerTodos("Cliente");
            foreach (DataRow item in rows)
            {
                EBL.Cliente obj = CrearObjeto(item);

                objs.Add(obj);
            }

            return objs;

        }

        private EBL.Cliente CrearObjeto(DataRow item)
        {
            return new EBL.Cliente(item["cuit"].ToString(), item["razonSocial"].ToString(), item["categoria"].ToString(), item["direccion"].ToString(), item["localidad"].ToString(), item["provincia"].ToString(), item["telefono"].ToString(), item["celular"].ToString(), item["email"].ToString());
        }

        public void grabar(EBL.Cliente unaEmpresa)
        {
            bool insertNewRow = false;
            SelectCommand select = new SelectCommand();
            DataRow row = select.obtenerUno("Cliente", "cuit", unaEmpresa.Cuit);
            DataRow rowResult;

            if (row == null) //insertar
            {
                NewRowCommand rowCommand = new NewRowCommand();
                DataRow nuevaRow = rowCommand.obtenerNuevaRow("Cliente");
                rowResult = nuevaRow;
                insertNewRow = true;
            }
            else //modificar
            {
                rowResult = row;
            }

            rowResult["cuit"] = unaEmpresa.Cuit;
            rowResult["razonSocial"] = unaEmpresa.RazonSocial;
            rowResult["categoria"] = unaEmpresa.Categoria;
            rowResult["direccion"] = unaEmpresa.Direccion;
            rowResult["localidad"] = unaEmpresa.Localidad;
            rowResult["provincia"] = unaEmpresa.Provincia;
            rowResult["telefono"] = unaEmpresa.Telefono;
            rowResult["celular"] = unaEmpresa.Celular;
            rowResult["email"] = unaEmpresa.Email;

            if (insertNewRow)
            {
                InsertCommand insertCommand = new InsertCommand();
                insertCommand.insertar("Empresa", rowResult);
            }

            TransactionCommand transaction = new TransactionCommand();
            transaction.commit();

        }

        public void eliminar(EBL.Cliente obj)
        {

            string nombreTabla = "Cliente";
            DeleteCommand deleteCommand = new DeleteCommand();
            deleteCommand.eliminar(nombreTabla, "cuit", obj.Cuit);

            TransactionCommand tr = new TransactionCommand();
            tr.commit();
        }

        public EBL.Cliente obtener(string valor)
        {
            SelectCommand select = new SelectCommand();
            DataRow item = select.obtenerUno("Empresa", "cuit", valor);

            if (item == null) return null;

            EBL.Cliente result = CrearObjeto(item);

            return result;
        }
    }
}
