<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarVehiculo.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas.frmRegistrarVehículo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        #DivPropietario
        {
            width: 709px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h1 style="margin-top:75px">
                     Registrar Vehículo
                </h1>
            
    
            <asp:ValidationSummary ID="RegistrarVehiculoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarVehiculo" Font-Size = "Small"/>
            <asp:ValidationSummary ID="ValidarPlacaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarPlaca" Font-Size = "Small"/>
            <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>

                <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Vehículo</legend>
                    <asp:Label ID="lblPlaca1" runat="server" Text="Placa: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPlaca1" runat="server" CssClass="textEntry" Width="100px" 
                        ontextchanged="txtPlaca1_TextChanged" Font-Strikeout="False" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarPlaca" runat="server" 
                        ControlToValidate="txtPlaca1" CssClass="failureNotification" 
                     ErrorMessage="La placa del vehículo es obligatoria." ToolTip="La placa del vehículo es obligatoria." 
                     ValidationGroup="ValidarPlaca" Font-Size = "Small" Display="Dynamic"></asp:RequiredFieldValidator>
                    
                    <asp:RegularExpressionValidator ID="ValidarDatosPlaca" runat="server" ControlToValidate="txtPlaca1" 
                    CssClass="failureNotification" 
                    ErrorMessage="La placa debe contener 3 letras y 3 dígitos." ToolTip="3 letras y 3 números" 
                    ValidationExpression="\w{3}(\d{3})" Font-Size = "Small"
                        ValidationGroup="ValidarPlaca" ></asp:RegularExpressionValidator>                    

                    
                <div id = "DivVehiculo" runat ="server" visible ="false">
                 <div class="post" >
                          <asp:Label ID="lblPoster" runat="server" Text="Datos Vehículo"></asp:Label>
                 </div> 
                    <asp:Label ID="lblPlaca" runat="server" Text="Placa: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPlaca" runat="server" CssClass="textEntry" Width="100px" 
                    Enabled ="false" Font-Names="Engravers MT" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisPlaca" runat="server" ControlToValidate="txtPlaca" 
                             CssClass="failureNotification" 
                        ErrorMessage="La placa del vehículo es obligatoria." ToolTip="La placa del vehículo es obligatoria." 
                             ValidationGroup="RegistrarVehiculo" >*</asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo: "></asp:Label>

                    <br />
                    <asp:TextBox ID="txtMarca" runat="server" CssClass= "textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisMarca" runat="server" ControlToValidate="txtMarca" 
                             CssClass="failureNotification" ErrorMessage="La marca del vehículo es obligatoria." ToolTip="La marca del vehículo es obligatoria." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosMarca" runat="server" ControlToValidate="txtMarca" 
                    CssClass="failureNotification" ErrorMessage="La marca debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^[A-Za-z]*$" 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCilindraje" runat="server" CssClass= "textEntry" Width="90px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisCilindraje" runat="server" ControlToValidate="txtCilindraje" 
                             CssClass="failureNotification" 
                        ErrorMessage="El cilindraje del vehículo es obligatorio." ToolTip="El cilindraje del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo" >*</asp:RequiredFieldValidator>
                    
                    <asp:RegularExpressionValidator ID="ValidarDatosCilindraje" runat="server" ControlToValidate="txtCilindraje" 
                    CssClass="failureNotification" ErrorMessage="El cilindraje debe contener 4 dígitos." 
                        ValidationExpression="\d{4}" ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtModelo" runat="server" CssClass= "textEntry" Width="90px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisModelo" runat="server" ControlToValidate="txtModelo" 
                             CssClass="failureNotification" ErrorMessage="El modelo del vehículo es obligatorio." ToolTip="El modelo del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                    <asp:RangeValidator ID="ValidarDatosModelo" runat="server" ErrorMessage="El modelo debe contener un valor numérico correcto" 
                    ControlToValidate="txtModelo" MaximumValue="2025" MinimumValue="1980" Type="Integer" SetFocusOnError="True" 
                    CssClass="failureNotification" ValidationGroup="RegistrarVehiculo">*</asp:RangeValidator>
                    
                    <br />
                    <asp:Label ID="lblMotor" runat="server" Text="No. Motor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblChasis" runat="server" Text="No. Chasis: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMotor" runat="server" CssClass= "textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisMotor" runat="server" ControlToValidate="txtMotor" 
                             CssClass="failureNotification" ErrorMessage="El número de motor del vehículo es obligatorio." ToolTip="El número de motor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtChasis" runat="server" CssClass= "textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisChasis" runat="server" ControlToValidate="txtChasis" 
                             CssClass="failureNotification" ErrorMessage="El número de chasis del vehículo es obligatorio." ToolTip="El número de chasis del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                </div> 
                <div id = "DivPropietario" runat ="server" visible ="false">
                     <div class="post" >
                          <asp:Label ID="lblPoster1" runat="server" Text="Información de Propietario"></asp:Label>
                      </div> 
                    <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedula" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarRegisCedulaProp" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del propietario del vehículo es obligatorio." ToolTip="El número de cédula del propietario del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosCedulaProp" runat="server" ControlToValidate="txtCedula" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    <br />
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  
                    <asp:TextBox ID="txtNombre" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarRegisNomProp" runat="server" ControlToValidate="txtNombre" 
                             CssClass="failureNotification" ErrorMessage="El nombre del propietario del vehículo es obligatorio." ToolTip="El nombre del propietario del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosNomProp" runat="server" ControlToValidate="txtNombre" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarRegisApeProp" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del propietario del vehículo es obligatorio." ToolTip="El apellido del propietario del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosApeProp" runat="server" ControlToValidate="txtPrimerApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <asp:RegularExpressionValidator ID="ValidarDatosApePorp" runat="server" ControlToValidate="txtSegundoApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                </div> 
                    
                    <div id="DivAsignacionConductor" runat="server" visible="false">
                    <div class="post" >
                        <asp:Label ID="lblPoster2" runat="server" Text="Asignación de Conductor"></asp:Label>
                      </div> 
                    <asp:Label ID="lblCedula1" runat="server" Text="Número de Cédula: " Visible="false"></asp:Label><br />
                    <asp:TextBox ID="txtCedula1" runat="server" CssClass= "textEntry" Width="160px" 
                        ontextchanged="txtCedula1_TextChanged" Visible="false"></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="ValidarAsigConductor" runat="server" ControlToValidate="txtCedula1" 
                    CssClass="failureNotification" 
                            ErrorMessage="El número de cédula del conductor es obligatorio." ToolTip="El número de cédula del conductor es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display="Dynamic" ></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosConductor" runat="server" ControlToValidate="txtCedula1" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="ValidarCedula" Font-Size = "Small" Display="Dynamic" ></asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 
                 <div id = "DatosConductor" runat ="server" visible ="false">
                    <h3>
                    <asp:Label ID="lblImprimirCedula" runat="server" Text="xxxxxxxxxxxxx" ></asp:Label>
                    </h3>
                    <br />
                    <asp:Label ID="lblNombreCond" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellidoCond" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellidoCond" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  
                    <asp:TextBox ID="txtNombreCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    </div> 
                    </div> 
                 <div id = "DivSelRuta" runat ="server" visible ="false">
                <div class="post" >
                          <asp:Label ID="lblPost" runat="server" Text="Asignación de Ruta"></asp:Label>
                      </div> 
                
                    <h3>
                    Seleccione la ruta a asignar.
                    </h3>
                    <br />
                     <asp:Label ID="lblRuta" runat="server" Text="Ruta: "></asp:Label>
                     <br />
                        <asp:ListBox ID="lstRuta" runat="server" AutoPostBack="True" Rows="1"  >
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Seleccionar</asp:ListItem>
                     </asp:ListBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisRuta" runat="server" ControlToValidate="lstRuta" 
                    CssClass="failureNotification" ErrorMessage="La selección de la ruta es obligatoria." ToolTip="La selección de la ruta es obligatoria." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                 </div>
                 </fieldset> 
                  <p class="submitButton">
                  <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                          onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" Visible="false" 
                        onclick="btnGuardar_Click" ValidationGroup="RegistrarVehiculo"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>
               </p>
                 </div> 
</asp:Content>
