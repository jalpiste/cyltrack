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
    /// Clase utilizada para representar la entidad Ubicación
    /// </summary>
    [DataContract]
    public class UbicacionBE
    {
        /// <summary>
        /// Identificador de la ubicacion del cilindro
        /// </summary>
        [DataMember]
        public String Id_Ubicacion { get; set; }

        /// <summary>
        /// Fecha del cambio de ubicación del cilindro
        /// </summary>
        [DataMember]
        public String fecha { get; set; }

        /// <summary>
        /// Descripción del cambio de ubicación
        /// </summary>
        [DataMember]
        public String Descripcion { get; set; }

        /// <summary>
        /// Dirección de nueva de ubicación
        /// </summary>
        [DataMember]
        public String Direccion { get; set; }

        /// <summary>
        /// Teléfono N.1 de nueva de ubicación
        /// </summary>
        [DataMember]
        public String Telefono_1 { get; set; }

        /// <summary>
        /// Teléfono N.2 de nueva de ubicación
        /// </summary>
        [DataMember]
        public String Telefono_2 { get; set; }

        /// <summary>
        /// Barrio de nueva de ubicación
        /// </summary>
        [DataMember]
        public String Barrio { get; set; }

        /// <summary>
        /// Cliente 
        /// </summary>
        [DataMember]
        public ClienteBE Cliente { get; set; }

        /// <summary>
        /// Ciudad 
        /// </summary>
        [DataMember]
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// Vehiculo 
        /// </summary>
        [DataMember]
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Tipo de Ubicacion 
        /// </summary>
        [DataMember]
        public Tipo_UbicacionBE Tipo_Ubicacion { get; set; }

       }
}
