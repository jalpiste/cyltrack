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
    /// Clase utilizada para representar la entidad Ubicación
    /// </summary>
    public class UbicacionBE
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
        /// Descripción del cambio de ubicación
        /// </summary>
        public String Descripcion { get; set; }

        /// <summary>
        /// Dirección de nueva de ubicación
        /// </summary>
        public String Direccion { get; set; }

        /// <summary>
        /// Teléfono N.1 de nueva de ubicación
        /// </summary>
        public String Telefono_1 { get; set; }

        /// <summary>
        /// Teléfono N.2 de nueva de ubicación
        /// </summary>
        public String Telefono_2 { get; set; }

        /// <summary>
        /// Barrio de nueva de ubicación
        /// </summary>
        public String Barrio { get; set; }


        /// <summary>
        /// Ciudad 
        /// </summary>
        public CiudadBE Ciudad { get; set; }

        /// <summary>
        /// Vehiculo 
        /// </summary>
        public VehiculoBE Vehiculo { get; set; }

       }
}
