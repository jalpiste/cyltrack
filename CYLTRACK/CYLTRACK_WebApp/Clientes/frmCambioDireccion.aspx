<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCambioDireccion.aspx.cs" Inherits="CYLTRACK_WebApp.Account.Clientes.frmConsultaClientes2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 <h1 style="margin-top: 75px">
        Cambiar Dirección
    </h1>
           <div class="accountInfo">
                <fieldset class="login">
                    <legend>Cambio Dirección Cliente</legend>
                   <p>
                   <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label>
                       <br />
                       <asp:TextBox ID="txtCedula" CssClass="textEntry"  runat="server"></asp:TextBox>
                       <br />
                      
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
               <p>
               <asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label>
                            <br />
               <asp:ListBox ID="lstDepartamento" runat="server" Rows="1">
                            <asp:ListItem>Boyacá</asp:ListItem>
                            <asp:ListItem>Cundinamarca</asp:ListItem>
                        </asp:ListBox>
                        <br />
               <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label>
                        <br />
                        <asp:ListBox ID="LstCiudad" runat="server" Rows="1">
                            <asp:ListItem>Chiquinquirá</asp:ListItem>
                            <asp:ListItem>Bogotá</asp:ListItem>
                            <asp:ListItem>Tunja</asp:ListItem>
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
