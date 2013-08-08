<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegistroPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido.frmRegistroPedido" EnableViewState="true" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <h1 style="margin-top: 75px">
        Registrar Pedido
    </h1>
                 <asp:ValidationSummary ID="RegistroPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistroPedido" Font-Size = "Small"/>
                 <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>
                 <asp:ValidationSummary ID="ValidarCantidadValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarCantidad" Font-Size = "Small"/>
                 <asp:ValidationSummary ID="ValidarOrdenPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarPedido" Font-Size = "Small"/>

       <h5>
                <asp:Label ID="lblCodigoPedido" runat="server" Text="Código Pedido:   " visible="false"></asp:Label>
                <asp:Label ID="lblNumeroPedido" runat="server" Text="" visible="false"></asp:Label>
            </h5>
             
            <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Registro de Pedidos</legend>
                       <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="ValidarCedula" ></asp:RegularExpressionValidator>
                    
                    </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Datos Personales del Cliente</div>   
                     <p>
                        <asp:Label ID="lblCedulaCli" runat="server" AssociatedControlID="txtNombreCliente">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedulaCli" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblSegundoApellido" runat="server" text="Segundo Apellido:"></asp:Label><br />
                      <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" 
                                Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        <br />
                        <asp:ListBox ID="lstDireccion" runat="server" Width="176px" AutoPostBack="True" 
                              Rows="1" onselectedindexchanged="lstDireccion_SelectedIndexChanged" >
                              <asp:ListItem>Seleccionar</asp:ListItem>
                        </asp:ListBox>
                           <asp:RequiredFieldValidator ID="ValidarDir" runat="server" ControlToValidate="lstDireccion" CssClass="failureNotification" 
                     ErrorMessage="La selección de la dirección del cliente es obligatoria." ToolTip="La selección de la dirección del cliente es obligatoria." 
                     ValidationGroup="RegistroPedido"> * </asp:RequiredFieldValidator>
                    
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="txtBarrio"  runat="server" CssClass="textEntry" 
                                Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server" AssociatedControlID="txtCiudad" 
                            Width="685px">Ciudad:</asp:Label><br />
                            <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>  
                        <p><asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="txtDepartamento" 
                            Width="679px">Departamento:</asp:Label><br />
                            <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label><br />
                         <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False"></asp:TextBox>
                    </p>
                        
                   <div class="post">Información Pedido</div>
                    <p>

                        <asp:Label ID="lblVehiculo" runat="server" Text="Placa Vehículo: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="lstPlaca" runat="server" Rows="1">
                            <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                        <asp:RequiredFieldValidator ID="ValidarPlaca" runat="server" ControlToValidate="lstPlaca" CssClass="failureNotification" 
                     ErrorMessage="La selección de la placa del vehículo es obligatoria." ToolTip="La selección de la placa del vehículo es obligatoria." 
                     ValidationGroup="RegistroPedido"> * </asp:RequiredFieldValidator>
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblRuta" runat="server" Text="Ruta: "></asp:Label>
                        &nbsp;
                        <asp:Label ID="lblRutaAsignada" runat="server" Text="xxxxxxx"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="lstTamano" runat="server" Rows="1">
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCantidadCilindro" runat="server" Text="Cantidad Cilindros: "></asp:Label>
                          &nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtCantidadCilindro" CssClass="textEntry" runat="server" Width="50px"></asp:TextBox>
                    
                        <asp:RequiredFieldValidator ID="ValidarCantidad" runat="server" 
                          ControlToValidate="txtCantidadCilindro" CssClass="failureNotification" 
                          ErrorMessage="La cantidad de cilindros es obligatoria." ToolTip="La cantidad de cilindros es obligatoria." 
                          ValidationGroup="RegistrarCantidad" Display="Dynamic">*</asp:RequiredFieldValidator>
                          
                    <asp:RegularExpressionValidator ID="ValidarDatosCantidad" runat="server" ControlToValidate="txtCantidadCilindro" 
                    CssClass="failureNotification" ErrorMessage="La cantidad de cilindros debe contener entre 1 y 5 dígitos." 
                        ValidationExpression="^([\d]{1,6})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarCantidad" >*</asp:RegularExpressionValidator>
                   
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="115px" 
                         onclick="btnAgregar_Click" />
                    <br />
                    <br />
                    <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false" 
                    AutoGenerateDeleteButton = "true" onrowdeleting="gvPedido_RowDeleting"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="TamanoCil" DataField="TamanoCil" HeaderText="Tamaño Cilindro"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="CantidadPedido" DataField="CantidadPedido" HeaderText="Cantidad"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>
                    <br />
                     </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" Visible="false" 
                        onclick="btnGuardar_Click" ValidationGroup="RegistroPedido"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click" />  
                    
                    </p>
            </div>
</asp:Content>
