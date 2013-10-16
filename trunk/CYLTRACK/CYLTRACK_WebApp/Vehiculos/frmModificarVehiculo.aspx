﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarVehiculo.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos.frmModificarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Modificar Vehículo
                </h1>
            <asp:ValidationSummary ID="ModificarVehiculoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarVehiculo" Font-Size = "Small"/>
            <asp:ValidationSummary ID="ValidarPlacaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarPlaca" Font-Size = "Small"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>
               
              <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificar Vehículo</legend>
                    <asp:Label ID="lblPlaca" runat="server" Text="Placa: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPlaca" runat="server" CssClass="textEntry" Width="100px" 
                        ontextchanged="txtPlaca_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarPlaca" runat="server" 
                        ControlToValidate="txtPlaca" CssClass="failureNotification" 
                     ErrorMessage="La placa del vehículo es obligatoria." ToolTip="La placa del vehículo es obligatoria." 
                     ValidationGroup="ValidarPlaca" Font-Size = "Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    
                    <asp:RegularExpressionValidator ID="ValidarDatosPlaca" runat="server" ControlToValidate="txtPlaca" 
                    CssClass="failureNotification" 
                    ErrorMessage="La placa debe contener 3 letras y 3 dígitos." ToolTip="3 letras y 3 números" 
                    ValidationExpression="\w{3}(\d{3})" Font-Size = "Small"
                        ValidationGroup="ValidarPlaca" Display="Dynamic" ></asp:RegularExpressionValidator>                    
                    <br />
                      <div id="DivDatosVehiculo" runat ="server" visible="false">
                      <div class="post">
                          <asp:Label ID="lblPoster" runat="server" Text="Datos Vehículo" ></asp:Label>
                      </div>
                      <asp:Label ID="lblIdVehiculo" runat="server" Text="Placa: "></asp:Label>                       
                      <br />
                      <asp:TextBox ID="txtIdVehiculo" runat="server" CssClass="textEntry" Width="100px" Font-Names="Engravers MT"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="ValidarRegisPlaca" runat="server" ControlToValidate="txtIdVehiculo" 
                             CssClass="failureNotification" ErrorMessage="La placa del vehículo es obligatoria." ToolTip="La placa del vehículo es obligatoria." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    
                    <asp:RegularExpressionValidator ID="ValidarDatosIdVehiculo" runat="server" ControlToValidate="txtIdVehiculo" 
                    CssClass="failureNotification" 
                    ErrorMessage="La placa debe contener 3 letras y 3 dígitos." ToolTip="3 letras y 3 números" 
                    ValidationExpression="\D{3}(\d{3})" 
                        ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>                    

                      <br /><br />
                      <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMarca" runat="server" CssClass= "textEntry" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisMarca" runat="server" ControlToValidate="txtMarca" 
                             CssClass="failureNotification" ErrorMessage="La marca del vehículo es obligatoria." ToolTip="La marca del vehículo es obligatoria." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosMarca" runat="server" ControlToValidate="txtMarca" 
                    CssClass="failureNotification" ErrorMessage="La marca debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^[A-Za-z]*$" 
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>
 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCilindraje" runat="server" CssClass= "textEntry" Width="90px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisCilindraje" runat="server" ControlToValidate="txtCilindraje" 
                             CssClass="failureNotification" ErrorMessage="El cilindraje del vehículo es obligatorio." ToolTip="El cilindraje del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosCilindraje" runat="server" ControlToValidate="txtCilindraje" 
                    CssClass="failureNotification" ErrorMessage="El cilindraje debe contener 4 dígitos." 
                        ValidationExpression="\d{4}" ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtModelo" runat="server" CssClass= "textEntry" Width="90px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisModelo" runat="server" ControlToValidate="txtModelo" 
                             CssClass="failureNotification" ErrorMessage="El modelo del vehículo es obligatorio." ToolTip="El modelo del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="ValidarDatosModelo" runat="server" ErrorMessage="El modelo debe contener un valor numérico correcto" 
                    ControlToValidate="txtModelo" MaximumValue="2025" MinimumValue="1980" Type="Integer" CssClass="failureNotification" 
                    ValidationGroup="ModificarVehiculo">*</asp:RangeValidator>
                    
                    <br /><br />
                    <asp:Label ID="lblMotor" runat="server" Text="No. Motor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblChasis" runat="server" Text="No. Chasis: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMotor" runat="server" CssClass= "textEntry"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisMotor" runat="server" ControlToValidate="txtMotor" 
                             CssClass="failureNotification" ErrorMessage="El número de motor del vehículo es obligatorio." ToolTip="El número de motor del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtChasis" runat="server" CssClass= "textEntry" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisChasis" runat="server" ControlToValidate="txtChasis" 
                             CssClass="failureNotification" ErrorMessage="El número de chasis del vehículo es obligatorio." ToolTip="El número de chasis del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    
                </div> 

                <div id = "DivPropietario" runat ="server" visible="false" >
                <div class="post">
                          <asp:Label ID="lblPoster1" runat="server" Text="Información de Propietario" ></asp:Label>
                </div> 
                    <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label>                
                    <br />
                    <asp:TextBox ID="txtCedula" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisCedulaProp" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del propietario del vehículo es obligatorio." ToolTip="El número de cédula del propietario del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosCedulaProp" runat="server" ControlToValidate="txtCedula" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    <br />
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  

                    <asp:TextBox ID="txtNombre" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarRegisNomProp" runat="server" ControlToValidate="txtNombre" 
                             CssClass="failureNotification" ErrorMessage="El nombre del propietario del vehículo es obligatorio." ToolTip="El nombre del propietario del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosNomProp" runat="server" ControlToValidate="txtNombre" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarRegisApeProp" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del propietario del vehículo es obligatorio." ToolTip="El apellido del propietario del vehículo es obligatorio." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosApeProp" runat="server" ControlToValidate="txtPrimerApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RegularExpressionValidator ID="ValidarDatosApePorp" runat="server" ControlToValidate="txtSegundoApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="ModificarVehiculo" >*</asp:RegularExpressionValidator>
                    
                      </div>
                        <%-------------------------------%>
                         <div id="DivConductorAsignado" class="post" runat="server" visible="false">
                        <asp:Label ID="lblPoster2" runat="server" Text="Conductor Asignado" ></asp:Label>
                      </div> 
                      <div id = "DivConductor" runat ="server" visible="false">
                    <asp:Label ID="lblCedulaCond" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    
                    <asp:TextBox ID="txtCedulaCond" runat="server" CssClass= "textEntry" Width="160px" 
                              ontextchanged="txtCedulaCond_TextChanged" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarAsigConductor" runat="server" ControlToValidate="txtCedulaCond" 
                    CssClass="failureNotification" 
                            ErrorMessage="El número de cédula del conductor es obligatorio." ToolTip="El número de cédula del conductor es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display="Dynamic" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosConductor" runat="server" ControlToValidate="txtCedulaCond" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="ValidarCedula" Font-Size = "Small" Display="Dynamic" ></asp:RegularExpressionValidator>
                    <br />
                     <h3>
                    <asp:Label ID="lblImprimirCedula" runat="server" ></asp:Label>
                    </h3>
                    <br />
                    <asp:Label ID="lblNombreCond" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellidoCond" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellidoCond" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  

                    <asp:TextBox ID="txtNombreCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellidoCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellidoCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    
                      </div> 
                 <div id= "DivAsigRuta" class="post" runat ="server" visible="false">
                          <asp:Label ID="lblPost" runat="server" Text="Ruta Asignada"></asp:Label>
                      </div> 
                 <div id="divDatosRuta" runat="server" visible="false">
                 <h3>
                    <asp:Label ID="lblNota" runat="server" Text="Seleccione la ruta a asignar."></asp:Label>
                 </h3> 
                 <br />            
                 <asp:ListBox ID="lstRuta" runat="server" AutoPostBack="True" Rows="1" 
                         visible="true" onselectedindexchanged="lstRuta_SelectedIndexChanged">
                                                    
                     </asp:ListBox>
                 
                 <br />
                 <br />
                     <asp:Label ID="lblRuta" runat="server" Text="Ruta: " ></asp:Label>
                     <br />
                     <asp:TextBox ID="txtRuta" runat="server" CssClass= "textEntry" Width="160px" Visible="true" Enabled = "false"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="ValidarRegisRuta" runat="server" ControlToValidate="txtRuta" 
                    CssClass="failureNotification" ErrorMessage="La selección de la ruta es obligatoria." ToolTip="La selección de la ruta es obligatoria." 
                             ValidationGroup="ModificarVehiculo">*</asp:RequiredFieldValidator>
                    
                  </div>  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" visible="false"
                        onclick="btnGuardar_Click" ValidationGroup="ModificarVehiculo"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>
               </p>
              </div>
                 
</asp:Content>
