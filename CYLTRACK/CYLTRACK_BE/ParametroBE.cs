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
    /// Clase utilizada para representar la entidad Parámetros
    /// </summary>

    public class ParametroBE
    {
        /// <summary>
        /// Identificador del Parámetro
        /// </summary>
        public String Id_Parametro { get; set; }

        /// <summary>
        /// Descripción del parámetro
        /// </summary>
        public String Descripcion { get; set; }

        /// <summary>
        /// Valor del parámetro
        /// </summary>
        public String Valor { get; set; }

    }
}
