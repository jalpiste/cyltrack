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

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Ciudad
    /// </summary>
    public class CiudadBE
    {
        /// <summary>
        /// Identificador de la ciudad
        /// </summary>
        public String Id_Ciudad { get; set; }
        
        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public String Nombre { get; set; }
        
    }
}
