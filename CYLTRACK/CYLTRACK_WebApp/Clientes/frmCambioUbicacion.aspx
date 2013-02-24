<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCambioUbicacion.aspx.cs" Inherits="CYLTRACK_WebApp.Account.Clientes.frmConsultaClientes2" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 <h1 style="margin-top: 75px">
        Agregar Nueva Ubicación
    </h1>
           <div class="accountInfo">
                <fieldset class="login">
                    <legend>Agregar Ubicación Cliente</legend>
                   <p>
                      <asp:Label ID="lblNuevaDireccion" runat="server" Text="Nueva Dirección: "></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblNuevoBarrio" runat="server" Text="Barrio:"></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblNuevoTel" runat="server" Text="Teléfono:"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtNuevaDireccion" CssClass="textEntry"  runat="server"></asp:TextBox>
               
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="txtNuevoBarrio" CssClass="textEntry" runat="server"></asp:TextBox>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="txtNuevoTelefono" CssClass="textEntry" runat="server"></asp:TextBox>
                          </p>
               <p>
               <asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label>
                            <br />
               <asp:ListBox ID="lstDepartamento" runat="server" Rows="1">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                        </asp:ListBox>
                        <br />
               <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label>
                        <br />
                        <asp:ListBox ID="LstCiudad" runat="server" Rows="1">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                        </asp:ListBox>
              </p> 

                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" 
                        onclick="btnGuardar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Button ID="btnMenuPrincipal" runat="server" Text="Atrás" Width="121px" 
                        onclick="btnMenuPrincipal_Click"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
            </div>
</asp:Content>
