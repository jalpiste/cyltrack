using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Fabricante
    /// </summary>
    [DataContract]
    public class FabricanteBE
    {
        /// <summary>
        /// Identificador fabricante
        /// </summary>
        [DataMember]
        public int Id_Fabricante { get; set; }
        /// <summary>
        /// Direccion del fabricante
        /// </summary>
        [DataMember]
        public String Direccion { get; set; }
        /// <summary>
        /// Telefono del fabricante
        /// </summary>
        [DataMember]
        public String Telefono { get; set; }
        /// <summary>
        /// Nombre del fabricante
        /// </summary>
        [DataMember]
        public String Nombre_Fabricante { get; set; }
        /// <summary>
        /// Número único de Identificación del fabricante
        /// </summary>
        [DataMember]
        public String Nit { get; set; }
        /// <summary>
        /// Código del fabricante
        /// </summary>
        [DataMember]
        public String Codigo_Fabricante { get; set; }
    }
}
