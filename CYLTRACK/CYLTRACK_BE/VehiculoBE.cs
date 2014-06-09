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
    /// Clase utilizada para representar la entidad vehiculo
    /// </summary>
    [DataContract]
    public class VehiculoBE
    {
        /// <summary>
        /// Identificador del Vehículo 
        /// </summary>
        [DataMember]
        public String Id_Vehiculo { get; set; }

        /// <summary>
        /// Placa del Vehículo (placa)
        /// </summary>
        [DataMember]
        public String Placa { get; set; }

        /// <summary>
        /// Estado del Vehículo 
        /// </summary>
        [DataMember]
        public String Estado { get; set; }

        /// <summary>
        /// Marca del Vehículo 
        /// </summary>
        [DataMember]
        public String Marca { get; set; }

        /// <summary>
        /// Cilindraje del Vehículo 
        /// </summary>
        [DataMember]
        public String Cilindraje { get; set; }

        /// <summary>
        /// Modelo del Vehículo 
        /// </summary>
        [DataMember]
        public String Modelo { get; set; }

        /// <summary>
        /// Número de motor del Vehículo 
        /// </summary>

        [DataMember]
        public String Motor { get; set; }

        /// <summary>
        /// Número de chasis del Vehículo 
        /// </summary>
        [DataMember]
        public String Chasis { get; set; }

        /// <summary>
        /// Ruta del Vehículo 
        /// </summary>
        [DataMember]
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Datos conductor
        /// </summary>
        [DataMember]
        public ConductorBE Conductor { get; set; }

        /// <summary>
        /// Datos contratista
        /// </summary>
        [DataMember]
        public ContratistaBE Contratista { get; set; }

        /// <summary>
        /// Identificador Ubicación
        /// </summary>
        [DataMember]
        public String Id_Ubicacion { get; set; }


    }
}
