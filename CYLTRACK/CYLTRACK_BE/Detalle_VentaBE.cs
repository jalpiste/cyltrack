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
    /// Clase utilizada para representar la entidad Detalle_Venta
    /// </summary>
    [DataContract]
    public class Detalle_VentaBE
    {
        /// <summary>
        /// Identificador de un detalle de venta
        /// </summary>
        [DataMember]
        public String Id_Detalle_Venta { get; set; }

        /// <summary>
        /// Tamaño del cilindro
        /// </summary>
        [DataMember]
        public String Tamano { get; set; }

        /// <summary>
        /// Tipo de Cilindro
        /// </summary>
        [DataMember]
        public String Tipo_Cilindro { get; set; }

        /// <summary>
        /// Identificador del cilindro de entrada, es decir, el cilindro que se recibe del cliente
        /// </summary>
        [DataMember]
        public String Id_Cilindro_Entrada { get; set; }

        /// <summary>
        /// Identificador del cilindro de salida, es decir, el cilindro que se entrega al cliente
        /// </summary>
        [DataMember]
        public String Id_Cilindro_Salida { get; set; }

        /// <summary>
        /// Casos especiales
        /// </summary>
        [DataMember]
        public CasosBE Casos_Especiales { get; set; }

        /// <summary>
        /// Identificador de la Venta
        /// </summary>
        [DataMember]
        public String IdVenta { get; set; }

        /// <summary>
        /// Identificador del Vehiculo
        /// </summary>
        [DataMember]
        public String Id_Vehiculo { get; set; }

        /// <summary>
        /// Identificador de la ubicacion del cliente
        /// </summary>
        [DataMember]
        public String Id_Ubicacion { get; set; }
        
    }
}
