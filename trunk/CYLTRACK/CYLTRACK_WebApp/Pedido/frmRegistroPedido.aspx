<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegistroPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido.frmRegistroPedido" EnableViewState="true" %>

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
                         <asp:Label ID="lblIdCedula" runat="server" Visible="false" ></asp:Label>
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
                                        <div id="divDirCliente" runat="server" visible="false">  
                   <div class="post">Direcciones del Cliente</div> 
                    <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" 
                    CellPadding="7" ForeColor="#333333" GridLines="None" >
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
                    <p>

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
