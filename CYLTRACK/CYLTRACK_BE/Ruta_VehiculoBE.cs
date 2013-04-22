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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Ruta_Vehiculo
    /// </summary>
    
    public class Ruta_VehiculoBE
    {
        /// <summary>
        /// Identificador de la ruta del vehiculo
        /// </summary>
        public String Id_Ruta_Vehiculo { get; set; }

        /// <summary>
        /// Fecha de inicio de la ruta
        /// </summary>
        public String Fecha_Inicio { get; set; }

        /// <summary>
        /// Fecha final de la ruta
        /// </summary>
        public String Fecha_Fin { get; set; }

        /// <summary>
        /// Estado de la ruta
        /// </summary>
        public String Estado { get; set; }

    }
}
