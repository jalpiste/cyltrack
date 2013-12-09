/*
 * Proyecto de grado: Trazabilidad de Cilindros CYLTRACK
 * Integrantes: Viviana Camacho y Jackelyne Padilla
 * Director: Fabián Lancheros Currea
 * Deerechos reservados
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unisangil.CYLTRACK.CYLTRACK_BE
{
    /// <summary>
    /// Entidad de negocio usada como prueba
    /// </summary>
    public class PruebaBE
    {
        int idPrueba;
        string descripción;
        DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string Descripción
        {
            get { return descripción; }
            set { descripción = value; }
        }

        public int IdPrueba
        {
            get { return idPrueba; }
            set { idPrueba = value; }
        }

    }
}
