using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CYLTRACK_PHONE
{
    /// <summary>
    /// Clase utilizada para identificar los links de acceso en el menu principal 
    /// </summary>
    public class ProcesoCyltrack
    {

        public String Titulo { get; set; }
        public String Titulo2 { get; set; }
        public String Titulo3 { get; set; }
        public String NomBoton { get; set; }
        public String Activity { get; set; }

        /// <summary>
        /// Constructor de la clase ProcesoCyltrack
        /// </summary>
        /// <param name="menu">Tipo de menú</param>
        public ProcesoCyltrack(String menu)
        {
            NomBoton = menu;
            Titulo = "Registrar " + menu;
            Titulo2 = "Consultar " + menu;

            switch (menu)
            {
                case "Cliente":
                    this.Activity = "Images/registroCilindros.png";
                    break;
                case "Venta":
                    this.Activity = "Images/actividad03.png";
                    this.Titulo3 = "Consultar Cilindro";
                    break;
                case "Pedido":
                    this.Activity = "Images/ventas.png";
                    break;
            }
        }
    }
}
