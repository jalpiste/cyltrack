using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Pais
    /// </summary>
    public class PaisBE
    {
        /// <summary>
        /// Identificador del pais
        /// </summary>
        public String Id_Pais { get; set; }

        /// <summary>
        /// Nombre del pais
        /// </summary>
        public String Nombre { get; set; }


    }
}

