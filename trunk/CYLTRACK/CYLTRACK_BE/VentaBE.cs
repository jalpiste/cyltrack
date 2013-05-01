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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad venta
    /// </summary>
    public class VentaBE
    {
        /// <summary>
        /// Identificador de venta
        /// </summary>
        public String Id_Venta { get; set; }

        /// <summary>
        /// Observaciones de la venta
        /// </summary>
        public String Observaciones { get; set; }

        /// <summary>
        /// Fecha de la venta
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Detalle de la venta
        /// </summary>
        public Detalle_VentaBE Detalle_Venta { get; set; }

        /// <summary>
        /// Datos del vehículo 
        /// </summary>
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Cliente 
        /// </summary>
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Contratista
        /// </summary>
        public ContratistaBE Contratista { get; set; }

        /// <summary>
        /// Ubicación
        /// </summary>
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Cilindro
        /// </summary>
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Pedido
        /// </summary>
        public PedidoBE Pedido { get; set; }

        /// <summary>
        /// Casos Especiales
        /// </summary>
        public CasosBE Casos_Especiales { get; set; }

        /// <summary>
        /// Reportes
        /// </summary>
        public ReportesBE Reportes { get; set; }



    }
}
