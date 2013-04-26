using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unisangil.CYLTRACK.CYLTRACK_BE;
using Unisangil.CYLTRACK.CYLTRACK_BL;
using System.ServiceModel;

namespace Unisangil.CYLTRACK.CYLTRACK_WCF_Services
{
    public class PedidoService : IPedidoService 
    {
        public long Registrar_Pedido(PedidoBE registrar_ped)
        {
            long resp = 0;
            PedidoBL regisPedido = new PedidoBL();
            resp = regisPedido.RegistrarPedido(registrar_ped);
            return resp;
        }

        public long Consultar_Pedido(PedidoBE consultar_ped)
        {
            long resp = 0;
            PedidoBL ConPedido = new PedidoBL();
            resp = ConPedido.ConsultarPedido(consultar_ped);
            return resp;
        }

        public long Modificar_Pedido(PedidoBE modificar_ped)
        {
            long resp = 0;
            PedidoBL ModPedido = new PedidoBL();
            resp = ModPedido.ModificarPedido(modificar_ped);
            return resp;
        }

        public long Cancelar_Pedido(PedidoBE cancelar_ped)
        {
            long resp = 0;
            PedidoBL CanPedido = new PedidoBL();
            resp = CanPedido.CancelarPedido(cancelar_ped);
            return resp;
        }
    }
}
