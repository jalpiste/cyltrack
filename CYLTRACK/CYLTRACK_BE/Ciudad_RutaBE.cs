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
    /// Clase utilizada para representar la entidad Ciudad_Ruta
    /// </summary>
    public class Ciudad_RutaBE
    {
        /// <summary>
        /// Identificador de la Ciudad_Ruta
        /// </summary>
        public String Id_Ciudad_Ruta { get; set; }

        /// <summary>
        /// Ciudad_Ruta
        /// </summary>
        public CiudadBE Ciudad { get; set; }
    }
}
