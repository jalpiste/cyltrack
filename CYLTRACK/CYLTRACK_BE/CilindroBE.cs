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
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Clase utilizada para representar la entidad Cilindro
    /// </summary>
    public class CilindroBE
    {
        /// <summary>
        /// Identificador del cilindro
        /// </summary>
        public String Id_Cilindro { get; set; }

        /// <summary>
        /// Año de fabricación del cilindro
        /// </summary>
        public String Ano { get; set; }

        /// <summary>
        /// Identificador fabricante de cilindro, 3 o 4 digitos
        /// </summary>
        public FabricanteBE Fabricante { get; set; }

        /// <summary>
        /// Código de 12 digitos
        /// </summary>
        public String Codigo_Cilindro { get; set; }

        /// <summary>
        /// Tamaño del cilindro
        /// </summary>
        public TamanoBE NTamano { get; set; }

        /// <summary>
        /// Estado actual del cilindro, en uso o chatarra
        /// </summary>
        public String Estado { get; set; }

        /// <summary>
        /// Tipo de cilindro, universal o de marca
        /// </summary>
        public String Tipo_Cilindro { get; set; }

        /// <summary>
        /// Código de 4 digitos restantes
        /// </summary>
        public String Serial_Cilindro { get; set; }

        /// <summary>
        /// Nombre de la ubicación del cilindro
        /// </summary>
        public Tipo_UbicacionBE Ubicacion { get; set; }

        /// <summary>
        /// Fecha de la creación del cilindro
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Vehículo
        /// </summary>
        public VehiculoBE Vehiculo { get; set; }

        /// <summary>
        /// Ventas
        /// </summary>
        public VentaBE Venta { get; set; }

    }
}
