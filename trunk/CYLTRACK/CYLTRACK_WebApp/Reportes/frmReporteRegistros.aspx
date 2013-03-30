<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReporteRegistros.aspx.cs" Inherits="CYLTRACK_WebApp.Reporte.frmReporteRegistros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h1 style="margin-top: 75px">
        Reporte de Registros
    </h1>
    <br />
    
    <asp:ValidationSummary ID="ReporteValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="ReporteValidationGroup" Width="385px" />

    <div style="width: 450px">
        Seleccione a continuación el ítem del que desea generar el reporte de registros.
    </div>
     <div id="DivRegistros" runat="server">
        
        <asp:RadioButtonList ID="rblstRegistros" runat="server" Width="205px">  
        <asp:ListItem>Cilindros</asp:ListItem>
        <asp:ListItem>Clientes</asp:ListItem>
        <asp:ListItem>Pedidos</asp:ListItem>
        <asp:ListItem>Rutas</asp:ListItem>
        <asp:ListItem>Usuarios</asp:ListItem>
        <asp:ListItem>Vehículos</asp:ListItem>
        <asp:ListItem>Ventas</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
   <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <asp:CheckBoxList ID="parametroCheckBoxList" runat="server" AutoPostBack="True" Width="250px">
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Vehículo</asp:ListItem>
                <asp:ListItem>Conductor</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblDesde" runat="server" Text="Fecha: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="lblDesdeDia" runat="server" Width="42px"></asp:TextBox>
            <asp:ListBox ID="lstDesdeMes" runat="server" AutoPostBack="True" Rows="1">
                <asp:ListItem>Mes</asp:ListItem>
                </asp:ListBox>
            <asp:TextBox ID="txtDesdeAño" runat="server" Width="100px"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lblPlacaVehiculo" runat="server" Text="Placa Vehículo: "></asp:Label>            
            <asp:ListBox ID="lstPlaca" runat="server" AutoPostBack="True" Rows="1">
                <asp:ListItem>Seleccionar</asp:ListItem>
                </asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblCedulaConductor" runat="server" Text="Cédula Conductor: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtCedulaConductor" runat="server" CssClass="textEntry" Width="197px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CedulaConductorRequired" runat="server" ControlToValidate="txtCedulaConductor" 
                             CssClass="failureNotification" ErrorMessage="La cedula del conductor es obligatorio." ToolTip="La cedula del conductor es obligatorio." 
                             ValidationGroup="ReporteValidationGroup">*</asp:RequiredFieldValidator>
       </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" />
        </p>
        <div id= "DivReporte" runat = "server" class="InfoInventarios">
       <fieldset class ="login">
            <legend>Reporte</legend>
            <div style="height: 1468px; width: 477px; margin-right: 4px;">
            <asp:Label ID="lblfecha" runat="server" Text="Fecha:   "></asp:Label>
            <asp:Label ID="lblImpresionFecha" runat="server" Text="xxxxxxxxx"></asp:Label>
            <br />
            </div> 
        </fieldset>
        </div> 
        <p class="submitButton">
            <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" Width="115px" 
                onclick="btnCancel_Click" />
        </p>
    </div>
</asp:Content>
