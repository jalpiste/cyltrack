/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Derechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class UsuarioBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public string RegistrarUsuario(UsuarioBE usuario)
        {
            string resp;
            resp = "Ok";
            return resp;   
        }

        public List<PerfilBE> consultarCargos()
        {
                List<PerfilBE> lstPerfil = new List<PerfilBE>();
                PerfilBE perfil = new PerfilBE();    
                perfil.Perfil = "Administrador";
                lstPerfil.Add(perfil);
                return lstPerfil;
        }

        public string ConsultarExistencia(string usuario)
        {
            string resp;
            resp = "Ok";
            return resp;
        }

        public string Autenticacion(UsuarioBE usuario)
        {
            string resp ;
            resp = "PrimeraVez";
            return resp;            
        }

        public string RecuperarContrasena(string usuario)
        {
            string resp = "contraseña enviada a correo electronico";
            return resp;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}

