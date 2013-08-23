<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="frmRegistrarUsuario.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion.frmRegistrarUsuario" %>

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
                    <asp:ValidationSummary ID="RegistrarUsuarios" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegistrodeUsuarios" Width="385px"/>
                    <div class="accountInfo">
                        <fieldset class="register">
                            <legend>Información de cuenta</legend>
                         <div style="width: 444px; margin-bottom: 0px;"> 
                             <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de usuario:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="textEntry" Width="320px" 
                                ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="UserRequired" runat="server" 
                                 ControlToValidate="txtNombreUsuario" CssClass="failureNotification" 
                                 ErrorMessage="El nombre de usuario es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblContrasena" runat="server" Text="Contraseña:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtContrasena" runat="server" CssClass="passwordEntry" 
                                 TextMode="Password" Width="320px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                 ControlToValidate="txtContrasena" CssClass="failureNotification" 
                                 ErrorMessage="La contraseña es obligatoria." 
                                 ToolTip="La contraseña es obligatoria." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblConfirmarContrasena" runat="server" Text="Confirmar contraseña:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtConfirmarContrasena" runat="server" CssClass="passwordEntry" 
                                TextMode="Password" Width="320px" 
                                ></asp:TextBox>
                              <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="txtContrasena"
                        ControlToValidate="txtConfirmarContrasena" CssClass="failureNotification" Display="Dynamic"
                        ErrorMessage="Contraseña y Confirmar contraseña deben coincidir." ValidationGroup="RegistrodeUsuarios"
                       >*</asp:CompareValidator>
                       <br />
                             <asp:Label ID="lblCorreo" runat="server" Text="Correo electrónico:"></asp:Label>
                             <br />
                             <asp:TextBox ID="txtEmail" runat="server" CssClass="passwordEntry" 
                                 Width="320px" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                 ControlToValidate="txtEmail" CssClass="failureNotification" 
                                 ErrorMessage="El correo electrónico es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                                 <asp:regularexpressionvalidator ID="revEmail" runat="server" ControlToValidate="txtEmail" CssClass="failureNotification"
                                 ErrorMessage="Formato de correo no valido" ValidationGroup="RegistrodeUsuarios" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">**</asp:regularexpressionvalidator>
                            <br /><br />
                      <div id= "DatosPersonales" runat ="server"> 
                             <div class="post" >
                             <asp:Label ID="LblPoster" runat="server" Text="Datos Personales"></asp:Label>
                               </div> 
                            
                             <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredCedula" runat="server" 
                                 ControlToValidate="txtCedula" CssClass="failureNotification" 
                                 ErrorMessage="El número de cédula es obligatorio." 
                                 ToolTip="El número de cédula es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                            <br />
                            
                             
                             <asp:Label ID="lblNombre" runat="server" Text="Nombre: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtNombre" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="NombreRequired" runat="server" 
                                 ControlToValidate="txtNombre" CssClass="failureNotification" 
                                 ErrorMessage="El nombre es obligatorio." 
                                 ToolTip="El nombre es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblApellidos" runat="server" Text="Apellido: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtApellidos" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                 ControlToValidate="txtApellidos" CssClass="failureNotification" 
                                 ErrorMessage="El apellido es obligatorio." 
                                 ToolTip="El apellido es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblDireccion" runat="server" Text="Dirección: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="320px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                 ControlToValidate="txtApellidos" CssClass="failureNotification" 
                                 ErrorMessage="La dirección del usuario es obligatoria." 
                                 ToolTip="la dirección del usuario es obligatoria." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
                             <br />
                             <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Width="150px"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                 ControlToValidate="txtApellidos" CssClass="failureNotification" 
                                 ErrorMessage="El telefono del usuario es obligatorio." 
                                 ToolTip="El telefono del usuario es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblGenero" runat="server" Text="Sexo: "></asp:Label>
                             <br />
                             <asp:ListBox ID="lstGenero" runat="server" AutoPostBack="True" Rows="1" 
                                 onselectedindexchanged="lstGenero_SelectedIndexChanged" />
                             <asp:RequiredFieldValidator ID="validSexo" runat="server" 
                                 ControlToValidate="lstGenero" CssClass="failureNotification" 
                                 ErrorMessage="Elegir el sexo es obligatorio." 
                                 ToolTip="Elegir el sexo es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                             <asp:Label ID="lblFechaNacimiento" runat="server" Text="Fecha de nacimiento: "></asp:Label>
                             <br />
                             <asp:ListBox ID="lstDia" runat="server" AutoPostBack="True" Rows="1" 
                                 Width="70px" onselectedindexchanged="lstDia_SelectedIndexChanged"/>
                            <asp:RequiredFieldValidator ID="validDia" runat="server" 
                                 ControlToValidate="lstDia" CssClass="failureNotification" 
                                 ErrorMessage="El dia de nacimiento es obligatorio." 
                                 ToolTip="El dia de nacimiento es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             &nbsp;&nbsp;&nbsp;
                             <asp:ListBox ID="lstMes" runat="server" AutoPostBack="True" Rows="1" 
                                 Width="100px" onselectedindexchanged="lstMes_SelectedIndexChanged">
                             <asp:ListItem>Mes</asp:ListItem>
                             </asp:ListBox>
                              <asp:RequiredFieldValidator ID="validMes" runat="server" 
                                 ControlToValidate="lstMes" CssClass="failureNotification" 
                                 ErrorMessage="El mes de nacimiento es obligatorio." 
                                 ToolTip="El mes de nacimiento es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                           
                             &nbsp;&nbsp;&nbsp;
                             <asp:ListBox ID="lstAno" runat="server" AutoPostBack="True" Rows="1" 
                                 Width="70px" onselectedindexchanged="lstAno_SelectedIndexChanged" />
                             <asp:RequiredFieldValidator ID="validAno" runat="server" 
                                 ControlToValidate="lstAno" CssClass="failureNotification" 
                                 ErrorMessage="El año de nacimiento es obligatorio." 
                                 ToolTip="El año de nacimiento es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             <br />
                          <asp:Label ID="lblCargo" runat="server" Text="Perfil: "></asp:Label>
                          <br />
                          <asp:ListBox ID="lstCargo" runat="server" AutoPostBack="True" Rows="1" 
                                 Width="200px" onselectedindexchanged="lstCargo_SelectedIndexChanged">
                             <asp:ListItem>Seleccione un cargo</asp:ListItem>
                             </asp:ListBox>
                             <asp:RequiredFieldValidator ID="validCargo" runat="server" 
                                 ControlToValidate="lstCargo" CssClass="failureNotification" 
                                 ErrorMessage="El perfil es obligatorio." 
                                 ToolTip="El perfil es obligatorio." 
                                 ValidationGroup="RegistrodeUsuarios">*</asp:RequiredFieldValidator>
                             
                             
                         </div>
                             </div>
                             </fieldset>
                        <p class="submitButton">
                            <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear usuario" Width="115px"
                           ValidationGroup="RegistrodeUsuarios" 
                                onclick="btnCrearUsuario_Click"  />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                                onclick="btnMenu_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    </div>
               
</asp:Content>
