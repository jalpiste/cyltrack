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
        /// Ruta vehiculo
        /// </summary>
        [DataMember]
        public Ruta_VehiculoBE Ruta_Vehiculo { get; set; }

        /// <summary>
        /// Ciudad Ruta
        /// </summary>
        [DataMember]
        public Ciudad_RutaBE Ciudad_Ruta { get; set; }

        /// <summary>
        /// Ciudades
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }

    }
}
