<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignarUbicacion.aspx.cs" Inherits="CYLTRACK_WebApp.AsignarUbicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="width: 837px; margin-right: 45px;">
       <h2> 
        Asignación de Ubicación de Cilindros
       </h2>
       <span class="failureNotification">
       <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>       
      
       <asp:ValidationSummary ID="LoginValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="LoginValidationGroup" Width="385px"/>
       <div class="accountInfo"> 
       <fieldset class="login">
       <legend>Asignación de Ubicación</legend>
       <div>
           <asp:Label ID="lblCodeCil" runat="server" Text="Código Cilindro:"></asp:Label>
           <br /> 
           <asp:TextBox ID="txtCodeCilindro" runat="server" CssClass="textEntry" Width="197px" ontextchanged="txtCodeCilindro_TextChanged" 
           ValidationGroup = "LoginValidationGroup"></asp:TextBox>
           <asp:RequiredFieldValidator ID="CodeCilindroRequired" runat="server" 
           ControlToValidate="txtCodeCilindro" CssClass="failureNotification" 
           ErrorMessage="El código del cilindro es obligatorio." ToolTip="El Código del Cilindro es obligatorio." 
           ValidationGroup="LoginValidationGroup">*</asp:RequiredFieldValidator>          
                         
       </div> 
       
       <div id = "ImpresionCodigo" runat ="server" visible= "false">
       <br />
           <asp:Label ID="lblCodCil" runat="server" Text="Código:  " Enabled="False"></asp:Label>
           <asp:TextBox ID="txtCodigoCilindro" runat="server" Enabled="False" 
               Width="90px"></asp:TextBox>
           </div>
           
                  <br />
                  <div id="UbicacionCil" runat="server" visible="false">
                  <div class="post" >
                      <asp:Label ID="lblPost" runat="server" Text="Información Ubicación Cilindro"></asp:Label>
                      </div> 
                        <asp:Label ID="lblUbicacionActual" runat="server" Text="Ubicación Actual:  " 
                            Enabled="False"></asp:Label>
                        <asp:TextBox ID="txtUbicacionActual" runat="server" Enabled="False"></asp:TextBox>                       
                        <br />
                    </div>
                    <br />
                    <div id = "NuevaUbicacion" runat ="server" visible ="False">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Nueva Ubicación:  " 
                            Enabled="False"></asp:Label>
                        <asp:ListBox ID="lstUbica" runat="server" AutoPostBack="True" Rows="1" 
                            onselectedindexchanged="Ubica_SelectedIndexChanged">
                            <asp:ListItem>Plataforma</asp:ListItem>
                            <asp:ListItem>Bodega</asp:ListItem>
                            <asp:ListItem>Mantenimiento</asp:ListItem>
                            <asp:ListItem>Chatarra</asp:ListItem>
                            <asp:ListItem>Vehículo</asp:ListItem>
                        </asp:ListBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " visible="false"></asp:Label>
                        <asp:ListBox ID="lstPlacaVehiculo" runat="server" AutoPostBack="True" Rows="1" visible="false">
                            <asp:ListItem>XHA913</asp:ListItem>
                            <asp:ListItem>XHA123</asp:ListItem>
                            <asp:ListItem>ABC1000</asp:ListItem>
                            <asp:ListItem>VBG456</asp:ListItem>
                            <asp:ListItem>LDEO650</asp:ListItem>
                            <asp:ListItem>AWA789</asp:ListItem>
                        </asp:ListBox>
                        </div>
       </fieldset><p class="submitButton">
                    <asp:Button ID="btnCambiar" runat="server" Text="Cambiar Ubicación" Width="140px" 
                    Visible="False" onclick="Cambiar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" 
                    Width="140px" Visible="False" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="140px" 
                    Visible="False" onclick="btnCancelar_Click"/> 
                    </p>
       </div>
  </div> 
</asp:Content>
