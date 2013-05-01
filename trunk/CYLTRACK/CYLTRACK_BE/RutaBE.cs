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
    /// Clase utilizada para representar la entidad Ruta
    /// </summary>
    public class RutaBE
    {
        /// <summary>
        /// Identificador ruta 
        /// </summary>
        public String Id_Ruta { get; set; }

        /// <summary>
        /// Nombre de la ruta 
        /// </summary>
        public String Nombre_Ruta { get; set; }

        /// <summary>
        /// Nombre de la ciudad de la ruta
        /// </summary>
        public Ciudad_RutaBE Ciudad_Ruta { get; set; }

        /// <summary>
        /// Nombre del departamento de la ruta
        /// </summary>
        public DepartamentoBE Departamento { get; set; }

    }
}
