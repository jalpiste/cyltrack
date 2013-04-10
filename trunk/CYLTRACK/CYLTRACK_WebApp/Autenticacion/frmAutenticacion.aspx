<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmAutenticacion.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion.frmAutenticacion" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Iniciar sesión
    </h1>
        <%-- <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
                ValidationGroup="LoginUserValidationGroup" Width="385px"/>--%>
        <div class="accountInfo">
            <fieldset class="login" style="width: 444px">
                <legend>Información de cuenta</legend>
                <div style="width: 425px; margin-bottom: 0px; margin-left: 40px;">
                    <asp:Label ID="lblUserName" runat="server" Text="Nombre de usuario:"
                        Width="124px"></asp:Label>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="txtUserName"
                        CssClass="failureNotification" ErrorMessage="El nombre de usuario es obligatorio."
                        ToolTip="El nombre de usuario es obligatorio." ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" ontextchanged="txtPassword_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="txtPassword"
                        CssClass="failureNotification" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria."
                        ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    <br />
                   
                    <a href="~/frmRecuperarContrasena.aspx" ID="lnkRecuperarContrasena" runat="server">Olvidó Contraseña</a>
                    <br />
                    <asp:CheckBox ID="RememberMe" runat="server"  />
                    <br />
                    <asp:Label ID="lblRememberMe" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Mantener la sesion iniciada</asp:Label>
                    <br />
                    <h3>
                        <asp:Label ID="lblPrimeraVez" runat="server" Text="Ingreso por primera vez. Por favor digite su nueva contraseña."
                            Width="430px" Visible="False"></asp:Label></h3>
                    <br />
                    <asp:Label ID="lblNewPassword" runat="server" Text="Nueva contraseña:" Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtNuevaContraseña" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="PasswordRequired1" runat="server" ControlToValidate="txtNuevaContraseña"
                        CssClass="failureNotification" ErrorMessage="La nueva contraseña es obligatoria."
                        ValidationGroup="LoginUserValidationGroup" Visible="False">*</asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:Label ID="lblConfirmPass" runat="server" Text="Confirmar nueva contraseña:"
                        Visible="False"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"
                        Width="320px" Visible="False"></asp:TextBox>
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtConfirmPassword"
                        ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic"
                        ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ValidationGroup="RegisterUserValidationGroup"
                        Visible="False">*</asp:CompareValidator>
                    <br />
                    <asp:Label ID="lblNota" runat="server" Text="Nueva contraseña y Confirmar nueva contraseña deben coincidir."
                        Width="400px" Visible="False"></asp:Label>
                    <br />
                </div>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnLoginButton" runat="server" CommandName="Login" Text="Iniciar sesión"
                    Width="115px" ValidationGroup="LoginUserValidationGroup" />
            </p>
        </div>
    </asp:Content>
