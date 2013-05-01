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
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    /// <summary>
    /// Clase creada para implementar el contrato de servicio de la interfaz.
    /// </summary>
    public class CilindroService : ICilindroService
    {
        /// <summary>
        /// Encargado de recibir un cilindro de los canales front de venta y llamar
        /// al metodo de negocio para crear un registro de cilindro
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Código interno del cilindro</returns>
        public long RegistrarCilindro(CilindroBE cilindro)
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
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Código interno del Cilindro</returns>
        public long ConsultarCilindro(CilindroBE cilindro)
        {
            long resp = 0;
            CilindroBL consultarCil = new CilindroBL();
            resp = consultarCil.ConsultarCilindro(cilindro);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir el codigo_Cilindro de los canales front de venta y llamar
        /// al metodo de negocio para asignar la ubicación del cilindro
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Código interno del Cilindro</returns>
        public long AsignarUbicacion(CilindroBE cilindro)
        {
            long resp = 0;
            CilindroBL asignarUbica = new CilindroBL();
            resp = asignarUbica.AsignarUbicacion(cilindro);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir el codigo_Cilindro de los canales front de venta y llamar
        /// al metodo de negocio para el cargue y descargue de cilindro
        /// </summary>
        /// <param name="cilindro">Objeto de negocio cilindro</param>
        /// <returns>Código interno del Cilindro</returns>
        public long CargueyDescargueCilindro(CilindroBE cilindro)
        {
            long resp = 0;
            CilindroBL cargueyDescargue = new CilindroBL();
            resp = cargueyDescargue.CargueyDescargueCilindro(cilindro);
            return resp;
        }

    }
}