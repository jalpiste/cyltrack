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
        public List<UsuarioBE> RegistrarUsuario(UsuarioBE usuario)
        {
            UsuarioBE user = new UsuarioBE();
            List<UsuarioBE> resp = new List<UsuarioBE>();
            PerfilBE per = new PerfilBE();
            per.Perfil= "Jefe de Plataforma";
            per.Perfil= "Vendedor";
            per.Perfil= "Administrador";
            user.Perfil = per;
            resp.Add(user);

        return resp;
        }

        public String Autenticacion(UsuarioBE usuario)
        {
            String resp ;
            resp = "true";
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

