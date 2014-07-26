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
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
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
            long resp;
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
        public CilindroBE ConsultarCilindro(string cilindro)
        {
            CilindroBE resp;
            CilindroBL consultarCil = new CilindroBL();
            resp = consultarCil.ConsultarCilindro(cilindro);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la ubicacion de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de cilindros en dicha ubicacion
        /// </summary>
        /// <param name="ubicacionCil">Objeto de negocio cilindro</param>
        /// <returns>Códigos de Cilindros</returns>
        public List<Ubicacion_CilindroBE> ConsultarCilUbicacion(Ubicacion_CilindroBE ubicacionCil)
        {
            List<Ubicacion_CilindroBE> resp;
            CilindroBL consultaUbicacion = new CilindroBL();
            resp = consultaUbicacion.ConsultarCilUbicacion(ubicacionCil);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir los objetos de cilindro de los canales front de venta y llamar
        /// al metodo de negocio para guardar las nuevas ubicaciones 
        /// </summary>
        /// <param name="Objeto cilindro">Objeto de negocio cilindro</param>
        /// <returns>respuesta</returns>
        public long ModificarUbicaCilindro(CilindroBE cilindros)
        {
            long resp;
            CilindroBL consultaUbicacion = new CilindroBL();
            resp = consultaUbicacion.ModificarUbicacionCilindro(cilindros);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la ubicacion de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de existencia de cilindros
        /// </summary>
        /// <param name="ubicacion">Objeto de negocio cilindro</param>
        /// <returns>codigo</returns>
        public long ConsultarExistenciaCilindro(string cilindro)
        {
            long resp;
            CilindroBL consultaExistenciaCilindro = new CilindroBL();
            resp = consultaExistenciaCilindro.ConsultarExistenciaCilindro(cilindro);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la ubicacion de los canales front de venta y llamar
        /// al metodo de negocio para la consulta de existencia de codigos fabricantes
        /// </summary>
        /// <param name="ubicacion">Objeto de negocio cilindro</param>
        /// <returns>codigo</returns>
        public long consultaCodigoFabricante(string codigoFabricante)
        {
            long resp;
            CilindroBL consultaExistenciaFabricante = new CilindroBL();
            resp = consultaExistenciaFabricante.consultaCodigoFabricante(codigoFabricante);
            return resp;
        }
    }
}