<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmAutenticacion.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion.frmAutenticacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Iniciar sesión
    </h1>
      <asp:ValidationSummary ID="validacionAutenticacion" runat="server" CssClass="failureNotification"
              ValidationGroup="AutenticacionUsuarios" Width="385px"/>
              <div class="accountInfo">
            <fieldset class="login" style="width: 444px">
                <legend>Información de cuenta</legend>
                <div style="width: 425px; margin-bottom: 0px; margin-left: 40px;">
                <div id="divAutentica" runat="server" >
                    <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de usuario:"
                        Width="124px"></asp:Label>
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="textEntry" Width="320px" 
                        ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtNombreUsuario"
                        CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio."
                        ToolTip="El nombre de usuario es obligatorio." ValidationGroup="AutenticacionUsuarios">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtContrasena"
                        CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                        ValidationGroup="AutenticacionUsuarios">*</asp:RequiredFieldValidator>
                    <br />
                   
                    <a href="~/frmRecuperarContrasena.aspx" ID="lnkRecuperarContrasena" runat="server">Olvidó Contraseña</a>
                    <br />
                    <asp:CheckBox ID="ckbSesionIniciada" runat="server"  />
                    <br />
                    <asp:Label ID="lblSesionIniciada" runat="server" AssociatedControlID="ckbSesionIniciada" CssClass="inline">Mantener la sesion iniciada</asp:Label>
                    <br />
                    </div>
                    <div id="divPrimeraVez" runat="server" visible="false">
                    <h3>
                       Ingreso por primera vez. Por favor digite su nueva contraseña."</h3>
                    <br />
                    <asp:Label ID="lblNuevaContrasena" runat="server" Text="Nueva contraseña:" ></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired1" runat="server" ControlToValidate="txtNuevaContrasena"
                        CssClass="failureNotification" ErrorMessage="La nueva contraseña es obligatoria."
                        ValidationGroup="AutenticacionUsuarios">*</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lblConfirmarContrasena" runat="server" Text="Confirmar nueva contraseña:"
                        ></asp:Label>
                    <br />
                    <asp:TextBox ID="txtConfirmarContrasena" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" ></asp:TextBox>
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtConfirmarContrasena"
                        ControlToValidate="txtNuevaContrasena" CssClass="failureNotification" Display="Dynamic"
                        ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ValidationGroup="AutenticacionUsuarios"
                       >*</asp:CompareValidator>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnPrimeraVez" runat="server" CommandName="Login" Text="Iniciar sesión"
                    Width="115px" ValidationGroup="AutenticacionUsuarios" onclick="btnPrimeraVez_Click" />
           
                    </div>
                </div>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnIniciarSesion" runat="server" CommandName="Login" Text="Iniciar sesión"
                    Width="115px" ValidationGroup="AutenticacionUsuarios" 
                    onclick="btnIniciarSesion_Click" />
            </p>
        </div>
    </asp:Content>
