<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ViewStateMode="Enabled" CodeBehind="frmNuevaUbicacion.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes.frmNuevaUbicacion" %>
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

                       &nbsp;<asp:ValidationSummary ID="NuevaUbicValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="NuevaUbic" Font-Size = "Small"/>
                       <p>

                       <asp:Label ID="lblNuevaDireccion" runat="server" Text="Nueva Dirección: "></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                      <asp:Label ID="lblNuevoBarrio" runat="server" Text="Barrio:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                      <br />
                      <asp:TextBox ID="txtNuevaDireccion" CssClass="textEntry"  runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ValidarDir" runat="server" ControlToValidate="txtNuevaDireccion" CssClass="failureNotification" 
                     ErrorMessage="La nueva dirección del cliente es obligatoria." ToolTip="La nueva dirección del cliente es obligatoria." 
                     ValidationGroup="NuevaUbic">*</asp:RequiredFieldValidator>
<%--                     <asp:RegularExpressionValidator ID="ValidarDatosDir" runat="server" ControlToValidate="txtNuevaDireccion" 
                    CssClass="failureNotification" ErrorMessage="La dirección debe contener sólo caracteres alfanuméricos. Ej, Calle 43 N 2 56"  
                    ValidationGroup="NuevaUbic" ValidationExpression="\w{1,20}\ \d{1,3}\ N \d{1,3}\ \d{1,3}" >*</asp:RegularExpressionValidator>
                    --%>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                       <asp:TextBox ID="txtNuevoBarrio" CssClass="textEntry" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="ValidarBarrio" runat="server" ControlToValidate="txtNuevoBarrio" CssClass="failureNotification" 
                     ErrorMessage="El nombre del barrio es obligatorio." ToolTip="El nombre del barrio es obligatorio." 
                     ValidationGroup="NuevaUbic">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosBarrio" runat="server" ControlToValidate="txtNuevoBarrio" 
                    CssClass="failureNotification" ErrorMessage="El barrio debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="NuevaUbic" >*</asp:RegularExpressionValidator>
                    
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       <asp:TextBox ID="txtTelefono" CssClass="textEntry" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidarTel" runat="server" ControlToValidate="txtTelefono" CssClass="failureNotification" 
                     ErrorMessage="El teléfono del cliente es obligatorio." ToolTip="El teléfono del cliente es obligatorio." 
                     ValidationGroup="NuevaUbic">*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarDatosTel" runat="server" ControlToValidate="txtTelefono" 
                    CssClass="failureNotification" ErrorMessage="El número de teléfono (fijo o móvil) debe contener entre 7 y 10 dígitos." 
                        ValidationExpression="^([\d]{7,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="NuevaUbic" >*</asp:RegularExpressionValidator>
                     
               </p>
               <p>
               <asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label>
                       
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
               <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label>
                            <br />
               <asp:ListBox ID="lstDepartamento" runat="server" Rows="1" AutoPostBack="true" Width="169px"
                       onselectedindexchanged="lstDepartamento_SelectedIndexChanged">
                            <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                           <asp:RequiredFieldValidator ID="ValidarDep" runat="server" ControlToValidate="lstDepartamento" CssClass="failureNotification" 
                     ErrorMessage="La selección del departamento es obligatoria." ToolTip="La selección del departamento es obligatoria." 
                     ValidationGroup="NuevaUbic"> * </asp:RequiredFieldValidator>
                     
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:ListBox ID="lstCiudad" runat="server" Rows="1"   AutoPostBack="false" Width="169px"
                       onselectedindexchanged="lstCiudad_SelectedIndexChanged">
                            <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                     <asp:RequiredFieldValidator ID="ValidarCiudad" runat="server" ControlToValidate="lstCiudad" CssClass="failureNotification" 
                     ErrorMessage="La selección de la ciudad es obligatoria." ToolTip="La selección de la ciudad es obligatoria." 
                     ValidationGroup="NuevaUbic"> * </asp:RequiredFieldValidator>
                     
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:Label ID="lblCedula" runat="server" Visible="false"></asp:Label>
                     
              </p> 
                </fieldset>
                <p class="submitButton">
                 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" 
                        Width="115px" onclick="btnGuardar_Click" Visible="false" ValidationGroup="NuevaUbic"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnAtras" runat="server" Text="Atrás" 
                        Width="115px" onclick="btnAtras_Click" /> 
                    </p>
            </div>
</asp:Content>
