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
            UsuarioBE user = new UsuarioBE();
            
            for (int i = 0; i < 4; i++) 
            {
                PerfilBE per = new PerfilBE()
                {
                   Perfil= "Opciones" 
                };
                user.Perfil[i] = per;                
            }
               return user;
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

