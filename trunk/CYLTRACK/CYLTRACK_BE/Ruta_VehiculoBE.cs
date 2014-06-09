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
    /// Clase utilizada para representar la entidad Ruta_Vehiculo
    /// </summary>
    [DataContract]
    public class Ruta_VehiculoBE
    {
        /// <summary>
        /// Identificador de la ruta del vehiculo
        /// </summary>
       [DataMember]
        public String Id_Ruta_Vehiculo { get; set; }

        /// <summary>
        /// Fecha de inicio de la ruta
        /// </summary>
       [DataMember]
        public String Fecha_Inicio { get; set; }

        /// <summary>
        /// Fecha final de la ruta
        /// </summary>
        [DataMember]
        public String Fecha_Fin { get; set; }

        /// <summary>
        /// Estado de la ruta
        /// </summary>
        [DataMember]
        public String Estado { get; set; }

        /// <summary>
        /// Lista Vehiculo
        /// </summary>
        [DataMember]
        public List<VehiculoBE> ListaVehiculo { get; set; }

        /// <summary>
        /// Vehiculo
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Ciudad
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }

    }
}
