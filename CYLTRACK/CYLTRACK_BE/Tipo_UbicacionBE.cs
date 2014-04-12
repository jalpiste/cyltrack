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
    /// Clase utilizada para representar la entidad Tipo de ubicación
    /// </summary>
    [DataContract]
    public class Tipo_UbicacionBE
    {
        /// <summary>
        /// Identificador de Ubicacion
        /// </summary>
        [DataMember]
        public String Id_Tipo_Ubica { get; set; }

        /// <summary>
        /// Nombre de la ubicación
        /// </summary>
        [DataMember]
        public String Nombre_Ubicacion { get; set; }

        /// <summary>
        /// Descripción de la ubicación
        /// </summary>
        [DataMember]
        public String Descripcion { get; set; }

        /// <summary>
        /// Ubicación
        /// </summary>
        [DataMember]
        public UbicacionBE Ubicacion { get; set; }

    }
}
