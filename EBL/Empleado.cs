using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public abstract class Empleado : TopEBL
    {
        //private List<EBL.Item> items;
        private float legajo;
        private string nombre;
        private string apellido;
        private float dni;
        private string tipo_contratacion;
        private string direccion;
        private string localidad;
        private string provincia;
        private string telefono;
        private string celular;
        private string email;
    
        public Empleado()
        {
        }

        public Empleado(float legajo, string nombre, string apellido, float dni, string tipo_contratacion, string direccion,  string localidad, string provincia, string telefono, string celular, string email)
        {
            this.legajo = legajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.tipo_contratacion = tipo_contratacion;
            this.direccion = direccion;
            this.localidad = localidad;
            this.provincia = provincia;
            this.telefono = telefono;
            this.celular = celular;
            this.email = email;

        }

        public float Legajo { get => legajo; }
        public string Nombre { get => nombre; }
        public string Apellido { get => apellido; }
        public float Dni { get => dni; }
        public string Tipo_contratacion { get => tipo_contratacion; }
        public string Direccion { get => direccion; }
        public string Localidad { get => localidad; }
        public string Provincia { get => provincia; }
        public string Telefono { get => telefono; }
        public string Celular { get => celular; }
        public string Email { get => email; }
    }
}
