<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambioTelefono.aspx.cs" Inherits="CYLTRACK_WebApp.Clientes.frmCambioTelefono" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Cambiar Teléfono
    </h1>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Cambio Teléfono Cliente</legend>
                   <p>
                       <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label>
                       <br />
                       <asp:TextBox ID="txtCedula" CssClass="textEntry"  runat="server"></asp:TextBox>
                       <br />
                      <asp:Label ID="lblTelefono" runat="server" Text="Nuevo Telefono: "></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblTipoTelefono" runat="server" Text="Tipo Telefono:"></asp:Label><br />
  
                      <asp:TextBox ID="txtNuevaDireccion" CssClass="textEntry"  runat="server"></asp:TextBox>
               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ListBox ID="lstTipoTelefono" runat="server"  Rows="1">
                                <asp:ListItem>Residencia</asp:ListItem>
                                <asp:ListItem>Celular</asp:ListItem>
                                <asp:ListItem>Oficina</asp:ListItem>
                                <asp:ListItem>PBX/Conmutador</asp:ListItem>
                                <asp:ListItem>Telefax</asp:ListItem>
                            </asp:ListBox>
               
              </p>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
            </div>
</asp:Content>
