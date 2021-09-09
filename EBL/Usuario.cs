using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBL
{
    public class Usuario : TopEBL
    {
        private string usuario;
        private string password;
        private DateTime ultimoLogin;
        private int cantidadMaximaDeReintentos;
        private int reintentos;
        private bool usuarioBloqueado;
        private List<Grupo> grupos;
        private string telefono;

        public Usuario(string usuario, string password, DateTime ultimoLogin, int cantidadMaximaDeReintentos, int reintentos, bool usuarioBloqueado, List<Grupo> grupos, string telefono)
        {
            this.usuario = usuario;
            this.password = password;
            this.ultimoLogin = ultimoLogin;
            this.cantidadMaximaDeReintentos = cantidadMaximaDeReintentos;
            this.reintentos = reintentos;
            this.usuarioBloqueado = usuarioBloqueado;
            this.grupos = grupos;
            this.telefono = telefono;
        }

        public Usuario()
        {
            this.grupos = new List<Grupo>();
        }
        public string Telefono()
        {
            return this.telefono;
        }
        public List<Grupo> getGrupos()
        {
            return grupos;
        }

        public void resetearIntentosFallidos()
        {
            this.setIntentosFallidos(0);
        }
        public void desBloquearUsuario()
        {
            usuarioBloqueado = false;
        }

        public void bloquearUsuario()
        {
            usuarioBloqueado = true;
        }

        public bool superoUmbralIntentosFallidos()
        {
            return reintentos >= cantidadMaximaDeReintentos;
        }

        public void sumarIntentoFallido()
        {
            this.reintentos++;
        }

        public bool estaBloqueado()
        {
            return this.usuarioBloqueado;
        }

        public void setIntentosFallidos(int intentosFallidos)
        {
            this.reintentos = intentosFallidos;
        }

        public void setFechaUltimoLogin(DateTime fecha)
        {
            this.ultimoLogin = fecha;
        }

        public string getUsuario()
        {
            return usuario;
        }

        public string getPassword()
        {
            return this.password;
        }

        public DateTime getUltimoLogin()
        {
            return this.ultimoLogin;
        }

        public int getCantidadMaximaReintentos()
        {
            return cantidadMaximaDeReintentos;
        }

        public int getReintentos()
        {
            return reintentos;
        }

        public bool getUsuarioBloqueado()
        {
            return usuarioBloqueado;
        }

        public void setPassword(string clave)
        {
            this.password = clave;
        }
    }
}
