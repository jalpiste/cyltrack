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
    /// Clase utilizada para representar la entidad Ruta
    /// </summary>
    [DataContract]
    public class RutaBE
    {
        /// <summary>
        /// Nombre de la ruta 
        /// </summary>
        [DataMember]
        public String Nombre_Ruta { get; set; }

        /// <summary>
        /// Nombre de la ciudad de la ruta
        /// </summary>
        [DataMember]
        public Ciudad_RutaBE Ciudad_Ruta { get; set; }

        /// <summary>
        /// Nombre del departamento de la ruta
        /// </summary>
        [DataMember]
        public DepartamentoBE Departamento { get; set; }

    }
}
