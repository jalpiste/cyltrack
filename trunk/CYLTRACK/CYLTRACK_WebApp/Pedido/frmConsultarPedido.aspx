<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmConsultarPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.Pedido.frmConsultarPedido" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Consultar Pedido
    </h1>
         <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validar" Font-Size = "Small"/>
                 
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Consulta de Pedidos</legend>
                                      <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
&nbsp;&nbsp; <br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="Validar" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                 
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="NumPedidoTxt" CssClass="textEntry" runat="server" 
                                  Width="112px" ontextchanged="NumPedidoTxt_TextChanged"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="ValidarDatosPedido" runat="server" ControlToValidate="NumPedidoTxt" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." 
                             ValidationGroup="Validar" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarPedido" runat="server" ControlToValidate="NumPedidoTxt" 
                            CssClass="failureNotification" ErrorMessage="El número del pedido debe contener entre 3 y 5 dígitos." 
                            ValidationExpression="^([\d]{3,5})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                        
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" ></asp:Label>
                    </h5>                    
                    <p>
                        <asp:Label ID="lblCedulaCliente" runat="server" AssociatedControlID="txtCedulaCliente" Text="Número de Cédula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" enabled = "false" runat="server" Width="197px"></asp:TextBox>
                    </p>                   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                               <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" Enabled="false" CssClass="textEntry" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
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
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPlaca"  CssClass="textEntry" runat="server" enabled = "false" Width="50px" ></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblRuta" runat="server"  Text="Ruta: "></asp:Label>
                        <asp:Label ID="lblRutaAsignada" runat="server"  Text="xxxxxxx"></asp:Label>
                      </p>
                      <p>
                    
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
                      </p>
                        <p>
                      
                          <asp:Label ID="lblFecha" runat="server" Text="Fecha de Registro de Pedido:   "></asp:Label>
                          &nbsp;
                          <asp:Label ID="lblFechaPedido" runat="server" Text=" dd/mm/aaaa 00:00:00"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblFechaEntrega" runat="server" Text="Fecha de Entrega del Pedido:"></asp:Label>
                          &nbsp;&nbsp;
                          <asp:Label ID="lblFechaEntregaCilindro" runat="server" Text="dd/mm/aaaa 00:00:00"></asp:Label>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnNuevaConsulta" runat="server" Text="Nueva Consulta" Visible="false" 
                        onclick="btnNuevaConsulta_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" onclick="btnMenuPrincipal_Click"  
                       />  
                    
                    </p>
            </div>
</asp:Content>
