<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCambioDireccion.aspx.cs" Inherits="CYLTRACK_WebApp.Account.Clientes.frmConsultaClientes2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h1> 
           
            </h1>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Dirección Cliente</legend>
                   <p>
                      <asp:Label ID="lblNuevaDireccion" runat="server" Text="Nueva Dirección: "></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblNuevoBarrio" runat="server" Text="Barrio:"></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNuevoTipoDir" runat="server" Text="Tipo de Dirección:"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtNuevaDireccion" CssClass="textEntry"  runat="server"></asp:TextBox>
               
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtNuevoBarrio" CssClass="textEntry" runat="server"></asp:TextBox>
               
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="lstNuevaTipoDireccion" runat="server" Rows="1">
                              <asp:ListItem>Residencia</asp:ListItem>
                              <asp:ListItem>Oficina</asp:ListItem>
                              <asp:ListItem>Deposito</asp:ListItem>
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
