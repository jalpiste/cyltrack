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
    public class CilindroService : ICilindroService
    {
        /// <summary>
        /// Encargado de recibir un cilindro de los canales front de venta y llamar
        /// al metodo de negocio para crear un registro de cilindro
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Código interno del cilindro</returns>
        public long CrearCilindro(CilindroBE cilindro)
        {
            long resp = 0;
            CilindroBL crearCil = new CilindroBL();
            resp = crearCil.CrearCilindro(cilindro);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir el codigo_Cilindro de los canales front de venta y llamar
        /// al metodo de negocio para consultar el registro del cilindro
        /// </summary>
        /// <param name="codigo_Cilindro">Objeto de negocio cilindro</param>
        /// <returns>Datos Cilindro</returns>
        public long ConsultarCilindro(CilindroBE codigo_Cilindro)
        {
            long resp = 1;
            return resp;
        }

    }
}
