﻿/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    // <summary>
    /// Clase utilizada para representar la entidad Departamento
    /// </summary>

    public class DepartamentoBE
    {
        /// <summary>
        /// Identificador de un departamento
        /// </summary>
        public String Id_Departamento { get; set; }

        /// <summary>
        /// Nombre de un departamento
        /// </summary>
        public String Nombre_Departamento { get; set; }

        /// <summary>
        /// Nombre de la ciudad
        /// </summary>
        public CiudadBE Ciudad { get; set; }
    }
}
