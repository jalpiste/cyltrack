using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para identificar la entidad Ubicacion_Cilindro
    /// </summary>
    public class Ubicacion_CilindroBE
    {
        /// <summary>
        /// Identificador de la Ubicacion del Cilindro
        /// </summary> 
        public String Id_Tipo_Ubica { get; set; }

        /// <summary>
        /// Nombre de la ubicación del cilindro
        /// </summary> 
        public String Nombre { get; set; }

        /// <summary>
        /// Descripción de la Ubicacion del Cilindro
        /// </summary> 
        public String Descripcion { get; set; }

    }
}
