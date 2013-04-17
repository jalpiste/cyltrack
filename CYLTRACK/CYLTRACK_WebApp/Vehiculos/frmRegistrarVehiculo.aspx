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
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="RegistrarVehiculoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarVehiculoValidationGroup"/>

            <asp:ValidationSummary ID="ConsultarPropietarioValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ConsultarConductorValidationGroup"/>

                <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Vehículo</legend>
                 <div class="post" >
                          <asp:Label ID="lblPoster" runat="server" Text="Datos Vehículo"></asp:Label>
                      </div> 
                    
                <div id = "DivVehiculo" runat ="server">
                    <asp:Label ID="lblPlaca" runat="server" Text="Placa: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPlaca" runat="server" CssClass="textEntry" Width="100px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RegistrarVehiculoRequired" runat="server" 
                     ControlToValidate="txtPlaca" CssClass="failureNotification" 
                     ErrorMessage="La placa es obligatoria." ToolTip="La placa es obligatoria." 
                     ValidationGroup="RegistrarVehiculoValidationGroup"> * </asp:RequiredFieldValidator>
                     <br />
                    <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMarca" runat="server" CssClass= "textEntry"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCilindraje" runat="server" CssClass= "textEntry" Width="90px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtModelo" runat="server" CssClass= "textEntry" Width="90px"></asp:TextBox>
                    <br /><br />
                    <asp:Label ID="lblMotor" runat="server" Text="No. Motor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblChasis" runat="server" Text="No. Chasis: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMotor" runat="server" CssClass= "textEntry"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtChasis" runat="server" CssClass= "textEntry"></asp:TextBox>
                </div> 
                <div class="post" >
                          <asp:Label ID="lblPoster1" runat="server" Text="Información de Propietario"></asp:Label>
                      </div> 
                    <div id = "DivPropietario" runat ="server" >
                    <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedula" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    <br />
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  

                    <asp:TextBox ID="txtNombre" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass= "textEntry" Width="160px" ></asp:TextBox>                                       
                    
                      </div> 
                    <%--------------------------------------------%>
                    
                    <div class="post" >
                        <asp:Label ID="lblPoster2" runat="server" Text="Asignación de Conductor"></asp:Label>
                      </div> 
                
                    <asp:Label ID="lblCedula1" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedula1" runat="server" CssClass= "textEntry" Width="160px" 
                        ontextchanged="txtCedula1_TextChanged" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtCedula" CssClass="failureNotification" 
                    ErrorMessage="La cédula del conductor es obligatoria." ToolTip="La cédula del conductor es obligatoria." 
                             ValidationGroup="ConsultarConductorValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <div id="DivAsignacionConductor" runat="server" visible="false">
                    <h3>
                    <asp:Label ID="lblImprimirCedula" runat="server" Text="xxxxxxxxxxxxx" ></asp:Label>
                    </h3>
                    <br />
                    <asp:Label ID="lblNombreCond" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellidoCond" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellidoCond" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  

                    <asp:TextBox ID="txtNombreCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellidoCond" runat="server" CssClass= "textEntry" Width="160px" Enabled ="false" ></asp:TextBox>                                       
                    
                      </div> 
                <div class="post" >
                          <asp:Label ID="lblPost" runat="server" Text="Asignación de Ruta"></asp:Label>
                      </div> 
                 <div id = "DivSelRuta" runat ="server">
                    <h3>
                    Seleccione la ruta a asignar.
                    </h3>
                    <br />
                     <asp:Label ID="lblRuta" runat="server" Text="Ruta: "></asp:Label>
                     <br />
                        <asp:ListBox ID="lstRuta" runat="server" AutoPostBack="True" Rows="1"  >
                            <asp:ListItem>Seleccionar</asp:ListItem>
                     </asp:ListBox>
                 </div>
                 </fieldset> 
                  <p class="submitButton">
                  <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" Visible="false" 
                        onclick="btnGuardar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>
               </p>
                 </div> 
</asp:Content>
