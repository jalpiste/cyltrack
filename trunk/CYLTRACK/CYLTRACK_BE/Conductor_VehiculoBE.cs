﻿/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Conductor_Vehículo
    /// </summary>
    
    public class Conductor_VehiculoBE
    {
        /// <summary>
        /// Identificador de conductor_vehículo
        /// </summary>
        public String Id_Conductor_Vehiculo { get; set; }

        /// <summary>
        /// fecha de inicio de la ruta en un vehículo
        /// </summary>
        public DateTime  Fecha_Inicio { get; set; }

        /// <summary>
        /// fecha de finalización de la ruta en un vehículo
        /// </summary>
        public DateTime Fecha_Fin { get; set; }

        /// <summary>
        /// nombre de conductor asignado al vehículo
        /// </summary>
        public String Nombre_Cond { get; set; }

        /// <summary>
        /// primer apellido de conductor asignado al vehículo
        /// </summary>
        public String Apellido_1_Cond { get; set; }

        /// <summary>
        /// segundo apellido de conductor asignado al vehículo
        /// </summary>
        public String Apellido_2_Cond { get; set; }
    }
}
