<%@ Page Title="" EnableEventValidation="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentaCilindro.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmVentaCilindro" EnableViewState="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h1 style="margin-top: 75px">
        Venta de Cilindro
    </h1>
              <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="VentadeCilindros" runat="server" CssClass="failureNotification" 
                 ValidationGroup="VentadeCilindros"/>
            <asp:ValidationSummary ID="AgregarVenta" runat="server" CssClass="failureNotification" 
                 ValidationGroup="AgregarVenta"/>
            <asp:ValidationSummary ID="ValidarSiembra" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarSiembra"/>
            <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Venta de Cilindros</legend>
                   <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
&nbsp;&nbsp; <br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="112px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cédula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="EntregaCilindroValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtNumPedido" CssClass="textEntry" runat="server" 
                            ontextchanged="txtNumPedido_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValidadorPedido" runat="server" ControlToValidate="txtNumPedido" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." ToolTip="El número del pedido es obligatorio." 
                             ValidationGroup="EntregaCilindroValidationGroup">*</asp:RequiredFieldValidator>
                    
                           <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: " Visible="false"></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Visible="false" ></asp:Label>
                    </h5>
                        <p>
                        <asp:Label ID="lblCedulaCliente" runat="server" text="Cédula del cliente:"></asp:Label>
                       <br />
                       <asp:TextBox ID="txtCedulaCliente" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                            <asp:Label ID="lblIdCliente" runat="server" Visible="false"></asp:Label>
                       </p>
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" text="Nombres del cliente:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="389px" Enabled="False" ></asp:TextBox>
                        <asp:Label ID="lblIdUbica" runat="server" Visible="false"></asp:Label>
                       </p>
                       </div>
                      <div id="divDirCliente" runat="server" visible="false">  
                   <div class="post">Direcciones del Cliente</div> 
                   <h3>
                    Seleccione la dirección del cliente en donde se realizará la venta: 
                    </h3>
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
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:RadioButton ID="rdDirCli" runat="server" Text="Seleccion" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("IdUbicacion")%>' OnCheckedChanged="Seleccion_onClick"  />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                     <div id="DivInfoPedido" runat="server" visible="false">
                  <div class="post" >
                      <asp:Label ID="lblPost" runat="server" Text="Información Pedido"></asp:Label>
                      </div> 
                                           
      <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="Tamamo" DataField="Tamano"  HeaderText="Tamaño"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cantidad" DataField="Cantidad" HeaderText="Cantidad"
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
        
               <div id="DivDetalleVenta" runat="server" visible="false">
               
                   <div class="post">Información de la Venta de Cilindros</div>
                   <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño Cilindro:"></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:ListBox ID="lstTamano" runat="server" Rows="1" Width="86px">
                                 </asp:ListBox>

                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstTamano" 
                             CssClass="failureNotification" ErrorMessage="El tamaño de cilindro es obligatorio." ToolTip="El tamaño del Cilindro es obligatorio." 
                             ValidationGroup="AgregarVenta">*</asp:RequiredFieldValidator>
                             
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          &nbsp;&nbsp;
                          
                          <asp:Button ID="btnAgregar" runat="server" Text="Buscar" Width="115px" onclick="btnAgregar_Click" 
                         ValidationGroup="AgregarVenta"/>
                  
                          <asp:Label ID="lblIdVehiculo" runat="server" Visible="false"></asp:Label>
        
    <table border="0">
        <tr>
            <td valign="top">
                 <asp:GridView ID="gvCilVehiculo" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>                        
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" value='<%# Eval("CodigosCilVehiculo")%>' OnCheckedChanged="CheckVehiculo_onClick" />
                            </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigosCilVehiculo" HeaderText="Cilindros Vehículos" />                        
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <EmptyDataTemplate>
                         No hay registros
                     </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"  />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td valign="middle">
                <asp:Button ID="btnSeleccionar" Visible="false" runat="server"  Text=">>" 
                    onclick="btnSeleccionarVehiculo_Click" /> <br/><br/>
                <asp:Button ID="btnQuitar" runat="server" Visible="false" Text="<<" onclick="btnSeleccionarVehiculo_Click" />
            </td>
            <td valign="top">
                <asp:GridView ID="gvSeleccion" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>                        
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion" runat="server" value='<%# Eval("CodigosVehiSeleccionados")%>' OnCheckedChanged="CheckSelecVehiculo_onClick" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigosVehiSeleccionados" HeaderText="Cilindros Agregados" />                        
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        Seleccione un item de la lista para agregar
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td></td>
            <td></td>
            <td valign="top">
                 <asp:GridView ID="gdCodClientes" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>                        
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion2"  runat="server" value='<%# Eval("CodigosCilCliente")%>' OnCheckedChanged="CheckCliente_onClick" />
                            </ItemTemplate>                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigosCilCliente" HeaderText="Cilindros Cliente" />                        
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                     <EmptyDataTemplate>
                         No hay registros
                     </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333"  />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
            <td valign="middle">
                <asp:Button ID="btnSelect" runat="server" Visible="false" Text=">>" 
                 onclick="btnSeleccionarCliente_Click"         /> <br/><br/>
                <asp:Button ID="btnQuitar2" runat="server" Visible="false" Text="<<" onclick="btnSeleccionarCliente_Click"  />
            </td>
            <td valign="top">
                <asp:GridView ID="gdCilSelecCliente" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:TemplateField>                        
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSeleccion3" runat="server" value='<%# Eval("CodigosCliSeleccionados")%>' OnCheckedChanged="CheckSelecCliente_onClick" />
                            </ItemTemplate>
                        
                        </asp:TemplateField>
                        <asp:BoundField DataField="CodigosCliSeleccionados" HeaderText="Cilindros Agregados" />                        
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        Seleccione un item de la lista para agregar
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White"  />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
    </table>          
                
                    <div id="divCilSiembra" runat="server" visible="false">
                    <div class="post">Tipo de Entrega de Cilindros</div>
                    <p>
                        <asp:Label ID="lblTipoVenta" runat="server" Text="Seleccione una de las opciones:"></asp:Label>
                    <br />
                    <asp:RadioButtonList ID="radioTipoDeVenta" runat="server" OnSelectedIndexChanged="SelectTipoVenta"  ValidationGroup="ValidarSiembra" AutoPostBack="True" Width="227px">
            <asp:ListItem>Intercambio</asp:ListItem>
            <asp:ListItem>Prestamo</asp:ListItem>
        </asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="validarSeleccionTipoVenta" runat="server" ControlToValidate="radioTipoDeVenta" 
                             CssClass="failureNotification" ErrorMessage="Debe seleccionar alguna de las opciones" ToolTip="Debe seleccionar alguna de las opciones" 
                             ValidationGroup="ValidarSiembra">*</asp:RequiredFieldValidator>
                </p>
                </div>
                <div id="divIntercambioCil" runat="server" visible="false">             
                     <div class="post">Proceso de Siembra de Cilindros</div>                    
                     <p>
                         <asp:Label ID="lblTipoCil" runat="server" Text="Tipo de Cilindro:"></asp:Label>
                          <asp:RadioButtonList ID="rdTipoCil" runat="server" AutoPostBack="true">
                             <asp:ListItem>Universal</asp:ListItem>
                             <asp:ListItem>Marcado</asp:ListItem>
                         </asp:RadioButtonList>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rdTipoCil" 
                             CssClass="failureNotification" ErrorMessage="Debe seleccionar alguna de las opciones" ToolTip="Debe seleccionar alguna de las opciones" 
                             ValidationGroup="ValidarSiembra">*</asp:RequiredFieldValidator>
                       </p>
                       <p>
                        <asp:Label ID="lblCilSiembra" runat="server" Text="Código Cilindro Recibido: "></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoCilSiembra" runat="server" Text="Tipo de Cilindro:"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtCilSiembra" runat="server" CssClass="textEntry"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="TxtCodigoCilindroRequired" runat="server" ControlToValidate="txtCilSiembra" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="ValidarSiembra">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="validarDatosCilindro" runat="server" ControlToValidate="txtCilSiembra" 
                            CssClass="failureNotification" ErrorMessage="El código del cilindro debe contener entre 11 y 12 dígitos." 
                            ValidationExpression="^([\d]{11,12})$"  Font-Size = "Small" ValidationGroup="ValidarSiembra">*</asp:RegularExpressionValidator>
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                       <asp:ListBox ID="lstTamSiembra" runat="server" AutoPostBack="True" Rows="1"  Width="116px" >         
                        </asp:ListBox>
                            <asp:RequiredFieldValidator ID="validTamano" runat="server" ControlToValidate="lstTamSiembra" 
                             CssClass="failureNotification" ErrorMessage="El tamaño del cilindro es obligatorio." ToolTip="El tamaño del cilindro es obligatorio." 
                             ValidationGroup="ValidarSiembra">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                        <asp:ListBox ID="lstTipoCil" runat="server"  Rows="1" AutoPostBack="True"></asp:ListBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lstTipoCil" 
                             CssClass="failureNotification" ErrorMessage="El tipo de cilindro es obligatorio." ToolTip="El tipo de cilindro es obligatorio." 
                             ValidationGroup="ValidarSiembra">*</asp:RequiredFieldValidator>
                            
                    </p>
                    </div>
                    <p>                    
                        <asp:Label ID="lblObservacion" runat="server" Text="Observación: "></asp:Label><br />
                        <asp:TextBox ID="txtObservacion" runat="server" Height="77px" Width="306px"></asp:TextBox>
                    </p>
                     </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="Guardar" 
                        Width="115px" onclick="btnGuardar_Click1" ValidationGroup="VentadeCilindros"
                        /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" onclick="btnMenuPrincipal_Click" 
                       />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
            </div>
</asp:Content>
