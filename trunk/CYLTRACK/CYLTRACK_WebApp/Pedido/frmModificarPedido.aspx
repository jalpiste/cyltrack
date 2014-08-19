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
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
                        <br />
                    <asp:TextBox ID="txtNumPedido" CssClass="textEntry" runat="server" 
                            Width="112px" ontextchanged="TxtNumPedido_TextChanged"  ></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="ValidarDatosPedido" runat="server" ControlToValidate="txtNumPedido" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." 
                             ValidationGroup="Validar" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                    
                     <asp:RegularExpressionValidator ID="ValidarPedido" runat="server" ControlToValidate="txtNumPedido" 
                            CssClass="failureNotification" ErrorMessage="El pedido debe contener solo dígitos numéricos" 
                            ValidationExpression="\d*"  Font-Size = "Small" Display ="Dynamic"
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
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" runat="server" 
                            Width="197px" Enabled="false" ></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="CedulaCli" runat="server" ControlToValidate="txtCedulaCliente" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="ModificarPedido" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidarCedulaCli" runat="server" ControlToValidate="txtCedulaCliente" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" ></asp:RegularExpressionValidator>
                    --%>
                        <asp:Label ID="lblId_Cliente" runat="server" Visible="false"></asp:Label>
                    </p>                   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"  ></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                               <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <div id="divDirCliente" runat="server" visible="false">  
                   <div class="post">Direcciones del Cliente</div> 
                    <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" 
                    CellPadding="7" ForeColor="#333333" GridLines="None" Visible="false">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="IdUbicacion" DataField="IdUbicacion" HeaderText="IdUbicacion"
                            HeaderStyle-Width="100px" Visible="false">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Direccion" DataField="Direccion" HeaderText="Dirección"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Barrio" DataField="Barrio"  HeaderText="Barrio"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Telefono" DataField="Telefono" HeaderText="Teléfono"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Ciudad" DataField="Ciudad" HeaderText="Ciudad"
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
                </div>
                   <div class="post">Información Pedido</div>
                    <asp:Label ID="lblTamano" runat="server" Text="Tamaño Cilindro:"></asp:Label>
    <asp:DropDownList ID="lstTamanos" runat="server">
    </asp:DropDownList>
    <asp:Label ID="lblCantidad" runat="server" Text="Cantidad"></asp:Label>
    <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
    <asp:Button ID="btnEjecutar" runat="server" Text="Agregar" OnClick="btnEjecutar_Click" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="False" 
        onclick="btnModificar_Click" />
    <asp:GridView ID="grvPrueba" runat="server" AutoGenerateDeleteButton="True" 
        AutoGenerateEditButton="True" onrowdeleting="grvPrueba_RowDeleting" 
        onrowediting="grvPrueba_RowEditing">
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
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones:"></asp:Label>
                    
                        <br />  
                          <asp:TextBox ID="txtObservaciones" runat="server" Height="65px" Width="289px" CssClass="textEntry" ></asp:TextBox>
                      <br />
                   </div>
                </fieldset>
                <p class="submitButton">
                  
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px"  Visible="false"
                        OnClick="btnGuardar_Click" ValidationGroup="ModificarPedido"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click"/>  
                   
                    </p>
            </div>
</asp:Content>
