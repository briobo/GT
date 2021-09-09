using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public class Cliente : TopEBL
    {
        private string razonSocial;
        private string cuit;
        private string categoria;
        private string direccion;
        private string localidad;
        private string provincia;
        private string telefono;
        private string celular;
        private string email;

        public Cliente()
        {
        }

        public Cliente(string cuit, string razonSocial, string categoria, string direccion, string localidad, string provincia, string telefono, string celular, string email)
        {
            this.razonSocial = razonSocial;
            this.cuit = cuit;
            this.categoria = categoria;
            this.direccion = direccion;
            this.localidad = localidad;
            this.provincia = provincia;
            this.telefono = telefono;
            this.celular = celular;
            this.email = email;

        }

        public string RazonSocial { get => razonSocial; }
        public string Cuit { get => cuit; }
        public string Categoria { get => categoria; }
        public string Direccion { get => direccion; }
        public string Localidad { get => localidad; }
        public string Provincia { get => provincia; }
        public string Telefono { get => telefono; }
        public string Celular { get => celular; }
        public string Email { get => email; }
    }
}
