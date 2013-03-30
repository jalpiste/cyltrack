<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReporteSiembras.aspx.cs" Inherits="CYLTRACK_WebApp.Reporte.frmReporteSiembras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Reporte de Siembras
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
            <asp:CheckBoxList ID="parametroCheckBoxList" runat="server" AutoPostBack="True" Width="250px">
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Ubicación</asp:ListItem>
            </asp:CheckBoxList>
            <br />
            <asp:Label ID="lblDesde" runat="server" Text="Fecha: "></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Calendar ID="cldFecha" runat="server" Height="20px" Width="20px" 
                BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" 
                DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                ForeColor="#663399" ShowGridLines="True">
                <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                <NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" />
                <OtherMonthDayStyle ForeColor="#CC9966" />
                <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                <SelectorStyle BackColor="#FFCC66" />
                <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" 
                    ForeColor="#FFFFCC" />
                <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
            </asp:Calendar>
             
             <br />
            <br />
            <asp:Label ID="lblNota" runat="server" Text="Ubicación: "></asp:Label>
            <asp:ListBox ID="lstUbicacion" runat="server" AutoPostBack="True" Rows="1" OnSelectedIndexChanged="Ubicacion_SelectedIndexChanged">
                <asp:ListItem>Seleccionar</asp:ListItem>
                <asp:ListItem>Vehiculo</asp:ListItem>
                </asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " Visible="False"></asp:Label>
            <asp:ListBox ID="lstPlacaVehículo" runat="server" AutoPostBack="True" Rows="1" Visible="False">
                <asp:ListItem>Seleccionar</asp:ListItem>
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
            </div>
    </fieldset>
    </div>
</asp:Content>
