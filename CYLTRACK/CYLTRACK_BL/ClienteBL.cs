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
using Unisangil.CYLTRACK.CYLTRACK_DL;

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class ClienteBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public long CrearCliente(ClienteBE cliente)
        {
            ClienteDL cli = new ClienteDL();

            long resp = 0;
            try
            {
                resp = cli.CrearCliente(cliente);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }
        
        public long AgregarUbicacion(ClienteBE cliente)
        {
            ClienteDL cli = new ClienteDL();
            long resp = 0;
            try
            {
                resp = cli.AgregarUbicacionCliente(cliente);
            }
            catch (Exception ex)
            {
                resp = -1;
            }
            return resp;
        }
         /// <summary>
        /// Método para la consulta de clientes en el sistema y muestra de información 
        /// </summary>
        /// <param name="consultar_cli"></param>
        /// <returns></returns>
        public ClienteBE ConsultarCliente(string consultar_cli)
        {
            ClienteDL cli = new ClienteDL();
            ClienteBE resp = new ClienteBE();
            try
            {
                resp = cli.ConsultarCliente(consultar_cli);
            }
            catch (Exception ex)
            {

            }

            return resp;
        }

        public long ModificarCliente(ClienteBE cliente)
        {
            ClienteDL cli = new ClienteDL();

            long resp = 0;
            try
            {
                resp = cli.ModificarCliente(cliente);
            }
            catch (Exception ex)
            {
                //guardar exepcion en el log de bd
                resp = -1;
            }

            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
