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
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    public class VentaService : IVentaService
    {
        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio para registrar ventas
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>Cédula del cliente</returns>
        public long VentaCilindro(VentaBE ventas)
        {
            long resp = 0;
            VentaBL ventaCil = new VentaBL();
            resp = ventaCil.VentaCilindro(ventas);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio para consultar venta
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>Cédula del cliente</returns>
        public long ConsultarVenta(VentaBE ventas)
        {
            long resp = 0;
            VentaBL consulVenta = new VentaBL();
            resp = consulVenta.ConsultarVenta(ventas);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio para Revisar los casos especiales registrados
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>ventas</returns>
        public long RevisionCasosEspeciales(VentaBE ventas)
        {
            long resp = 0;
            VentaBL consulVenta = new VentaBL();
            resp = consulVenta.ConsultarVenta(ventas);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio registrar casos especiales
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>ventas</returns>
        public long CasosEspeciales(VentaBE ventas)
        {
            long resp = 0;
            VentaBL casosEspeciles = new VentaBL();
            resp = casosEspeciles.CasosEspeciales(ventas);
            return resp;
        }
    }
}
