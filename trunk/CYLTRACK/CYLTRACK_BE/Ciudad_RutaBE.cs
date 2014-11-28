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
    /// Clase utilizada para representar la entidad Ciudad_Ruta
    /// </summary>
    [DataContract]
    public class Ciudad_RutaBE
    {
        /// <summary>
        /// Identificador de la Ciudad_Ruta
        /// </summary>
        [DataMember]
        public String Id_Ciudad_Ruta { get; set; }

        /// <summary>
        /// Identificador Ruta
        /// </summary>
        [DataMember]
        public String Id_Ciudad { get; set; }

        /// <summary>
        /// Identificador Ruta
        /// </summary>
        [DataMember]
        public String Id_Ruta { get; set; }


    }
}
