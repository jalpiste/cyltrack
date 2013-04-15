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
    /// Clase utilizada para representar la entidad Ubicación
    /// </summary>
    public class Ubicacion
    {
        /// <summary>
        /// Identificador de la ubicacion del cilindro
        /// </summary>
        public String Id_Ubicacion { get; set; }

        /// <summary>
        /// Fecha del cambio de ubicación del cilindro
        /// </summary>
        public String fecha { get; set; }

        /// <summary>
        /// Descripcion del cambio de ubicación
        /// </summary>
        public String Descripcion { get; set; }

        /// <summary>
        /// Direccion del cambio de ubicación
        /// </summary>
        public String Direccion { get; set; }



    }
}
