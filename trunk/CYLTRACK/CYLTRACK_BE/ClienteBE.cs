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
    /// Clase utilizada para representar la entidad Cliente
    /// </summary>
    [DataContract]
    public class ClienteBE
    {
        /// <summary>
        /// Identificador de un cliente
        /// </summary>
        [DataMember]
        public String Id_Cliente { get; set; }
        
        /// <summary>
        /// Número de documento de un cliente
        /// </summary>
        [DataMember]
        public String Cedula { get; set; }

        /// <summary>
        /// Nombres de un cliente
        /// </summary>
        [DataMember]
        public String Nombres_Cliente { get; set; }

        /// <summary>
        /// Primer apellido de un cliente
        /// </summary>
        [DataMember]
        public String Apellido_1 { get; set; }

        /// <summary>
        /// Segundo apellido de un cliente
        /// </summary>
        [DataMember]
        public String Apellido_2 { get; set; }

        /// <summary>
        /// ubicación de un cliente
        /// </summary> 
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Detalle Venta
        /// </summary> 
        [DataMember]
        public Detalle_VentaBE Detalle_Venta { get; set; }

        /// <summary>
        /// Pedido
        /// </summary>              
        [DataMember]
        public PedidoBE Pedido { get; set; }

        /// <summary>
        /// venta de un cilindro a un cliente
        /// </summary>              
        [DataMember]
        public VentaBE Venta { get; set; }

    }
}
