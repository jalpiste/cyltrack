/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Pedido
    /// </summary>
    public class PedidoBE
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        public String Id_Pedido { get; set; }

        /// <summary>
        /// Fecha de la realizacion del pedido 
        /// </summary>
        public String Fecha { get; set; }

        /// <summary>
        /// Observaciones referentes a la entrega del pedido
        /// </summary>
        public String Detalle { get; set; }

        /// <summary>
        /// Motivo de cancelación de un pedido
        /// </summary>
        public String Motivo_Cancel { get; set; }

        /// <summary>
        /// Información del cliente
        /// </summary>
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Ubicación del cliente
        /// </summary>
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Ciudad de la ubicación del cliente
        /// </summary>
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// Cilindro del cliente
        /// </summary>
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Vehículo repartidor
        /// </summary>
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Ruta del vehículo
        /// </summary>
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Detalle de la venta
        /// </summary>
        public Detalle_PedidoBE Detalle_Ped { get; set; }

        /// <summary>
        /// venta
        /// </summary>
        public VentaBE Venta { get; set; }
    }
}
