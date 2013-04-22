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
    /// Clase utilizada para representar la entidad Perfil
    /// </summary>
    
    public class PerfilBE
    {
        /// <summary>
        /// Identificador del Perfil
        /// </summary>
        public String Id_Perfil { get; set; }

        /// <summary>
        /// Nombre del Perfil
        /// </summary>
        public String Perfil { get; set; }

        /// <summary>
        /// Observaciones o descripcion del Perfil
        /// </summary>
        public String Observaciones { get; set; }

    }
}
