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
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    [ServiceBehavior(Namespace = "http://servicios.cyltrack.com.co/cyltrack/")]
    public class VentaService : IVentaService
    {
        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio para registrar ventas
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>Identificador Venta</returns>
        public long RegistrarVenta(VentaBE ventas)
        {
            long resp;
            VentaBL ventaCil = new VentaBL();
            resp = ventaCil.RegistarVenta(ventas);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir el id_venta de los canales front de venta y llamar
        /// al metodo de negocio para consultar ventas
        /// </summary>
        /// <param name="cédula cliente, codigo pedido">cedula, codigopedido</param>
        /// <returns>Identificador venta</returns>
        public long ConsultarExistenciaVenta(string ventas)
        {
            long resp;
            VentaBL ventaCil = new VentaBL();
            resp = ventaCil.ConsultarExistenciasVenta(ventas);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente o código de la venta de los canales front de venta y llamar
        /// al metodo de negocio para consultar venta
        /// </summary>
        /// <param name="cédula, codigoVenta">cédula cliente o código venta</param>
        /// <returns>Objeto de Venta</returns>
        public VentaBE ConsultarVenta(string datoConsulta)
        {
            VentaBE resp;
            VentaBL consulVenta = new VentaBL();
            resp = consulVenta.ConsultarVenta(datoConsulta);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir una ciudad de los canales front de venta y llamar
        /// al metodo de negocio para consultar cargue de vehiculo
        /// </summary>
        /// <param name="ventas">ciudad de ubicacion del cliente</param>
        /// <returns>codigos de cilindros</returns>
        public List<CilindroBE> ConsultarCarguePlaca()
        {
            List<CilindroBE> resp;
            VentaBL consultaPlaca = new VentaBL();
            resp = consultaPlaca.ConsultarCarguePlaca();
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio para Revisar los casos especiales registrados
        /// </summary>
        /// <param name="ventas">Objeto de negocio Venta</param>
        /// <returns>ventas</returns>
        public List<CasosBE> RevisionCasosEspeciales(string casos)
        {
            List<CasosBE> resp;
            VentaBL revisionCasos = new VentaBL();
            resp = revisionCasos.RevisionCasosEspeciales(casos);
            return resp;
        }

        /// <summary>
        /// Encargado de recibir la cédula del cliente de los canales front de venta y llamar
        /// al metodo de negocio registrar casos especiales
        /// </summary>
        /// <param name="casos">Objeto de negocio Venta</param>
        /// <returns>ventas</returns>
        public String CasosEspeciales(CasosBE casos)
        {
            String resp;
            VentaBL casosEspeciles = new VentaBL();
            resp = casosEspeciles.CasosEspeciales(casos);
            return resp;
        }
    }
}
