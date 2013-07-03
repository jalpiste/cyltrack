<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido.frmModificarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Modificar Pedido
    </h1>
               <asp:ValidationSummary ID="ModificarPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarPedido" Font-Size = "Small"/>
                  <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validar" Font-Size = "Small"/>
                 <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarCantidad" Font-Size = "Small"/>
            
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificación de Pedidos</legend>
                      <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="Validar" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                    
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TxtNumPedido" CssClass="textEntry" runat="server" 
                            Width="112px" ontextchanged="TxtNumPedido_TextChanged"  ></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="ValidarDatosPedido" runat="server" ControlToValidate="txtNumPedido" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." 
                             ValidationGroup="Validar" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarPedido" runat="server" ControlToValidate="txtNumPedido" 
                            CssClass="failureNotification" ErrorMessage="El número del pedido debe contener entre 3 y 5 dígitos." 
                            ValidationExpression="^([\d]{3,5})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                    
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Text="2323432"></asp:Label>
                    </h5> 
                    <p>
                        <asp:Label ID="lblCedulaCliente" runat="server" AssociatedControlID="txtCedulaCliente" Text="Número de Cédula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" runat="server" 
                            Width="197px" ontextchanged="txtCedulaCliente_TextChanged"  ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CedulaCli" runat="server" ControlToValidate="txtCedulaCliente" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="ModificarPedido" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidarCedulaCli" runat="server" ControlToValidate="txtCedulaCliente" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                    
                    </p>                   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                               <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        <br />
                        <asp:ListBox ID="lstDireccion" runat="server" AutoPostBack="True" Rows="1" 
                            onselectedindexchanged="lstDireccion_SelectedIndexChanged">
                              <asp:ListItem>Seleccionar...</asp:ListItem>
                          </asp:ListBox>
                          <asp:RequiredFieldValidator ID="ValidarDir" runat="server" ControlToValidate="lstDireccion" 
                             CssClass="failureNotification" ErrorMessage="La selección de la dirección del cliente es obligatoria." ToolTip="La selección de la dirección del cliente es obligatoria." 
                             ValidationGroup="ModificarPedido">*</asp:RequiredFieldValidator>

                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server" Width="685px">Ciudad:</asp:Label><br />
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    <br/>
                    <asp:Label ID="lblDepartamento" runat="server" Width="679px">Departamento:</asp:Label>
                    <br />
                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                         
                        </p>
                   
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    <br />
                           <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False" ></asp:TextBox>
                    </p>
                   <div class="post">Información Pedido</div>
                    <p>

                        <asp:Label ID="lblVehiculo" runat="server" Text="Vehiculo zona: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;<asp:ListBox ID="lstPlaca" runat="server" AutoPostBack="True" Rows="1">
                            <asp:ListItem>UZK201</asp:ListItem>
                            <asp:ListItem>UZK270</asp:ListItem>
                            <asp:ListItem>XHA940</asp:ListItem>
                        </asp:ListBox>
                    <asp:RequiredFieldValidator ID="ValidarPlaca" runat="server" ControlToValidate="lstPlaca" CssClass="failureNotification" 
                     ErrorMessage="La selección de la placa del vehículo es obligatoria." ToolTip="La selección de la placa del vehículo es obligatoria." 
                     ValidationGroup="ModificarPedido"> * </asp:RequiredFieldValidator>
                    
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblRuta" runat="server"  Text="Ruta: "></asp:Label>
                        <asp:Label ID="lblRutaAsignada" runat="server"  Text="xxxxx"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="lstTamano" runat="server" Rows="1">
                              <asp:ListItem>30</asp:ListItem>
                              <asp:ListItem>40</asp:ListItem>
                              <asp:ListItem>80</asp:ListItem>
                              <asp:ListItem>100</asp:ListItem>
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:Label ID="lblCantidadCilindro" runat="server" Text="Cantidad Cilindros: "></asp:Label>
                          &nbsp;&nbsp;
                          
                          <asp:TextBox ID="txtCantidadCilindro"  CssClass="textEntry" runat="server" Width="50px" Text=""></asp:TextBox>
                      <asp:RegularExpressionValidator ID="ValidarDatosCantidad" runat="server" ControlToValidate="txtCantidadCilindro" 
                    CssClass="failureNotification" ErrorMessage="La cantidad de cilindros debe contener como mínimo 1 dígito." 
                        ValidationExpression="^([\d]{1,6})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarCantidad" >*</asp:RegularExpressionValidator>
                   
                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="115px" 
                         onclick="btnAgregar_Click" ValidationGroup="RegistrarCantidad"/>
                         
                    <br />
                    <br />

                    <asp:GridView ID="gvPedido" runat="server" CellPadding="2" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                      </p>
                        <p>
                     <asp:Label ID="lblFecha" runat="server" Text="Fecha de Registro de Pedido:   "></asp:Label>
                          <asp:Label ID="lblFechaPedido" runat="server" Text=" dd/mm/aaa 00:00:00"></asp:Label>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px"  Visible="false"
                        onclick="btnGuardar_Click" ValidationGroup="ModificarPedido"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>  
                   
                    </p>
            </div>
</asp:Content>
