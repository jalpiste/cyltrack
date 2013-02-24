<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegistroPedido.aspx.cs" Inherits="CYLTRACK_WebApp.Account.Pedido.frmRegistroPedido" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
 </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <h1 style="margin-top: 75px">
        Registrar Pedido
    </h1>
       <h5>
                <asp:Label ID="lblCodigoPedido" runat="server" Text="Código Pedido:   "></asp:Label>
                <asp:Label ID="lblNumeroPedido" runat="server" Text="342342"></asp:Label>
            </h5>
             <asp:ValidationSummary ID="RegistroPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistroPedidoValidationGroup"/>
            <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Registro de Pedidos</legend>
                       <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="RegistroPedidoValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Datos Personales del Cliente</div>   
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
                              Rows="1" >
                              <asp:ListItem>Seleccionar</asp:ListItem>
                        </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label><br />
                         <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False"></asp:TextBox>
                    </p>
                  
                        <div class="post">Información Cilindro Cliente</div>
                  <p>
                      <asp:Label ID="lblCilindro" runat="server" Text="Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label><br />
                  <asp:TextBox ID="txtCilindro" runat="server" CssClass="textEntry" Text=" " Enabled="False"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:TextBox ID="txtTamano" Enabled="false" CssClass="textEntry" runat="server" Width="48px"></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                      
                      
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  
                  </p>
                   <div class="post">Información Pedido</div>
                    <p>

                        <asp:Label ID="lblVehiculo" runat="server" Text="Vehiculo zona: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="lstPlaca" runat="server" Rows="1">
                            <asp:ListItem>UZK201</asp:ListItem>
                            <asp:ListItem>UZK270</asp:ListItem>
                            <asp:ListItem>UZK271</asp:ListItem>
                            <asp:ListItem>XHA940</asp:ListItem>
                        </asp:ListBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPlaca" runat="server" Text="Ruta Chiquinquirá"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="ListBox1" runat="server" Rows="1">
                              <asp:ListItem>30</asp:ListItem>
                              <asp:ListItem>40</asp:ListItem>
                              <asp:ListItem>80</asp:ListItem>
                              <asp:ListItem>100</asp:ListItem>
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCantidadCilindro" runat="server" Text="Cantidad Cilindros: "></asp:Label>
                          &nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtCantidadCilindro" CssClass="textEntry" runat="server" 
                              Width="50px"></asp:TextBox>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" 
                        onclick="btnGuardar_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click" />  
                    
                    </p>
            </div>
</asp:Content>
