<%@ Page Title="Olvido Contraseña" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOlvidoContrasena.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion.frmOlvidoContrasena" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   <div style="width: 637px">
       <div>
           <h1 style="margin-top: 75px">
       ¿Olvidó su contraseña?
           </h1>
       </div> 
       <br />
       <asp:Label ID="lblIndicación" runat="server" Text="Digite su nombre de usuario y a continuación haga click en enviar." Width="400px"></asp:Label>
       <br />
       <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>       
       <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup" Width="385px"/>
       <br />
       <asp:Label ID="lblUsNa" runat="server" Text="Nombre de usuario:"></asp:Label>
       <br />
       <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
       <asp:RequiredFieldValidator ID="UserRequired" runat="server" 
        ControlToValidate="txtUserName" CssClass="failureNotification" 
        ErrorMessage="El nombre de usuario es obligatorio." 
        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
       <br />
       <br />
       <br />
     <p class="submitButton">                 
       <asp:Button ID="btnEnvíoInformación" runat="server" Text="Enviar" Width="115px" 
       ValidationGroup="RegisterUserValidationGroup" />
       </p>
       <br />
       </div>
   <div>
    <h3>
        <asp:Label ID="lblAviso" runat="server" 
            Text="¡Comuníquese con el administrador del sistema!"></asp:Label>
    </h3>
    </div>
</asp:Content>
