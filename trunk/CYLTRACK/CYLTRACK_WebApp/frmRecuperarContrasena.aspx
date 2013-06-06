<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRecuperarContrasena.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.frmRecuperarContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 837px; margin-right: 45px;">
       <h1> 
        Recuperar Contraseña
       </h1>
       <br />
       Digite su nombre de usuario y a continuacion seleccione el botón enviar
       <br />
       <span class="failureNotification">
       <asp:Literal ID="FailureText" runat="server"></asp:Literal>
       </span>       
      
       <asp:ValidationSummary ID="RecuperarContrasena" runat="server" CssClass="failureNotification" 
                         ValidationGroup="OlvidoContrasena" Width="385px"/>
       <div class="accountInfo"> 
       <fieldset class="login">
       <legend>Olvidó Contraseña</legend>
       <div id="DivCodigo" runat="server" visible="true">
           <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario:"></asp:Label>
           <br /> 
           <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="textEntry" Width="197px"  
           ValidationGroup = "OlvidoContrasena"></asp:TextBox>
           <asp:RequiredFieldValidator ID="NombreUsuarioRequired" runat="server" 
           ControlToValidate="txtNombreUsuario" CssClass="failureNotification" 
           ErrorMessage="El nombre de usuario es obligatorio" ToolTip="El nombre de usuario es obligatorio" 
           ValidationGroup="OlvidoContrasena">*</asp:RequiredFieldValidator>          
                         
       </div> 
       
                  
       </fieldset><p class="submitButton">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                    Width="140px" onclick="btnEnviar_Click" ValidationGroup="OlvidoContrasena"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="BtnMenu" runat="server" Text="Menú Principal" Width="140px" onclick="BtnMenu_Click" 
                    /> 
                    </p>
       </div>
  </div> 
</asp:Content>
