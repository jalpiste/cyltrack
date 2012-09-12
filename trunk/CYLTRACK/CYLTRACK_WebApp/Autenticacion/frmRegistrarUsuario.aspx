<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmRegistrarUsuario.aspx.cs" Inherits="CYLTRACK_WebApp.Autenticacion.frmRegistrarUsuario" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
                 <h1 style="margin-top:75px">
                     Crear una nueva cuenta
                </h1>
                    <div style="width: 381px">
                        Las contraseñas deben tener una longitud mínima de
                        <%= Membership.MinRequiredPasswordLength %>&nbsp;caracteres.
                    </div>
                    <span class="failureNotification">
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup" Width="385px"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Información de cuenta</legend>
                         <div style="width: 444px; margin-bottom: 0px;"> 
                             <asp:Label ID="lblUserName" runat="server" Text="Nombre de usuario:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtUserName" runat="server" CssClass="textEntry" Width="320px" 
                                ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="UserRequired" runat="server" 
                                 ControlToValidate="txtUserName" CssClass="failureNotification" 
                                 ErrorMessage="El nombre de usuario es obligatorio." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                             <asp:RequiredFieldValidator ID="DisponibleRequired" runat="server" 
                                 ControlToValidate="txtUserName" CssClass="failureNotification" 
                                 ErrorMessage="El nombre de usuario no está disponible. Inténtelo con otro nombre." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator> 
                             <br />
                             <asp:Label ID="lblPass" runat="server" Text="Contraseña:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" 
                                 TextMode="Password" Width="320px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                 ControlToValidate="txtPassword" CssClass="failureNotification" 
                                 ErrorMessage="La contraseña es obligatoria." 
                                 ToolTip="La contraseña es obligatoria." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblConfirmPass" runat="server" Text="Confirmar contraseña:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="passwordEntry" 
                                TextMode="Password" Width="320px" 
                                ></asp:TextBox>
                             <asp:RequiredFieldValidator ControlToValidate="txtConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirmar contraseña es obligatorio." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirmar contraseña es obligatorio." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                             <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                 ControlToCompare="txtConfirmPassword" ControlToValidate="txtPassword" 
                                 CssClass="failureNotification" Display="Dynamic" 
                                 ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                             <br />
                             <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="passwordEntry" 
                                 Width="320px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                 ControlToValidate="txtEmail" CssClass="failureNotification" 
                                 ErrorMessage="El correo electrónico es obligatorio." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            <br /><br />
                      <div id= "DatosPersonales" runat ="server"> 
                             <div class="post" >
                             <asp:Label ID="LblPoster" runat="server" Text="Datos Personales"></asp:Label>
                               </div> 
                             <asp:Label ID="lblNombre" runat="server" Text="Nombres: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtNombre" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="NombreRequired" runat="server" 
                                 ControlToValidate="txtNombre" CssClass="failureNotification" 
                                 ErrorMessage="El nombre es obligatorio." 
                                 ToolTip="El nombre es obligatorio." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblApellidos" runat="server" Text="Apellidos: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtApellidos" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ControlToValidate="txtApellidos" CssClass="failureNotification" 
                                 ErrorMessage="El apellido es obligatorio." 
                                 ToolTip="El apellido es obligatorio." 
                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <br />
                             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Width="150px"></asp:TextBox>
                             <br />
                             <asp:Label ID="lblGenero" runat="server" Text="Sexo: "></asp:Label>
                             <br />
                             <asp:ListBox ID="lstGenero" runat="server" AutoPostBack="True" Rows="1" >
                             <asp:ListItem>Hombre</asp:ListItem>
                             <asp:ListItem>Mujer</asp:ListItem>
                             <asp:ListItem>Sin Especificar</asp:ListItem>
                             </asp:ListBox>
                             <br />
                             <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento: "></asp:Label>
                             <br />
                             <asp:ListBox ID="lstDia" runat="server" AutoPostBack="True" Rows="1" Width="70px">
                             <asp:ListItem>Día</asp:ListItem>
                             </asp:ListBox>
                             &nbsp;&nbsp;&nbsp;
                             <asp:ListBox ID="lstMes" runat="server" AutoPostBack="True" Rows="1" Width="100px">
                             <asp:ListItem>Mes</asp:ListItem>
                             </asp:ListBox>
                             &nbsp;&nbsp;&nbsp;
                             <asp:ListBox ID="ListAno" runat="server" AutoPostBack="True" Rows="1" Width="70px">
                             <asp:ListItem>Año</asp:ListItem>
                             </asp:ListBox>
                             <br />
                          <asp:Label ID="lblCargo" runat="server" Text="Perfil: "></asp:Label>
                          <br />
                          <asp:ListBox ID="lstCargo" runat="server" AutoPostBack="True" Rows="1" Width="200px">
                             <asp:ListItem>Seleccione un cargo</asp:ListItem>
                             </asp:ListBox>
                             
                         </div>
                             </div>
                             </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="btnCreateUserButton" runat="server" Text="Crear usuario" Width="115px"
                           ValidationGroup="RegisterUserValidationGroup"  />
                        </p>
                    </div>
               
</asp:Content>
