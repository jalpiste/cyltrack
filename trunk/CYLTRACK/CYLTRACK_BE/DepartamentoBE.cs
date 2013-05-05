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
    // <summary>
    /// Clase utilizada para representar la entidad Departamento
    /// </summary>
    [DataContract]
    public class DepartamentoBE
    {
        /// <summary>
        /// Identificador de un departamento
        /// </summary>
        [DataMember]
        public String Id_Departamento { get; set; }

        /// <summary>
        /// Nombre de un departamento
        /// </summary>
        [DataMember]
        public String Nombre_Departamento { get; set; }

        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }
    }
}
