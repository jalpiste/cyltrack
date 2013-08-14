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
        public UsuarioBE RegistrarUsuario(UsuarioBE usuario)
        {
            UsuarioBE resp = new UsuarioBE();
           for (int i = 0; i < 4; i++) 
            {
                UsuarioBE user = new UsuarioBE();
                PerfilBE per = new PerfilBE();
                per.Perfil = "Opciones";
                user.Perfil[i] = per;
                resp = user;                            
            }
               return resp;
        }

        public string ConsultarExistencia(string usuario)
        {
            string resp;
            resp = "Ok";
            return resp;
        }

        public bool Autenticacion(UsuarioBE usuario)
        {
            bool resp ;
            resp = true;
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

