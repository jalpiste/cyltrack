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
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class UsuarioBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public long RegistrarUsuario(UsuarioBE usuario)
        {
            UsuarioDL user = new UsuarioDL();
            long resp = 0;
            try
            {
                resp = user.CrearUsuario(usuario);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

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

        public long ConsultarExistencia(string usuario)
        {
            UsuarioDL user = new UsuarioDL();
            long resp = 0;
            try
            {
                resp = user.ConsultarExistenciaUsuarios(usuario);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

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

