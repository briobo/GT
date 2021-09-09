using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente : TopBLL
    {
        public List<EBL.Cliente> obtenerTodo()
        {
            Mapper.Cliente mapper = new Mapper.Cliente();
            return mapper.obtenerTodo();
        }

        public void grabar(string cuit, string razonSocial, string categoria, string direccion, string localidad, string provincia, string telefono, string celular, string email)
        {
            EBL.Cliente obj = new EBL.Cliente(cuit, razonSocial, categoria, direccion, localidad, provincia, telefono, celular, email);
            grabar(obj);
        }

        private void grabar(EBL.Cliente obj)
        {
            Mapper.Cliente mapper = new Mapper.Cliente();
            mapper.grabar(obj);
        }

        public void eliminar(EBL.Cliente obj)
        {
            Mapper.Cliente mapper = new Mapper.Cliente();
            mapper.eliminar(obj);
        }

        public EBL.Cliente obtener(string valor)
        {
            Mapper.Cliente mapper = new Mapper.Cliente();
            return mapper.obtener(valor);
        }

        public List<EBL.Cliente> obtenerConFiltro(string condicionDeFiltro)
        {
            List<EBL.Cliente> empresas = this.obtenerTodo();
            List<EBL.Cliente> result = new List<EBL.Cliente>();
            result.AddRange(empresas.Where(e => e.RazonSocial.ToUpper().Contains(condicionDeFiltro.ToUpper())));

            return result;
        }
        /*
        public void puedoEliminarEmpresa(EBL.Cliente obj)
        {
            BLL.Documento documento = new BLL.Documento();
            List<EBL.Documento> facturas = documento.obtenerFacturasDeEmpresa(obj);
            if (facturas.Count > 0) throw new DatosInvalidosException("No puede eliminar este cliente dado que tiene facturas asociadas");

        }*/
    }
}
