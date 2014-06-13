
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarVehiculo.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos.frmRegistrarVehiculo" %>
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
                    <asp:ListBox ID="lstModelo" runat="server" AutoPostBack="True" Rows="1" ></asp:ListBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisModelo" runat="server" ControlToValidate="lstModelo" 
                             CssClass="failureNotification" ErrorMessage="El modelo del vehículo es obligatorio." ToolTip="El modelo del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                                       
                    <br />
                    <asp:Label ID="lblMotor" runat="server" Text="No. Motor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblChasis" runat="server" Text="No. Chasis: "></asp:Label>
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblEstado" runat="server" Text="Estado: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMotor" runat="server" CssClass= "textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisMotor" runat="server" ControlToValidate="txtMotor" 
                             CssClass="failureNotification" ErrorMessage="El número de motor del vehículo es obligatorio." ToolTip="El número de motor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtChasis" runat="server" CssClass= "textEntry"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarRegisChasis" runat="server" ControlToValidate="txtChasis" 
                             CssClass="failureNotification" ErrorMessage="El número de chasis del vehículo es obligatorio." ToolTip="El número de chasis del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>

                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                             <asp:ListBox ID="lstEstado" runat="server" AutoPostBack="True" Rows="1" ></asp:ListBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstModelo" 
                             CssClass="failureNotification" ErrorMessage="El estado del vehículo es obligatorio." ToolTip="El estado del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    
                    
                </div> 
                <div id = "DivDatosPropietario" runat ="server" visible ="false">
                     <div class="post" >
                          <asp:Label ID="lblPoster1" runat="server" Text="Información de Propietario"></asp:Label>
                      </div> 
                    <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedula" runat="server" CssClass= "textEntry" Width="160px" 
                         ontextchanged="txtCedula_TextChanged" ></asp:TextBox>   
                        
                        <asp:RegularExpressionValidator ID="ValidarDatosCedulaProp" runat="server" ControlToValidate="txtCedula" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                        
                   <div id = "DivConsultaPropietario" runat ="server" visible ="false"> 
                      <asp:Label ID="lblCedula2" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedula2" runat="server" CssClass= "textEntry" Width="160px" 
                        Enabled="false"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="validarCedProp" runat="server" ControlToValidate="txtCedula2" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del propietario del vehículo es obligatorio." ToolTip="El número de cédula del propietario del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validarExpreProp" runat="server" ControlToValidate="txtCedula2" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                   <br />                                      
                    <asp:Label ID="lblNombres" runat="server" Text="Nombres " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblApellidos" runat="server" Text="Apellidos " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="txtNombres" runat="server" CssClass= "textEntry" Width="160px" Enabled="false" ></asp:TextBox>                                       
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass= "textEntry" Width="160px" Enabled="false"  ></asp:TextBox> 
                         </div>                                      
                   
                </div> 
                    
                    <div id="DivAsignacionConductor" runat="server" visible="false">
                    <div class="post" >
                        <asp:Label ID="lblPoster2" runat="server" Text="Asignación de Conductor"></asp:Label>
                      </div> 
                    <asp:Label ID="lblCedula1" runat="server" Text="Número de Cédula: " Visible="false"></asp:Label><br />
                    <asp:TextBox ID="txtCedula1" runat="server" CssClass= "textEntry" Width="160px" 
                        ontextchanged="txtCedula1_TextChanged" Visible="false"></asp:TextBox>                                       
                    
                        <asp:RegularExpressionValidator ID="ValidarExpresionCedula" runat="server" ControlToValidate="txtCedula1" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                  
                 
                 <div id = "DivDatosConductor" runat ="server" visible ="false">
                    <h3>
                    <asp:TextBox ID="txtCedConductor" runat="server" CssClass= "textEntry" Width="160px" 
                        Enabled="false"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="validarCedulaCond" runat="server" ControlToValidate="txtCedConductor" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del conductor del vehículo es obligatorio." ToolTip="El número de cédula del conductor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCedConductor" 
                    CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                        ValidationExpression="^([\d]{6,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                                                                        
                    </h3>
                    <br />
                    <asp:Label ID="lblNombreCond" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellidoCond" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellidoCond" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  
                    <asp:TextBox ID="txtNombreCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="validarNombreCond" runat="server" ControlToValidate="txtNombreCond" 
                             CssClass="failureNotification" ErrorMessage="El nombre del conductor del vehículo es obligatorio." ToolTip="El nombre del conductor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validarExpresionCond" runat="server" ControlToValidate="txtNombreCond" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    
                    <asp:RequiredFieldValidator ID="validarApellidoCond" runat="server" ControlToValidate="txtPrimerApellidoCond" 
                             CssClass="failureNotification" ErrorMessage="El apellido del conductor del vehículo es obligatorio." ToolTip="El apellido del conductor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validarExpresionApellido" runat="server" ControlToValidate="txtPrimerApellidoCond" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="validarSegundApellido" runat="server" ControlToValidate="txtSegundoApellidoCond" 
                             CssClass="failureNotification" ErrorMessage="El apellido del conductor del vehículo es obligatorio." ToolTip="El apellido del conductor del vehículo es obligatorio." 
                             ValidationGroup="RegistrarVehiculo">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="validarExpresionSegApellido" runat="server" ControlToValidate="txtSegundoApellidoCond" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="RegistrarVehiculo" >*</asp:RegularExpressionValidator>
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
                        <asp:ListBox ID="lstRuta" runat="server" AutoPostBack="True" Rows="1" onselectedindexchanged="lstRuta_SelectedIndexChanged" 
                           >
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