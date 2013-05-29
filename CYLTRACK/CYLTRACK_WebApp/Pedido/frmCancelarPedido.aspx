<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCancelarPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido.frmCancelarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Cancelar Pedido
    </h1>
            
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Cancelación de Pedidos</legend>
                                      <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
<br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="112px" ontextchanged="txtCedula_TextChanged" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="NumPedidoTxt" CssClass="textEntry" runat="server" 
                                              ontextchanged="NumPedidoTxt_TextChanged"></asp:TextBox><br />
                        
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Text="2323432"></asp:Label>
                    </h5>                    
                    <p>
                        <asp:Label ID="lblCedulaCliente" runat="server" AssociatedControlID="txtCedulaCliente" Text="Cédula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" Enabled="False" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ModificarPedidoRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
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
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="144px" Enabled="False" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="144px" Enabled="False" ></asp:TextBox>
                        
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server" Width="685px">Ciudad:</asp:Label><br />
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    <br/>
                    <asp:Label ID="lblDepartamento" runat="server" Width="679px">Departamento:</asp:Label>
                    <br />
                    <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                         
                        </p>
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" text = "Teléfono: "></asp:Label>
                    <br />
                           <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False" ></asp:TextBox>
                    </p>
                   <div class="post">Información Pedido</div>
                    <p>

                        <asp:Label ID="lblVehiculo" runat="server" Text="Vehiculo zona: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;<asp:TextBox ID="txtZona" runat="server" CssClass="textEntry" Enabled="false" Width="50px"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblRuta" runat="server" Enabled="false" Text="Ruta: "></asp:Label>
                        <asp:Label ID="lblRutaAsignada" runat="server" Enabled="false" Text="xxxxxxx"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblTamanoCil" runat="server" Enabled="false" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtTamanoCil" runat="server" CssClass="textEntry" Enabled="false" Width="50px" Text=""></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblCantidadCilindro" runat="server" Enabled="false" Text="Cantidad Cilindros: "></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:TextBox ID="txtCantidadCilindro" Enabled="false" CssClass="textEntry" runat="server" Width="50px" Text=""></asp:TextBox>
                          <br />
                          <br />
                          <asp:GridView ID="gvPedido" runat="server" CellPadding="2" ForeColor="#333333" 
                              GridLines="None">
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
                          <br />
                      
                      </p>
                      <p>
                      
                          <asp:Label ID="lblFecha" runat="server" Text="Fecha de Registro de Pedido:   "></asp:Label>
                          <asp:Label ID="lblFechaPedido" runat="server" Text=" dd/mm/aaa 00:00:00"></asp:Label>
                      </p>
                      <p>
                          <asp:Label ID="lblMotivoCancelacion" runat="server" Text="Motivo de la cancelación:"></asp:Label><br />
                          <asp:TextBox ID="txtMotivoCancelacion"  runat="server" Height="109px" 
                              Width="306px" ></asp:TextBox>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" Visible="false" 
                        onclick="btnGuardar_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>  
                    
                    </p>
            </div>
</asp:Content>
