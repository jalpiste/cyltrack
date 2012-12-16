<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCancelarVenta.aspx.cs" Inherits="CYLTRACK_WebApp.Ventas.frmCancelarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Cancelar Venta
    </h1>
    <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="CancelarVentaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="CancelarVentaValidationGroup"/>
    <div>
            <fieldset class="login" style="width: 777px">
                <legend>Cancelación de Venta</legend>
                <%--cual seria la diferencia con devolucion cilindro si en ese formulario se da la opción de cancelar venta...--%>
            </fieldset>
    </div>
</asp:Content>
