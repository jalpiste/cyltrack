<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmInventario.aspx.cs" Inherits="CYLTRACK_WebApp.Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #DivReporte
        {
            width: 490px;
        }
        #DivTotales
        {
            height: 207px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="margin-top: 75px">
        Reporte de Cilindros
    </h1>
    <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="LoginUserValidationGroup" Width="385px" />
    <br />
    <div class="accountInfo">
        <fieldset class="login" width="250px">
            <legend>Búsqueda</legend>
            <asp:CheckBoxList ID="parametroCheckBoxList" runat="server" AutoPostBack="True" Width="250px">
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Ubicación</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblDesde" runat="server" Text="Desde el: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lblDesdeDia" runat="server" Width="42px"></asp:TextBox>
            <asp:ListBox ID="lstDesdeMes" runat="server" AutoPostBack="True" Rows="1">
                <asp:ListItem>Enero</asp:ListItem>
                <asp:ListItem>Febrero</asp:ListItem>
                <asp:ListItem>Marzo</asp:ListItem>
                <asp:ListItem>Abril</asp:ListItem>
                <asp:ListItem>Mayo</asp:ListItem>
                <asp:ListItem>Junio</asp:ListItem>
                <asp:ListItem>Julio</asp:ListItem>
                <asp:ListItem>Agosto</asp:ListItem>
                <asp:ListItem>Septiembre</asp:ListItem>
                <asp:ListItem>Octubre</asp:ListItem>
                <asp:ListItem>Noviembre</asp:ListItem>
                <asp:ListItem>Diciembre</asp:ListItem>
            </asp:ListBox>
            <asp:TextBox ID="txtDesdeAño" runat="server" Width="100px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblNota" runat="server" Text="Ubicación: "></asp:Label>
            <asp:ListBox ID="lstUbicacion" runat="server" AutoPostBack="True" Rows="1" OnSelectedIndexChanged="Ubicacion_SelectedIndexChanged">
                <asp:ListItem>Seleccionar</asp:ListItem>
                <asp:ListItem>Plataforma</asp:ListItem>
                <asp:ListItem>Bodega</asp:ListItem>
                <asp:ListItem>Mantenimiento</asp:ListItem>
                <asp:ListItem>Chatarra</asp:ListItem>
                <asp:ListItem>Vehículo</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " Visible="False"></asp:Label>
            <asp:ListBox ID="lstPlacaVehículo" runat="server" AutoPostBack="True" Rows="1" Visible="False">
                <asp:ListItem>XHA913</asp:ListItem>
                <asp:ListItem>XHA123</asp:ListItem>
                <asp:ListItem>ABC1000</asp:ListItem>
                <asp:ListItem>VBG456</asp:ListItem>
                <asp:ListItem>LDEO650</asp:ListItem>
                <asp:ListItem>AWA789</asp:ListItem>
            </asp:ListBox>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" />
        </p>
    </div>
    <div id= "DivReporte" runat = "server" class="InfoInventarios">
        <fieldset class="login">
            <legend>Reporte</legend>
            <div style="height: 1468px; width: 477px; margin-right: 4px;">
            <asp:Label ID="lblfecha" runat="server" Text="Fecha:   "></asp:Label>
            <asp:Label ID="lblImpresionFecha" runat="server" Text="xxxxxxxxx"></asp:Label>
            <br />
            <div id="DivPlataforma" runat = "server" visible = "false">
            <h3>
            <asp:Label ID="lblPlataforma1" runat="server" Text="PLATAFORMA:   "></asp:Label>
            </h3>
            <h4>
            <asp:Label ID="lblCilindroMarca1" runat="server" Text="Cilindros de Marca:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano1" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad1" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta1" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta1" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta1" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta1" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta1" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta1" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien1" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien" runat="server" Text="xxxxx"></asp:Label>
                </div>
            <br />
            <div id="DivBodega" runat = "server" visible = "false">
            <h3>
            <asp:Label ID="lblBodega" runat="server" Text="BODEGA:   "></asp:Label>
            </h3>
            <h4>
            <asp:Label ID="lblCilindroMarca2" runat="server" Text="Cilindros de Marca:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano2" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad2" runat="server" Text="Cantidad"></asp:Label>
            </h4>
         
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta2" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta2" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta2" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta2" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta2" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta2" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien2" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien2" runat="server" Text="xxxxx"></asp:Label>
                </div> 
            <%----------------------------------------------%>
            <br />
            <div id="DivMantenimiento" runat = "server" visible = "false">
            <h3>
            <asp:Label ID="lblMantenimiento" runat="server" Text="MANTENIMIENTO:   "></asp:Label>
            </h3>
            <h4>
            <asp:Label ID="lblCilindroMarca3" runat="server" Text="Cilindros de Marca:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano3" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad3" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta3" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta3" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta3" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta3" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta3" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta3" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien3" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien3" runat="server" Text="xxxxx"></asp:Label>
            <br />
            <h4>
            <asp:Label ID="lblCilindroUniversal4" runat="server" Text="Cilindros Universales:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano4" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad4" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta4" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta4" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta4" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta4" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta4" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta4" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien4" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien4" runat="server" Text="xxxxx"></asp:Label>
                </div>
            <%-----------------------------------------------------------------------%>
            <br />
            <div id="DivChatarra" runat = "server" visible = "false">
            <h3>
            <asp:Label ID="lblChatarra" runat="server" Text="CHATARRA:   "></asp:Label>
            </h3>
            <h4>
            <asp:Label ID="lblCilindroMarca4" runat="server" Text="Cilindros de Marca:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano5" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad5" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta5" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta5" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta5" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta5" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta5" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta5" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien5" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien5" runat="server" Text="xxxxx"></asp:Label>
            <br />
            <h4>
            <asp:Label ID="lblCilindroUniversal5" runat="server" Text="Cilindros Universales:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano6" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad6" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta6" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta6" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta6" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta6" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta6" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta6" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien6" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien6" runat="server" Text="xxxxx"></asp:Label>
                </div> 
            <%-----------------------------------------------------------------------%>
            <br />
            <div id="DivVehiculo" runat = "server" visible = "false">
            <h3>
            <asp:Label ID="lblVehiculo" runat="server" Text="VEHÍCULO:   "></asp:Label>
            </h3>
            <h4>
            <asp:Label ID="lblCilindroMarca5" runat="server" Text="Cilindros de Marca:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano7" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad7" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta7" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta7" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta7" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta7" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta7" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta7" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien7" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien7" runat="server" Text="xxxxx"></asp:Label>
            <br />
            <h4>
            <asp:Label ID="lblCilindroUniversal6" runat="server" Text="Cilindros Universales:"></asp:Label>
            <br />
            <asp:Label ID="lblTamano8" runat="server" Text="Tamaño"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCantidad8" runat="server" Text="Cantidad"></asp:Label>
            </h4>
            
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblTreinta8" runat="server" Text="30       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadTreinta8" runat="server" Text="xxxxx"></asp:Label>
             <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCuarenta8" runat="server" Text="40       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCuarenta8" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblOchenta8" runat="server" Text="80       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadOchenta8" runat="server" Text="xxxxx"></asp:Label>
            <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCien8" runat="server" Text="100       "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblCantidadCien8" runat="server" Text="xxxxx"></asp:Label>
                </div> 
            <br />
            <br />
            <div id="DivTotales" runat ="server">
            <h4>
                <asp:Label ID="lblTotalMarca" runat="server" Text="Total Cilindros de Marca: "></asp:Label>
                </h4> 
                <asp:Label ID="lblTotalM" runat="server" Text="xxxxx"></asp:Label>
            <h4>
                <asp:Label ID="lblTotalUniversal" runat="server" Text="Total Cilindros Universales: "></asp:Label>
                </h4>
                <asp:Label ID="lblTotalU" runat="server" Text="xxxxx"></asp:Label>
            <h4>
                <asp:Label ID="lblTotalPlanta" runat="server" Text="Total en Planta: "></asp:Label>
                </h4>
                <asp:Label ID="lblTotalP" runat="server" Text="xxxxx"></asp:Label>
                <br />
                </div>
            </div>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="115px" 
                onclick="btnCancel_Click" />
        </p>
    </div>
</asp:Content>
