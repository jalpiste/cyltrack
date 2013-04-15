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
    /// Clase utilizada para representar la entidad Ruta
    /// </summary>
    public class Ruta
    {
        /// <summary>
        /// Identificador ruta 
        /// </summary>
        public String Id_Ruta { get; set; }

        /// <summary>
        /// Nombre de la ruta 
        /// </summary>
        public String Nombre { get; set; }

    }
}
