<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarContratista.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos.frmRegistrarContratista" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Registrar Contratista</h1>
        <asp:ValidationSummary ID="RegistrarContratistaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarContratistaValidationGroup" Font-Size = "Small"/>
        <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>
        
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Contratista</legend>
                        <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del Contratista es obligatorio." ToolTip="El número de cédula del conductor es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="ValidarCedula" ></asp:RegularExpressionValidator>
                    
                    </p>
                    <div id="divInfoContratista" runat="server" visible="false">
                    <div class="post">
                    
                     Datos Personales del Contratista</div>
                     <p>
                   <asp:Label ID="lblCedulaCont" runat="server" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedulaCont" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidarCedulaCont" runat="server" ControlToValidate="txtCedulaCont" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del Contratista es obligatorio." ToolTip="El número de cédula del Contratista es obligatorio." 
                             ValidationGroup="RegistrarContratistaValidationGroup">*</asp:RequiredFieldValidator>
                     </p>
                    <p>
                        <asp:Label ID="lblNombreContratista" runat="server" AssociatedControlID="txtNombreContratista" >Nombres del Contratista:</asp:Label><br />
                        <asp:TextBox ID="txtNombreContratista" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtNombreContratistaRequired" runat="server" ControlToValidate="txtNombreContratista" 
                             CssClass="failureNotification" ErrorMessage="El nombre del Contratista es obligatorio." ToolTip="El nombre del Contratista es obligatorio." 
                             ValidationGroup="RegistrarContratistaValidationGroup">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="ValidarDatosNom" runat="server" ControlToValidate="txtNombreContratista" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="RegistrarContratistaValidationGroup" >*</asp:RegularExpressionValidator>
                    
                    </p>
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Apellidos:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtPrimerApellidoRequired" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del Contratista es obligatorio." ToolTip="El apellido del Contratista es obligatorio." 
                             ValidationGroup="RegistrarContratistaValidationGroup">*</asp:RequiredFieldValidator>

                             <asp:RegularExpressionValidator ID="ValidarDatosApe" runat="server" ControlToValidate="txtPrimerApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="RegistrarContratistaValidationGroup" >*</asp:RegularExpressionValidator>
                    
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                                                        
                    </p> 
                    <p validationexpression="\w">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtDirecciónRequired" runat="server" ControlToValidate="txtDireccion" 
                             CssClass="failureNotification" ErrorMessage="La dirección del Contratista es obligatoria." ToolTip="La dirección del Contratista es obligatoria." 
                             ValidationGroup="RegistrarContratistaValidationGroup">*</asp:RequiredFieldValidator>
                                      </p> 
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    <br />
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTelefonoRequiredField" runat="server" ControlToValidate="txtTelefono" 
                             CssClass="failureNotification" ErrorMessage="El teléfono del Contratista es obligatorio." ToolTip="El teléfono del Contratista es obligatorio." 
                             ValidationGroup="RegistrarContratistaValidationGroup">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="ValidarDatosTel" runat="server" ControlToValidate="txtTelefono" 
                    CssClass="failureNotification" ErrorMessage="El número de teléfono (fijo o móvil) debe contener entre 7 y 10 dígitos." 
                        ValidationExpression="^([\d]{7,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarContratistaValidationGroup" >*</asp:RegularExpressionValidator>
                   
                    </p>
                    </div>
                  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="115px" 
                        onclick="btnLimpiar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" ValidationGroup="RegistrarContratistaValidationGroup" 
                        Width="115px" onclick="btnGuardar_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" Width="115px" 
                        onclick="btnMenuPrincipal_Click"/>
               </p>
            </div>
</asp:Content>
