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
    /// Clase utilizada para representar la entidad Tipo de ubicación
    /// </summary>
    public class Tipo_UbicacionBE
    {
        /// <summary>
        /// Identificador de Ubicacion
        /// </summary>
        public String Id_Tipo_Ubica { get; set; }

        /// <summary>
        /// Nombre de la ubicación
        /// </summary>
        public String Nombre_Ubicacion { get; set; }

        /// <summary>
        /// Descripción de la ubicación
        /// </summary>
        public String Descripcion { get; set; }

    }
}
