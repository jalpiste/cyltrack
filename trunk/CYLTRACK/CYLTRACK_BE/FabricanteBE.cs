using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Fabricante
    /// </summary>
    public class FabricanteBE
    {
        /// <summary>
        /// Identificador fabricante
        /// </summary>
        public String Id_Fabricante { get; set; }
        /// <summary>
        /// Direccion del fabricante
        /// </summary>
        public String Direccion { get; set; }
        /// <summary>
        /// Telefono del fabricante
        /// </summary>
        public String Telefono { get; set; }
        /// <summary>
        /// Nombre del fabricante
        /// </summary>
        public String Nombre_Fabricante { get; set; }
        /// <summary>
        /// Número único de Identificación del fabricante
        /// </summary>
        public String Nit { get; set; }
        /// <summary>
        /// Código del fabricante
        /// </summary>
        public String Codigo_Fabricante { get; set; }
    }
}
