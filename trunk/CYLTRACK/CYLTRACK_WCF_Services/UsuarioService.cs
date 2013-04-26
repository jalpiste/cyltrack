using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{

    /// <summary>
    /// Clase que implementa el contrato de servicio.
    /// </summary>

   public class UsuarioService : IUsuarioService
    {
        /// <summary>
        /// Encargado de recibir un usuario de los canales front de autenticación y llamar
        /// al metodo de negocio para crear un registro de usuario
        /// </summary>
      
        public long Registrar_Usuario(UsuarioBE registrar_usuario)
        {
            long resp = 0;
            UsuarioBL RegisUsu = new UsuarioBL();
            resp = RegisUsu.RegistrarUsuario(registrar_usuario);
            return resp;
        }

    }
}
