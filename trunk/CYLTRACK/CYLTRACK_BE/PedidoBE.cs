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
        /// Identificador del cliente
        /// </summary>
        [DataMember]
        public String IdCliente { get; set; }

        /// <summary>
        /// Identificador Vehículo repartidor
        /// </summary>
        [DataMember]
        public String Id_Vehiculo { get; set; }


        /// <summary>
        /// Estado del pedido, (1) Activo (2) Cancelado
        /// </summary>
        [DataMember]
        public String Estado { get; set; }

        /// <summary>
        /// Detalle de la venta
        /// </summary>
        [DataMember]
        public Detalle_PedidoBE Detalle_Ped { get; set; }

        /// <summary>
        /// Lista Detalle de la venta
        /// </summary>
        [DataMember]
        public List<Detalle_PedidoBE> List_Detalle_Ped { get; set; }

    
    }
}
