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
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    //[ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    //public class UsuarioService : IUsuarioService
    //{
    //    /// <summary>
    //    /// Encargado de recibir el nombre de usuario de los canales front de venta y llamar
    //    /// al metodo de negocio para crear un registro del usuario
    //    /// </summary>
    //    /// <param name="usuario">Objeto de negocio Usuario</param>
    //    /// <returns>Código interno del cilindro</returns>
    //    public List<UsuarioBE> RegistrarUsuario(UsuarioBE usuario)
    //    {
    //        List<UsuarioBE> resp;
    //        UsuarioBL regUsuario = new UsuarioBL();
    //        resp = regUsuario.RegistrarUsuario(usuario);
    //        return resp;
    //    }

    //    /// <summary>
    //    /// Encargado de recibir el nombre de usuario de los canales front de venta y llamar
    //    /// al metodo de negocio para realizar la autenticación
    //    /// </summary>
    //    /// <param name="usuario">Objeto de negocio Usuario</param>
    //    /// <returns>nombre de usuario</returns>
    //    public String Autenticacion(UsuarioBE usuario)
    //    {
    //        String resp;
    //        UsuarioBL autenticarUsuario = new UsuarioBL();
    //        resp = autenticarUsuario.Autenticacion(usuario);
    //        return resp;
    //    }

    //    /// <summary>
    //    /// Encargado de recibir el nombre de usuario de los canales front de venta y llamar
    //    /// al metodo de negocio para realizar la autenticación
    //    /// </summary>
    //    /// <param name="usuario">Objeto de negocio Usuario</param>
    //    /// <returns>Nombre de usuario</returns>
    //    public String RecuperarContrasena(UsuarioBE usuario)
    //    {
    //        String resp;
    //        UsuarioBL recuperarContrasena = new UsuarioBL();
    //        resp = recuperarContrasena.RecuperarContrasena(usuario);
    //        return resp;
    //    }
    //}

}

