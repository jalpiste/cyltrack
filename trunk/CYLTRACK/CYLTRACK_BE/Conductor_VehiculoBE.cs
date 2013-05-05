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
    /// Clase utilizada para representar la entidad Conductor_Vehículo
    /// </summary>
    [DataContract]
    public class Conductor_VehiculoBE
    {
        /// <summary>
        /// Identificador de conductor_vehículo
        /// </summary>
        [DataMember]
        public String Id_Conductor_Vehiculo { get; set; }

        /// <summary>
        /// fecha de inicio de la ruta en un vehículo
        /// </summary>
        [DataMember]
        public DateTime  Fecha_Inicio { get; set; }

        /// <summary>
        /// fecha de finalización de la ruta en un vehículo
        /// </summary>
        [DataMember]
        public DateTime Fecha_Fin { get; set; }

        /// <summary>
        /// Vehiculo del conductor
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Conductor del vehículo
        /// </summary>
        [DataMember]
        public ConductorBE Conductor { get; set; }
    }
}
