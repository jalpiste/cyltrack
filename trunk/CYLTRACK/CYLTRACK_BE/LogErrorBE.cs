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
    /// Clase utilizada para representar la entidad LogError
    /// </summary>
    [DataContract]
    public class LogErrorBE
    {
        /// <summary>
        /// Identificador del Error
        /// </summary>
        [DataMember]
        public String Id_Error { get; set; }

        /// <summary>
        /// Nombre del Error
        /// </summary>
        [DataMember]
        public String Error { get; set; }

        /// <summary>
        /// Tipo de error
        /// </summary>
        [DataMember]
        public String Tipo_Error { get; set; }

    }
}
