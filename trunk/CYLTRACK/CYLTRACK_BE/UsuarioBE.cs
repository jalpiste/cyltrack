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
    /// Clase utilizada para representar la entidad Usuario
    /// </summary>
    
    public class UsuarioBE
    {
        /// <summary>
        /// Identificador del Usuario
        /// </summary>
        public String Id_Usuario { get; set; }

        /// <summary>
        /// Nombre de Usuario o Nick de login
        /// </summary>
        public String Usuario { get; set; }

        /// <summary>
        /// Nombre del Usuario
        /// </summary>
        public String Nombre { get; set; }

        /// <summary>
        /// Apellido Usuario
        /// </summary>
        public String Apellido { get; set; }

        /// <summary>
        /// Número de Cédula del Usuario
        /// </summary>
        public String Cedula { get; set; }

        /// <summary>
        /// Contraseña N.1 del Usuario
        /// </summary>
        public String Contrasena_1 { get; set; }

        /// <summary>
        /// Confirmación de contraeña del Usuario
        /// </summary>
        public String Contrasena_2 { get; set; }

        /// <summary>
        /// Contraseña N.3 del Usuario
        /// </summary>
        public String Contrasena_3 { get; set; }

        /// <summary>
        /// Contraseña N.4 del Usuario
        /// </summary>
        public String Contrasena_4 { get; set; }

        /// <summary>
        /// Contraseña N.5 del Usuario
        /// </summary>
        public String Contrasena_5 { get; set; }

        /// <summary>
        /// Contraseña N.6 del Usuario
        /// </summary>
        public String Contrasena_6 { get; set; }

        /// <summary>
        /// Contraseña N.7 del Usuario
        /// </summary>
        public String Contrasena_7 { get; set; }

        /// <summary>
        /// Contraseña N.8 del Usuario
        /// </summary>
        public String Contrasena_8 { get; set; }

        /// <summary>
        /// Contraseña N.9 del Usuario
        /// </summary>
        public String Contrasena_9 { get; set; }

        /// <summary>
        /// Contraseña N.10 del Usuario
        /// </summary>
        public String Contrasena_10 { get; set; }

        /// <summary>
        /// Estado del Usuario
        /// </summary>
        public String Estadp { get; set; }

        /// <summary>
        /// Fecha de modificacion de la contraseña del Usuario
        /// </summary>
        public String Fecha_Mod_Contrasena { get; set; }

        /// <summary>
        /// Primera vez que ingresa al sistema con esa contraseña
        /// </summary>
        public String Primera_Vez { get; set; }

        /// <summary>
        /// Género del Usuario
        /// </summary>
        public String Genero { get; set; }

        /// <summary>
        /// Fecha de nacimiento del Usuario
        /// </summary>
        public String Fecha_Nacim { get; set; }

        /// <summary>
        /// Dirección del Usuario
        /// </summary>
        public String Direccion { get; set; }

        /// <summary>
        /// Correo electrónico del Usuario
        /// </summary>
        public String Correo { get; set; }

        /// <summary>
        /// Teléfono del Usuario
        /// </summary>
        public String Telefono { get; set; }

        /// <summary>
        /// Perfil de Usuario
        /// </summary>
        public PerfilBE Perfil { get; set; }

    }
}
