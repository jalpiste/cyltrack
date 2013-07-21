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
        
        public List<ClienteBE> ConsultarCliente(String consultar_cli)
        {
            List<ClienteBE> lstCliente = new List<ClienteBE>();

            ClienteBE[] lista = new ClienteBE[4];
            Random ran = new Random();
            for (int i = 0; i < 4; i++)
            {
            ClienteBE cliente = new ClienteBE();
            cliente.Cedula = "56235624";
            cliente.Nombres_Cliente = "Jaime";
            cliente.Apellido_1 = "Poveda";
            cliente.Apellido_2 = "Sanchez";

            UbicacionBE ubi_cli = new UbicacionBE();
            ubi_cli.Direccion  = "Calle 17 N 10-30";
            ubi_cli.Barrio = "Centro";
            ubi_cli.Telefono_1 = "3143456789";
            cliente.Ubicacion = ubi_cli;

            CiudadBE ciu_cli = new CiudadBE();
            ciu_cli.Nombre_Ciudad = "Chiquinquirá";
            cliente.Ciudad = ciu_cli;

            DepartamentoBE dep_cli = new DepartamentoBE();
            dep_cli.Nombre_Departamento = "Boyacá";
            ciu_cli.Departamento = dep_cli;
            
            CilindroBE cilindro = new CilindroBE();
            cilindro.Codigo_Cilindro = ((DateTime.Now.Hour + DateTime.Now.Second) * ran.Next(1, 10)).ToString();
            cilindro.Tipo_Cilindro = "Universal";
            cliente.Cilindro = cilindro;
            
            TamanoBE tamano = new TamanoBE();
            tamano.Tamano = "40";
            cliente.Cilindro.NTamano = tamano;

            lista[i] = cliente;
            }

            lstCliente = lista.ToList();

            return lstCliente;
        }

        public String ModificarCliente(String modificar_cli)
        {
            List<ClienteBE> modificar = ConsultarCliente(modificar_cli);
            String resp = "Ok";
            
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
