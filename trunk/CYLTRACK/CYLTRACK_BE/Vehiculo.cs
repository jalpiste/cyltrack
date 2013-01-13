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

namespace CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad vehiculo
    /// </summary>
    class Vehiculo
    {
        /// <summary>
        /// Identificador del vehiculo, (placa)
        /// </summary>
        public String Id_Vehiculo { get; set; }

        /// <summary>
        /// Identificador de la ruta
        /// </summary>
        public String Id_Ruta { get; set; }

        /// <summary>
        /// Caracteristicas del vehículo
        /// </summary>
        public String Caracteristicas { get; set; }
    }
}
