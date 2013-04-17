<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmNuevaUbicacion.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes.frmNuevaUbicacion" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
 <h1 style="margin-top: 75px">
        Nueva Ubicación
    </h1>
           <div class="accountInfo">
                <fieldset class="login">
                    <legend>Agregar Nueva Ubicación Cliente</legend>
                   <p>
                       <asp:Label ID="lblNuevaDireccion" runat="server" Text="Nueva Dirección: "></asp:Label>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblNuevoBarrio" runat="server" Text="Barrio:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtNuevaDireccion" CssClass="textEntry"  runat="server"></asp:TextBox>
               
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="txtNuevoBarrio" CssClass="textEntry" runat="server"></asp:TextBox>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="txtTelefono" CssClass="textEntry" runat="server"></asp:TextBox>
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
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="115px"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        Width="115px" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnAtras" runat="server" Text="Atrás" 
                        Width="115px" /> 
                    </p>
            </div>
</asp:Content>
