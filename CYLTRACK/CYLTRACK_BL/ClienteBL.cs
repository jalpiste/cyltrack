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
        
        public List<ClienteBE> ConsultarCliente(ClienteBE consultar_cli)
        {
            List<ClienteBE> lstCliente = new List<ClienteBE>();
            ClienteBE cliente = new ClienteBE();
            cliente.Cedula = "11234238";
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
            
            CilindroBE cil_cli = new CilindroBE();
            cil_cli.Codigo_Cilindro = "8778687687687";
            cil_cli.Tipo_Cilindro = "marcado";
            cliente.Cilindro = cil_cli;

            TamanoBE tam_cil = new TamanoBE();
            tam_cil.Tamano = "40";
            cil_cli.NTamano = tam_cil; 

            lstCliente.Add(cliente);

            return lstCliente;
        }

        public String ModificarCliente(ClienteBE modificar_cli)
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
