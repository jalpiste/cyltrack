using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.ServiceModel;
using System.Runtime.Serialization;


namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    [DataContract]
    public class Tipo_CasoBE
    {
        /// <summary>
        /// Identificador del Tipo de Caso
        /// </summary>
        [DataMember]
        public String Id_Tipo_Caso { get; set; }

        /// <summary>
        /// Descripción del Tipo de Caso
        /// </summary>
        [DataMember]
        public String Descripcion_Tipo_Caso { get; set; }

        /// <summary>
        /// Nombre del Caso
        /// </summary>
        [DataMember]
        public String Nombre_Caso { get; set; }  
    }
}
