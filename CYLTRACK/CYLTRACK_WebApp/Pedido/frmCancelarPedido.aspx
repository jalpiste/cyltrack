<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCancelarPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido.frmCancelarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Cancelar Pedido
    </h1>
            <asp:ValidationSummary ID="CancelarPedidoValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="CancelarPedido"  Font-Size = "Small"/>
            <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>


            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Cancelación de Pedidos</legend>
                                      <p>
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
                        <br />
                        <asp:TextBox ID="txtNumPedido" CssClass="textEntry" runat="server" 
                              Width="112px" ontextchanged="txtNumPedido_TextChanged"></asp:TextBox><br />
                     <asp:RequiredFieldValidator ID="ValidarDatosPedido" runat="server" ControlToValidate="txtNumPedido" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." 
                             ValidationGroup="ValidarCedula" Font-Size = "Small" Display ="Dynamic"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarPedido" runat="server" ControlToValidate="txtNumPedido" 
                            CssClass="failureNotification" ErrorMessage="El número del pedido debe contener entre 1 y 5 dígitos." 
                            ValidationExpression="^([\d]{1,5})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="ValidarCedula" ></asp:RegularExpressionValidator>
                   
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
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                     <asp:Label ID="lblIdUbica" runat="server" Visible="false"></asp:Label>                      
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
                <div id="divInfoPedido" runat="server" visible="false" >
                   <div class="post">Información Pedido</div>
                                     
                    <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" > 
                              
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
                        <asp:BoundField SortExpression="FechaPedido" DataField="FechaPedido" HeaderText="Fecha "
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="200px" />
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
                   </div>

                          <br />                      
                      <p>
                          <asp:Label ID="lblMotivoCancelacion" runat="server" Text="Motivo de la cancelación:"></asp:Label><br />
                          <asp:TextBox ID="txtMotivoCancelacion"  runat="server" Height="71px" 
                              Width="306px" TextMode="MultiLine" ontextchanged="txtMotivoCancelacion_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ValidarMotivo" runat="server" ControlToValidate="txtMotivoCancelacion" 
                             CssClass="failureNotification" ErrorMessage="El motivo de cancelación del pedido es obligatorio." ToolTip="El motivo de cancelación del pedido es obligatorio." 
                             ValidationGroup="CancelarPedido">*</asp:RequiredFieldValidator>
                      </p>
                   </div>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" Visible="false" 
                        onclick="btnGuardar_Click" ValidationGroup="CancelarPedido"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click" />  
                    
                    </p>
            </div>
</asp:Content>
