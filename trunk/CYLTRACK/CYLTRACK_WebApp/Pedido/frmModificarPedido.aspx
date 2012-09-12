<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarPedido.aspx.cs" Inherits="CYLTRACK_WebApp.Pedido.frmModificarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h1> 
            </h1>
               <asp:ValidationSummary ID="ModificarPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarPedidoValidationGroup"/>
            
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificación de Pedidos</legend>
                                      <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
&nbsp;&nbsp; <br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="112px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TxtNumPedido" CssClass="textEntry" runat="server" 
                                              ontextchanged="TxtNumPedido_TextChanged"  ></asp:TextBox><br />
                        
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Text="2323432"></asp:Label>
                    </h5> 
                    <p>
                    
                        <asp:Label ID="lblCedulaCliente" runat="server" AssociatedControlID="txtCedulaCliente" Text="Cedula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ModificarPedidoRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                    </p>                   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" 
                                Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoDireccion" runat="server" Text="Tipo de Dirección:"></asp:Label>
                        &nbsp;</p> 
                   
                      <p>
                          <asp:ListBox ID="lstDireccion" runat="server" AutoPostBack="True" Rows="1">
                              <asp:ListItem>Calle 4 N° 2-49</asp:ListItem>
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="txtTipoDireccion" runat="server" Enabled="false" CssClass="textEntry"></asp:TextBox>
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server" Width="685px">Ciudad:</asp:Label></p>
                    <p><asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox>
                         
                        </p>  
                        <p><asp:Label ID="lblDepartamento" runat="server" Width="679px">Departamento:</asp:Label></p>
                    <p><asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Width="197px" Enabled="False"></asp:TextBox>
                         
                        </p>
                    
                     <p> 
                        <asp:Label ID="lblTipoTelefono" runat="server" Text="Tipo de Teléfono: "></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
                    </p>
                        <p>
                           <asp:TextBox ID="txtTipoTelefono" CssClass="textEntry" Enabled="false" runat="server"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False"></asp:TextBox>
                    </p>
                  <div class="post">Información Cilindro Cliente</div>
                  <p>
                      <asp:Label ID="lblCilindro" runat="server" Text="Cilindro:"></asp:Label>
                  &nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblCantCilindro" runat="server" Text="Cantidad de Cilindros: "></asp:Label>
                  &nbsp;</p>
                  <p>
                  
                      <asp:TextBox ID="txtCilindro" runat="server" CssClass="textEntry" Text="11809615345" Enabled="False"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                      <asp:TextBox ID="txtTamano" Enabled="false" CssClass="textEntry" runat="server" text="30"
                          Width="48px"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  <asp:TextBox ID="txtCantCil" runat="server" CssClass="textEntry" Width="50px" Text="1" 
                          Enabled="False"></asp:TextBox>
                  
                  </p>
                   <div class="post">Información Pedido</div>
                    <p>

                        <asp:Label ID="lblVehiculo" runat="server" Text="Vehiculo zona: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;<asp:ListBox ID="LstPlaca" runat="server" AutoPostBack="True" Rows="1">
                            <asp:ListItem>UZK201</asp:ListItem>
                            <asp:ListItem>UZK270</asp:ListItem>
                            <asp:ListItem>XHA940</asp:ListItem>
                        </asp:ListBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblPlaca" runat="server"  Text="Ruta Chiquinquirá"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="lstTamanoCil" runat="server" Rows="1">
                              <asp:ListItem>30</asp:ListItem>
                              <asp:ListItem>40</asp:ListItem>
                              <asp:ListItem>80</asp:ListItem>
                              <asp:ListItem>100</asp:ListItem>
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblCantidadCilindro" runat="server" Text="Cantidad Cilindros: "></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:TextBox ID="txtCantidadCilindro"  CssClass="textEntry" runat="server" 
                              Width="50px" Text="1"></asp:TextBox>
                      </p>
                        <p>
                      
                          <asp:Label ID="lblFecha" runat="server" Text="Fecha de Registro de Pedido:   "></asp:Label>
                          <asp:Label ID="lblFechaPedido" runat="server" Text=" 28/08/12. 09:04:50 Pm"></asp:Label>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar Datos" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" 
                       />  
                   
                    </p>
            </div>
</asp:Content>
