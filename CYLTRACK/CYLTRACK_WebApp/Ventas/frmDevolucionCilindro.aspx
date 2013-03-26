<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDevolucionCilindro.aspx.cs" Inherits="CYLTRACK_WebApp.Ventas.frmDevolucionCilindro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Devolución Cilindros
                </h1>
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="DevolucionCilindroValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="DevolucionCilindroValidationGroup"/>

                 <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Devolución de Cilindro</legend>
                     <asp:Label ID="lblCodigoCilindro" runat="server" Text="Código Cilindro: "></asp:Label>
                     <br />
                     <asp:TextBox ID="txtCodigoCilindro" runat="server" CssClass="textEntry" 
                         Width="197px" ontextchanged="txtCodigoCilindro_TextChanged"></asp:TextBox>
                         <%--AutoPostBack="True" pendiente por verificar si funciona en textbox para usar el mensaje de error --%>
                     <asp:RequiredFieldValidator ID="CodigoCilindroRequired" runat="server" ControlToValidate="txtCodigoCilindro" 
                             CssClass="failureNotification" ErrorMessage="El código del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="DevolucionCilindroValidationGroup"> * </asp:RequiredFieldValidator>
                    <div id="DivDatosCilindro" runat="server" visible="false">
                    <div class="post" >
                          <asp:Label ID="lblPoster" runat="server" Text="Datos Cilindro"></asp:Label>
                      </div> 
                        <asp:Label ID="lblCodCilindro" runat="server" Text="Código: "></asp:Label>
                        <asp:TextBox ID="txtCodCilindro" runat="server" Enabled = "false" CssClass="textEntry"  
                         Width="90px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label>
                        <asp:TextBox ID="txtTamano" runat="server"  Enabled = "false" Width="49px" CssClass="textEntry"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha de Entrega: "></asp:Label>
                        <asp:TextBox ID="txtFechaEntrega" runat="server" CssClass="textEntry" Enabled ="false"></asp:TextBox>
                      </div> 
                    <div id="DivDatosCliente" runat="server" visible="false">
                    <div class="post" >
                          <asp:Label ID="lblPost" runat="server" Text="Información Cliente"></asp:Label>
                          </div> 
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Text="2323432"></asp:Label>
                    </h5>
                     
                        <asp:Label ID="lblNombreCliente" runat="server" Text="Nombres del cliente: "></asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox><br />
                        
                    <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                    <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label> 
                    <br />
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <br />
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; 
                    <asp:Label ID="lblDepartamento" runat="server" text="Departamento:"></asp:Label> 
                    <br />
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                    <br />
                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
                        <br />
                         <asp:TextBox ID="txtTipoTelefono" Enabled="false" CssClass="textEntry" runat="server"></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    </div>
              <div id="DivObservaciones" runat="server" visible="false">       
                    <div class="post" >
                          <asp:Label ID="lblPosterObservaciones" runat="server" Text="Observaciones"></asp:Label>
                          </div> 
                    <h4>
                    <asp:Label ID="lblAviso" runat="server" Text="Seleccione un motivo para realizar la devolución del cilindro."></asp:Label>            
                    </h4>
                    <br />
                    <asp:ListBox ID="lstMotivo" runat="server" AutoPostBack="True" Rows="1" 
                        onselectedindexchanged="lstMotivo_SelectedIndexChanged"> 
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>Cambio de cilindro por escape</asp:ListItem>
                    <asp:ListItem>Terminación del contrato</asp:ListItem>
                    </asp:ListBox>
                    <br />
                    <br />
                <div id="DivCambio" runat="server" visible="false">       
                  <asp:Label ID="lblCilindroCambio" runat="server" Text="Código Cilindro de Cambio: "></asp:Label>
                  <br />                                         
                  <asp:TextBox ID="txtCilindroCambio" runat="server" CssClass="textEntry"  
                         Width="197px"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="CodigoCilindroCambioRequired" runat="server" ControlToValidate="txtCilindroCambio" 
                   CssClass="failureNotification" ErrorMessage="El código del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                   ValidationGroup="DevolucionCilindroValidationGroup"> * </asp:RequiredFieldValidator>
                   </div> 
                   <br />   
                  <asp:Label ID="lblObservacion" runat="server" Text="Observaciones: "></asp:Label> 
                  <br />        
                  <asp:TextBox ID="txtObservaciones" runat="server" Height="77px" Width="306px" CssClass="textEntry"></asp:TextBox>
              </div>
            </fieldset> 
            <p class="submitButton">
                <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="120px" 
                    onclick="BtnGuardar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="BtnMenu" runat="server" Text="Menú Principal" Width="120px" 
                    onclick="BtnMenu_Click"/>  
                   
               </p>
            </div> 
</asp:Content>
