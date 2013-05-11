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
            String resp = "cliente creado";
            return resp;
        }
        
        public String RegistrarUbicacion(ClienteBE registrar_ubi)
        {
            String resp = "ubicacion creada";
            return resp;
        }
        
        public List<ClienteBE> ConsultarCliente(ClienteBE consultar_cli)
        {
            List<ClienteBE> lstCliente = new List<ClienteBE>();
            ClienteBE cliente = new ClienteBE();
            cliente.Nombres_Cliente = "jaime";
            cliente.Apellido_1 = "Poveda";
            cliente.Apellido_2 = "Sanchez";
            cliente.Ubicacion.Direccion = "Calle 17 N 10-30";
            cliente.Ubicacion.Barrio = "centro";
            cliente.Ciudad.Nombre_Ciudad = "Chiquinquirá";
            cliente.Ciudad.Departamento.Nombre_Departamento = "Boyacá";
            cliente.Ubicacion.Telefono_1 = "3143456789";
            cliente.Cilindro.Codigo_Cilindro = "8778687687687";
            cliente.Cilindro.NTamano.Tamano = "40";
            cliente.Cilindro.Tipo_Cilindro = "marcado";

            lstCliente.Add(cliente);

            return lstCliente;
        }

        public String ModificarCliente(ClienteBE modificar_cli)
        {
            List<ClienteBE> modificar = ConsultarCliente(modificar_cli);
            String resp = "ok";
            
            return resp;
        }
        #endregion
        #region Metodos privados
        #endregion
    }
}
