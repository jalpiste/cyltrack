﻿/*
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

namespace Unisangil.CYLTRACK.CYLTRACK_BL
{
    public class ClienteBL
    {
        #region Variables

        #endregion
        #region Metodos publicos
        public String RegistrarCliente(ClienteBE registrar_cli)
        {
            String resp = "Ok";
            return resp;
        }
        
        public String RegistrarUbicacion(ClienteBE registrar_ubi)
        {
            String resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de existencia de clientes en el sistema
        /// </summary>
        /// <param name="consultar_existencia"></param>
        /// <returns></returns>
        public string ConsultarExistencia(string consultar_existencia)
        {
            string resp = "Ok";
            return resp;
        }
        /// <summary>
        /// Método para la consulta de clientes en el sistema y muestra de información 
        /// </summary>
        /// <param name="consultar_cli"></param>
        /// <returns></returns>
        public ClienteBE ConsultarCliente(string consultar_cli)
        {
            Random ran = new Random();

            ClienteBE cliente = new ClienteBE();
            cliente.Cedula = "56235624";
            cliente.Nombres_Cliente = "Jaime";
            cliente.Apellido_1 = "Poveda";
            cliente.Apellido_2 = "Sanchez";

            UbicacionBE ubicacion = new UbicacionBE();
            ubicacion.Direccion  = "Calle 17 N 10 30";
            ubicacion.Barrio = "Centro";
            ubicacion.Telefono_1 = "3143456789";
            
            CiudadBE ciu_cli = new CiudadBE();
            ciu_cli.Nombre_Ciudad = "Chiquinquirá";
            ubicacion.Ciudad = ciu_cli;

            DepartamentoBE dep_cli = new DepartamentoBE();
            dep_cli.Nombre_Departamento = "Boyacá";
            ciu_cli.Departamento = dep_cli;
            
            CilindroBE cilindro = new CilindroBE();
            cilindro.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
            cilindro.Tipo_Cilindro = "Universal";
            
            TamanoBE tamano = new TamanoBE();
            tamano.Tamano = "40";
            cilindro.NTamano = tamano;

            Ubicacion_CilindroBE ubi_cilindro = new Ubicacion_CilindroBE();
            ubi_cilindro.Cilindro = cilindro;
            ubicacion.Ubicacion_Cilindro = ubi_cilindro;
            cliente.Ubicacion = ubicacion;
            
            return cliente;
        }

        public String ModificarCliente(String modificar_cli)
        {
            ClienteBE modificar = ConsultarCliente(modificar_cli);
            String resp = "Ok";
            
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}