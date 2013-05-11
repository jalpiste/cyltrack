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
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Pedido
    /// </summary>
    [DataContract]
    public class PedidoBE
    {
        /// <summary>
        /// Identificador del pedido
        /// </summary>
        [DataMember]
        public String Id_Pedido { get; set; }

        /// <summary>
        /// Fecha de la realizacion del pedido 
        /// </summary>
        [DataMember]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Observaciones referentes a la entrega del pedido
        /// </summary>
        [DataMember]
        public String Detalle { get; set; }

        /// <summary>
        /// Motivo de cancelación de un pedido
        /// </summary>
        [DataMember]
        public String Motivo_Cancel { get; set; }

        /// <summary>
        /// Información del cliente
        /// </summary>
        [DataMember]
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Ubicación del cliente
        /// </summary>
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Ciudad de la ubicación del cliente
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// Cilindro del cliente
        /// </summary>
        [DataMember]
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Vehículo repartidor
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Ruta del vehículo
        /// </summary>
        [DataMember]
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Detalle de la venta
        /// </summary>
        [DataMember]
        public Detalle_PedidoBE Detalle_Ped { get; set; }

        /// <summary>
        /// venta
        /// </summary>
        [DataMember]
        public VentaBE Venta { get; set; }
    }
}
