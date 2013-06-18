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
        /// Código del cilindro actual del cliente
        /// </summary>
        [DataMember]
        public String Cod_Cil_Actual { get; set; }

        /// <summary>
        /// Código del cilindro nuevo de venta al cliente
        /// </summary>
        [DataMember]
        public String Cod_Cil_Nuevo { get; set; }

        /// <summary>
        /// Cilindro entregado
        /// </summary>
        [DataMember]
        public CilindroBE Cilindro { get; set; }

        /// <summary>
        /// Cilindro entregado como prestamo al cliente
        /// </summary>
        [DataMember]
        public String Id_Cilindro_Entrada { get; set; }

        /// <summary>
        /// Cilindro recibido como prestamo al cliente
        /// </summary>
        [DataMember]
        public String Id_Cilindro_Salida { get; set; }

        /// <summary>
        /// Casos especiales
        /// </summary>
        [DataMember]
        public CasosBE Casos_Especiales { get; set; }

        /// <summary>
        /// Venta
        /// </summary>
        [DataMember]
        public VentaBE Venta { get; set; }


    }
}
