<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCasosEspeciales.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmCasosEspeciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Casos Especiales
    </h1>
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Datos Casos Especiales</legend>
            <h3>
                Seleccione en el listado la opción correspondiente:
            </h3>
            <br />
            <p>
                <asp:ListBox ID="lstCasosEspeciales" runat="server" AutoPostBack="True" Rows="1"
                    Width="170px" onselectedindexchanged="lstCasosEspeciales_SelectedIndexChanged">
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>Código erroneo en la entrega del cliente</asp:ListItem>
                    <asp:ListItem>Código erroneo en el recibido del cliente</asp:ListItem>
                </asp:ListBox>
            </p>
            <br />
            <div id="divConsultarCilindro" runat="server" visible="false">   
                       <p>
                        <asp:Label ID="lblCodigoCilindro" runat="server" text="Seleccionar el código erroneo del sistema:"></asp:Label><br />
                        <asp:ListBox ID="lstCodigosVehiculo" runat="server" Rows="1" 
                               onselectedindexchanged="lstCodigosVehiculo_SelectedIndexChanged" >
                        <asp:ListItem>88091751785</asp:ListItem>
                        <asp:ListItem>890967567456</asp:ListItem>
                        </asp:ListBox>
                        </p>
                        </div>
                    <div id="DivDatosCilindro" runat="server" visible="false">
                     <div class="post" >
                          <asp:Label ID="LblPoster" runat="server" Text="Datos Cilindro"></asp:Label>
                      </div> 
                     <p>
                         <asp:Label ID="LblAno" runat="server" Text="Año Fabricación:" ></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="LblEmpresa" runat="server" Text="Empresa Fabricante:" ></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="LblCodigo" runat="server" Text="Código Cilindro:" ></asp:Label>
                    </p>
                    <p>
                         <asp:TextBox ID="TxtAno" runat="server" CssClass="textEntry" Enabled="false" Width="80px"></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:TextBox ID="TxtEmpresa" runat="server" Width="80px" CssClass="textEntry" 
                             Enabled="False" ></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                         <asp:TextBox ID="TxtCodigo" runat="server" Width="80px" CssClass="textEntry" Enabled="False" 
                            ></asp:TextBox>
                    </p>
                    <p> 
                        <asp:Label ID="LblUbicacion" runat="server" Text="Ubicación: " ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="TxtUbicacion" runat="server" CssClass="textEntry" Width="80px" 
                                text="Cliente" Enabled="False"
                                ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TxtTamano" runat="server" CssClass="textEntry" Width="80px" 
                                Enabled="False"></asp:TextBox>
                    </p>
                        <p>
                        <asp:Label ID="LblTotal" runat="server" text="codigo total" Width="30%" ></asp:Label>
                            &nbsp;&nbsp;<asp:Label ID="lblregistro" runat="server" Text="Fecha Registro:"></asp:Label>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblFechaUbicacion" runat="server" Text="Fecha de Movimiento:"></asp:Label>
                 </p>
                 <p>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="TxtRegistro" runat="server" CssClass="textEntry" Enabled="false" Width="80px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:TextBox ID="txtFechaUbica" runat="server" CssClass="textEntry"></asp:TextBox>
                        </p>
                        
                        <div id="DivInfoCilindro" runat="server" visible="false">
                        <div class="post" >
                            <asp:Label ID="LblPost" runat="server" Text="Información Ubicación Cilindro" ></asp:Label>
                        </div>
                        <p>
                        <asp:Label ID="LblCedula" runat="server" >Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="false"></asp:TextBox>
                        </p>
                    <p>
                        <asp:Label ID="LblNombreCliente" runat="server" 
                            AssociatedControlID="TxtNombreCliente" >Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="TxtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="false"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="LblPrimerApellido" runat="server" text="Primer Apellido:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label ID="LblSegundoApellido" runat="server" Text="Segundo Apellido:" ></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="TxtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TxtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="LblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        &nbsp;</p> 
                   
                      <p>
                        <asp:TextBox ID="TxtDireccion" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                          <asp:TextBox ID="TxtBarrio" runat="server" CssClass="textEntry" Width="197px" Enabled="false"></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          </p> 
                    <p><asp:Label ID="LblCiudad" runat="server" >Ciudad:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
                    <asp:Label ID="LblDepartamento" runat="server" text="Departamento:" ></asp:Label></p>
                    <p><asp:TextBox ID="TxtCiudad" runat="server" CssClass="textEntry"  Width="197px" Enabled="false" ></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                           <asp:TextBox ID="TxtDepartamento" runat="server" CssClass="textEntry" Width="197px" Enabled="false"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>  
                    
                     <p> 
                         <asp:Label ID="LblTelefono" runat="server" Text="Telefono:" ></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="LblEntrega" runat="server" Text="Fecha de Entrega: " ></asp:Label>
                    </p>
                        <p>
                            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;   
                    <asp:TextBox ID="Txtentrega" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                    </p>

                  </div>
                   
                  <div id="DivInfoVehiculo" runat="server" visible="false">
                        <div class="post" >
                            <asp:Label ID="LblDatosVehiculo" runat="server" Text="Datos Vehiculo" ></asp:Label>
                        </div>
                        <p>
                        <asp:Label ID="LblVehiculo" runat="server" Text="Placa Vehículo:"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LblConductor" runat="server" Text="Conductor:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="LblRuta" runat="server" Text="Ruta:"></asp:Label>
                        </p>
                        <p>
                        <asp:TextBox ID="TxtPlaca" runat="server" CssClass="textEntry" Width="80px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TxtConductor" runat="server" CssClass="textEntry" Width="165px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TxtRuta" runat="server" CssClass="textEntry"></asp:TextBox>
                        </p>
                   </div>
                     </div> 
                    <div id="divCodigoCorrecto" runat="server" visible="false">
                    <div class="post" >
                          <asp:Label ID="lblInfoCorreccion" runat="server" Text="Datos a Corregir"></asp:Label>
                      </div> 
                    <p>
                        <asp:Label ID="lblCodigoCorregido" runat="server" Text="Digitar código correcto fisicamente:"></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtCodigoCorregido" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                    </div>
                   </fieldset>
                    </div>
             
         
            <p class="submitButton">
                    <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú" />
               </p>
           
</asp:Content>
