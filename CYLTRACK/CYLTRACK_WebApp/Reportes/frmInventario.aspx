<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmInventario.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Inventario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #DivReporte
        {
            width: 490px;
            margin-right: 128px;
            height: 1163px;
        }
        #DivTotales
        {
            height: 228px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="margin-top: 75px">
        Reporte de Inventario de Cilindros
    </h1>
    <br />
    <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="LoginUserValidationGroup" Width="385px" />
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <asp:Label ID="lblDesde" runat="server" Text="Fecha: "></asp:Label>
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
                <asp:ListItem>Todos..</asp:ListItem>
            </asp:ListBox>
            <br />
            <br />
            <div id="divPlaca" runat="server" visible="false">
            <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " Visible="true"></asp:Label>
            <asp:ListBox ID="lstPlacaVehículo" runat="server" AutoPostBack="True" Rows="1" Visible="true">
                <asp:ListItem>XHA913</asp:ListItem>
                <asp:ListItem>XHA123</asp:ListItem>
                <asp:ListItem>ABC1000</asp:ListItem>
                <asp:ListItem>VBG456</asp:ListItem>
                <asp:ListItem>LDEO650</asp:ListItem>
                <asp:ListItem>AWA789</asp:ListItem>
            </asp:ListBox>
            </div>
        </fieldset>
        <p class="submitButton" >
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" OnClick="btnBuscar_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        </p>
    </div>
     <div id="divInventario" runat="server" class="accountInfo" visible="false">
        <fieldset class="login">
            <legend>Reporte</legend>
           
                <asp:GridView ID="gvReporte" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
           
        </fieldset>
    </div>
    <div class="submitButton" id="divBotones" runat="server" visible="false">
        <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" OnClick="btnMenu_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    </div>
</asp:Content>
