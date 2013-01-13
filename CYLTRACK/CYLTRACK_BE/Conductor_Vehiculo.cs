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

namespace CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Conductor_Vehículo
    /// </summary>
    
    class Conductor_Vehiculo
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

    }
}
