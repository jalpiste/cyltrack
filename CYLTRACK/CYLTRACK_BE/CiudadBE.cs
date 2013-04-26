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
using Unisangil.CYLTRACK.CYLTRACK_BE;

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
        public String Nombre_Ciudad { get; set; }

        /// <summary>
        /// Departamento
        /// </summary>
        public DepartamentoBE Departamento { get; set; }

    }
}
