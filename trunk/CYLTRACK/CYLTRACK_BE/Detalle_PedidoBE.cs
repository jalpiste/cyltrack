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
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Detalle_Pedido
    /// </summary>
    [DataContract]
    public class Detalle_PedidoBE
    {

        /// <summary>
        /// Identificador del pedido
        /// </summary>
        [DataMember]
        public String Id_Pedido { get; set; }

        /// <summary>
        /// Identificador de tamaño del cilindro
        /// </summary>
        [DataMember]
        public String Id_Tamano { get; set; }

        /// <summary>
        /// Cantidad de cilindros
        /// </summary>
        [DataMember]
        public String Cantidad { get; set; }

        /// <summary>
        /// Tamaño del cilindro del pedido
        /// </summary>
        [DataMember]
        public String Tamano { get; set; }

        /// <summary>
        /// Fecha de la realizacion del pedido 
        /// </summary>
        [DataMember]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Decripcion detalle pedido
        /// </summary>
        [DataMember]
        public String Descripcion { get; set; }

    }
}
