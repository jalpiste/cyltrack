﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarConductor.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos.frmRegistrarConductor" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Registrar Conductor
    </h1>
        <asp:ValidationSummary ID="RegistrarConductorValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarConductorValidationGroup" Font-Size = "Small"/>
        <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>
        
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Conductor</legend>
                        <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del conductor es obligatorio." ToolTip="El número de cédula del conductor es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="ValidarCedula" ></asp:RegularExpressionValidator>
                    
                    </p>
                    <div id="divInfoConductor" runat="server" visible="false">
                    <div class="post">
                    
                     Datos Personales del Conductor</div>
                     <p>
                   <asp:Label ID="lblCedulaCond" runat="server" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedulaCond" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ValidarCedulaCond" runat="server" ControlToValidate="txtCedulaCond" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del conductor es obligatorio." ToolTip="El número de cédula del conductor es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>
                     </p>
                    <p>
                        <asp:Label ID="lblNombreConductor" runat="server" AssociatedControlID="txtNombreConductor" >Nombre del Conductor:</asp:Label><br />
                        <asp:TextBox ID="txtNombreConductor" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtNombreConductorRequired" runat="server" ControlToValidate="txtNombreConductor" 
                             CssClass="failureNotification" ErrorMessage="El nombre del Conductor es obligatorio." ToolTip="El nombre del Conductor es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="ValidarDatosNom" runat="server" ControlToValidate="txtNombreConductor" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"    
                    ValidationGroup="RegistrarConductorValidationGroup" >*</asp:RegularExpressionValidator>
                    
                    </p>
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:" ></asp:Label>
                   <br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtPrimerApellidoRequired" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del Conductor es obligatorio." ToolTip="El apellido del Conductor es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>

                             <asp:RegularExpressionValidator ID="ValidarDatosApe" runat="server" ControlToValidate="txtPrimerApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarConductorValidationGroup" >*</asp:RegularExpressionValidator>
                    
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                            <asp:TextBox ID="txtSegundoApellido"  runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="ValidarDatosApe2" runat="server" ControlToValidate="txtSegundoApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"   
                    ValidationGroup="RegistrarConductorValidationGroup" >*</asp:RegularExpressionValidator>
                    
                            
                    </p> 
                    <p validationexpression="\w">
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:"  ></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtDirecciónRequired" runat="server" ControlToValidate="txtDireccion" 
                             CssClass="failureNotification" ErrorMessage="La dirección del Conductor es obligatoria." ToolTip="La dirección del Conductor es obligatoria." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" 
                                Width="197px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtBarrioRequired" runat="server" ControlToValidate="txtBarrio" 
                             CssClass="failureNotification" ErrorMessage="El barrio es obligatorio." ToolTip="El barrio es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>

                              <asp:RegularExpressionValidator ID="ValidarDatosBarrio" runat="server" ControlToValidate="txtBarrio" 
                    CssClass="failureNotification" ErrorMessage="El barrio debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="RegistrarConductorValidationGroup" >*</asp:RegularExpressionValidator>
                    
                         </p> 
                         <p><asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label>
                            <br />
                        <asp:ListBox ID="lstDepartamento" runat="server" Rows="1" AutoPostBack="True"  onselectedindexchanged="lstDepartamento_SelectedIndexChanged" 
                                 >
                        </asp:ListBox>
                            <asp:RequiredFieldValidator ID="lstDepartamentoRequired" runat="server" ControlToValidate="lstDepartamento" 
                             CssClass="failureNotification" ErrorMessage="El departamento es obligatorio." ToolTip="El departamento es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>
                       
                        </p>
                    
                    <p><asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label>
                    <br />
                        <asp:ListBox ID="lstCiudad" runat="server" Rows="1" 
                            >
                        </asp:ListBox>
                     <asp:RequiredFieldValidator ID="lstCiudadRequired" runat="server" ControlToValidate="LstCiudad" 
                             CssClass="failureNotification" ErrorMessage="La ciudad es obligatorio." ToolTip="La ciudad es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>
                            </p>  
                        
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    <br />
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTelefonoRequiredField" runat="server" ControlToValidate="txtTelefono" 
                             CssClass="failureNotification" ErrorMessage="El teléfono del Conductor es obligatorio." ToolTip="El teléfono del Conductor es obligatorio." 
                             ValidationGroup="RegistrarConductorValidationGroup">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="ValidarDatosTel" runat="server" ControlToValidate="txtTelefono" 
                    CssClass="failureNotification" ErrorMessage="El número de teléfono (fijo o móvil) debe contener entre 7 y 10 dígitos." 
                        ValidationExpression="^([\d]{7,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarConductorValidationGroup" >*</asp:RegularExpressionValidator>
                   
                    </p>
                    </div>
                  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="115px" 
                        onclick="btnLimpiar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" ValidationGroup="RegistrarConductorValidationGroup" 
                        Width="115px" onclick="btnGuardar_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" Width="115px" 
                        onclick="btnMenuPrincipal_Click"/>
               </p>
            </div>
</asp:Content>
