<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarVehiculo.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Vehiculos.frmModificarVehiculo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Modificar Vehículo
                </h1>
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="ModificarVehiculoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarVehiculoValidationGroup"/>
            <asp:ValidationSummary ID="CedulaConductorValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="CedulaConductorValidationGroup"/>
            
                 
              <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificar Vehículo</legend>
                    <asp:Label ID="lblPlaca" runat="server" Text="Placa: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPlaca" runat="server" CssClass="textEntry" Width="100px" 
                        ontextchanged="txtPlaca_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ModificarVehiculoRequired" runat="server" 
                     ControlToValidate="txtPlaca" CssClass="failureNotification" 
                     ErrorMessage="La placa es obligatoria." ToolTip="La placa es obligatoria." 
                     ValidationGroup="ModificarVehiculoValidationGroup"> * </asp:RequiredFieldValidator>
                     <br />
                      <div id="DivDatosVehiculo" runat ="server" visible="false">
                      <div class="post">
                          <asp:Label ID="lblPoster" runat="server" Text="Datos Vehículo" ></asp:Label>
                      </div>
                      <asp:Label ID="lblIdVehiculo" runat="server" Text="Placa: "></asp:Label>                       
                      <br />
                      <asp:TextBox ID="txtIdVehiculo" runat="server" CssClass="textEntry" Width="100px" ></asp:TextBox>
                      <br /><br />
                      <asp:Label ID="lblMarca" runat="server" Text="Marca: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCilindraje" runat="server" Text="Cilindraje: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblModelo" runat="server" Text="Modelo: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMarca" runat="server" CssClass= "textEntry" ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtCilindraje" runat="server" CssClass= "textEntry" Width="90px" ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtModelo" runat="server" CssClass= "textEntry" Width="90px" ></asp:TextBox>
                    <br /><br />
                    <asp:Label ID="lblMotor" runat="server" Text="No. Motor: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblChasis" runat="server" Text="No. Chasis: "></asp:Label>
                    <br />
                    <asp:TextBox ID="txtMotor" runat="server" CssClass= "textEntry"  ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtChasis" runat="server" CssClass= "textEntry" ></asp:TextBox>
                </div> 

                <div id = "DivPropietario" runat ="server" visible="false" >
                <div class="post">
                          <asp:Label ID="lblPoster1" runat="server" Text="Información de Propietario" ></asp:Label>
                </div> 
                    <asp:Label ID="lblCedula" runat="server" Text="Número de Cédula: "></asp:Label>                
                    <br />
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
                        <%-------------------------------%>
                         <div id="DivConductorAsignado" class="post" runat="server" visible="false">
                        <asp:Label ID="lblPoster2" runat="server" Text="Conductor Asignado" ></asp:Label>
                      </div> 
                      <div id = "DivConductor" runat ="server" visible="false">
                    <asp:Label ID="lblCedulaCond" runat="server" Text="Número de Cédula: "></asp:Label><br />
                    <asp:TextBox ID="txtCedulaCond" runat="server" CssClass= "textEntry" Width="160px" 
                              ontextchanged="txtCedulaCond_TextChanged" ></asp:TextBox>                                       
                    <asp:RequiredFieldValidator ID="CedulaConductorRequired" runat="server" 
                     ControlToValidate="txtCedulaCond" CssClass="failureNotification" 
                     ErrorMessage="El número de cédula es obligatoria." ToolTip="El número de cédula es obligatoria." 
                     ValidationGroup="CedulaConductorValidationGroup"> * </asp:RequiredFieldValidator>
                    <br />
                    <asp:Label ID="lblNombreCond" runat="server" Text="Nombre " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPrimerApellidoCond" runat="server" Text="Primer Apellido " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblSegundoApellidoCond" runat="server" Text="Segundo Apellido " ></asp:Label><br />                  

                    <asp:TextBox ID="txtNombreCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrimerApellidoCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellidoCond" runat="server" CssClass= "textEntry" Width="160px" enabled="false" ></asp:TextBox>                                       
                    
                      </div> 
                 <div id= "DivAsigRuta" class="post" runat ="server" visible="false">
                          <asp:Label ID="lblPost" runat="server" Text="Ruta Asignada"></asp:Label>
                      </div> 
                 <div id="divDatosRuta" runat="server" visible="false">
                 <h3>
                    <asp:Label ID="lblNota" runat="server" Text="Seleccione la ruta a asignar." Visible="false"></asp:Label>
                 </h3>             
                       
                     <asp:Label ID="lblRuta" runat="server" Text="Ruta: " Visible="false"></asp:Label>
                     <br />
                     <asp:TextBox ID="txtRuta" runat="server" CssClass= "textEntry" Width="160px" Visible="true" ></asp:TextBox>
                
                 <asp:ListBox ID="lstRuta" runat="server" AutoPostBack="True" Rows="1" visible="true">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                     </asp:ListBox>
                  </div>  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" visible="false"
                        onclick="btnGuardar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>
               </p>
              </div>
                 
</asp:Content>
