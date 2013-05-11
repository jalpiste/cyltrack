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
        public String RegistrarUsuario(UsuarioBE usuario)
        {
            String resp = "usuario creado";
            return resp;
        }

        public String Autenticacion(UsuarioBE usuario)
        {
            String resp="Ok";
            return resp;
        }

        public String RecuperarContrasena(UsuarioBE usuario)
        {
            String resp = "contraseña enviada a correo electronico";
            return resp;
        }

        #endregion
        #region Metodos privados
        #endregion
    }
}

