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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad vehiculo
    /// </summary>
    public class VehiculoBE
    {
        /// <summary>
        /// Identificador del Vehículo 
        /// </summary>
        public String Id_Vehiculo { get; set; }

        /// <summary>
        /// Placa del Vehículo (placa)
        /// </summary>
        public String Placa { get; set; }

        /// <summary>
        /// Estado del Vehículo 
        /// </summary>
        public String Estado { get; set; }

        /// <summary>
        /// Marca del Vehículo 
        /// </summary>
        public String Marca { get; set; }

        /// <summary>
        /// Cilindraje del Vehículo 
        /// </summary>
        public String Cilindraje { get; set; }

        /// <summary>
        /// Modelo del Vehículo 
        /// </summary>
        public String Modelo { get; set; }

        /// <summary>
        /// Número de motor del Vehículo 
        /// </summary>
        public String Motor { get; set; }

        /// <summary>
        /// Número de chasis del Vehículo 
        /// </summary>
        public String Chasis { get; set; }

        /// <summary>
        /// Número de cédula del propietario del Vehículo 
        /// </summary>
        public String Ced_Prop { get; set; }

        /// <summary>
        /// Nombres del propietario del Vehículo 
        /// </summary>
        public String Nombres_Prop { get; set; }

        /// <summary>
        /// Primer apellido del propietario del Vehículo 
        /// </summary>
        public String Apellido_1_Prop { get; set; }

        /// <summary>
        /// Segundo apellido del propietario del Vehículo 
        /// </summary>
        public String Apellido_2_Prop { get; set; }

        /// <summary>
        /// Ruta del Vehículo 
        /// </summary>
        public RutaBE Ruta { get; set; }

        /// <summary>
        /// Conductor asignado al Vehículo 
        /// </summary>
        public Conductor_VehiculoBE Conductor_Vehiculo { get; set; }
    }
}
