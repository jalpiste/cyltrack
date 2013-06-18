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
        /// Número de cédula del propietario del Vehículo 
        /// </summary>
        [DataMember]
        public String Ced_Prop { get; set; }

        /// <summary>
        /// Nombres del propietario del Vehículo 
        /// </summary>
        [DataMember]
        public String Nombres_Prop { get; set; }

        /// <summary>
        /// Primer apellido del propietario del Vehículo 
        /// </summary>
        [DataMember]
        public String Apellido_1_Prop { get; set; }

        /// <summary>
        /// Segundo apellido del propietario del Vehículo 
        /// </summary>
        [DataMember]
        public String Apellido_2_Prop { get; set; }

        /// <summary>
        /// Ruta del Vehículo 
        /// </summary>
        [DataMember]
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Conductor asignado al Vehículo 
        /// </summary>
        [DataMember]
        public Conductor_VehiculoBE Conductor_Vehiculo { get; set; }

        /// <summary>
        /// Datos conductor
        /// </summary>
        [DataMember]
        public ConductorBE Conductor { get; set; }
    }
}
