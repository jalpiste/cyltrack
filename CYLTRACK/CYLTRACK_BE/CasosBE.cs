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
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Casos
    /// </summary>
    [DataContract]
    public class CasosBE
    {
        /// <summary>
        /// Identificador del Caso
        /// </summary>
        [DataMember]
        public String Id_Casos { get; set; }

        /// <summary>
        /// Observaciones del caso
        /// </summary>
        [DataMember]
        public String Observaciones { get; set; }

        /// <summary>
        /// Tipo de caso
        /// </summary>
        [DataMember]
        public Tipo_CasoBE Tipo_Caso { get; set; }
      }
}
