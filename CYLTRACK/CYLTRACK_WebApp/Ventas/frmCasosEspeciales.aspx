<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCasosEspeciales.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmCasosEspeciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Casos Especiales
    </h1>
     <div class="accountInfo">
      <asp:ValidationSummary ID="RegistrarCaso" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarCaso" />
                 <asp:ValidationSummary ID="validarCodigo" runat="server" CssClass="failureNotification" 
                 ValidationGroup="validarCodigo" />
  <fieldset class="login" style="width: 777px">
             
                <legend>Casos Especiales</legend>
                <h3>
                Digite el número de cédula del cliente o código de la venta
                </h3>
                <br />
                    <asp:Label ID="lblCedulaCliente" runat="server" Text="Cédula Cliente:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblIdVenta" runat="server" Text="Código Venta:"></asp:Label>
                        <br />
                    <asp:TextBox ID="txtCedulaCliente" runat="server" CssClass="textEntry" 
                    Width="197px" ontextchanged="txtCedulaCliente_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConsultarVentaRequired" runat="server" ControlToValidate="txtCedulaCliente"
                        CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio."
                        ToolTip="El número de cédula del cliente es obligatorio." ValidationGroup="ConsultarVentaValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txtCodVenta" runat="server" CssClass="textEntry" 
                    ontextchanged="txtCodVenta_TextChanged"></asp:TextBox>
                    <br />
        <div id="DivInfoVenta" runat = "server" visible ="false" >
                <div class="post">Información Venta</div>   
                <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtFecha" runat="server" enabled ="false" CssClass="textEntry" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblHora" runat="server" Text="Hora: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtHora" runat="server" Width="90px" enabled ="false" CssClass="textEntry" ></asp:TextBox>
                <asp:Label ID="lblIdVehiculo" runat="server" Visible="false" ></asp:Label>
                <br />
                <br />
                <p>
                        <asp:Label ID="lblCedula2" runat="server" text="Cédula del cliente:"></asp:Label>
                       <br />
                       <asp:TextBox ID="txtCedula2" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
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
                        <h4>
                          <asp:Label ID="lblDirClientes" runat="server" Text="Seleccione la dirección que desea consultar:"></asp:Label>
                          </h4>
                   <br />
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
                <div id="divVerifInfo" runat="server" visible="false">
                 <div class="post">Verificación de Información</div> 
                 
               <h3>Seleccione la opcion correspondiente a su caso: </h3>
                    <asp:ListBox ID="lstCaso" runat="server" Rows="1" AutoPostBack="True"
                        onselectedindexchanged="lstCaso_SelectedIndexChanged" >
                       </asp:ListBox>
               <asp:RequiredFieldValidator ID="validListaCaso" runat="server" ControlToValidate="lstCaso" 
                             CssClass="failureNotification" ErrorMessage="El tipo de caso es obligatorio." ToolTip="El tipo de caso es obligatorio." 
                             ValidationGroup="RegistrarCaso">*</asp:RequiredFieldValidator>
                    <div id="divGrid" runat="server" visible="false">
                    <h3>Seleccione el cilindro del caso a registrar: 
                        <asp:Label ID="lblIdDetalleV" runat="server" Visible="false"></asp:Label>
                        </h3>
                    
                    <asp:Label ID="lblMsn" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:GridView ID="gvCargue" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                    <asp:BoundField SortExpression="Id_Det_Venta" DataField="Id_Det_Venta" Visible="false"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="CodigosCilindros" DataField="CodigosCil" HeaderText="Códigos Cilindros"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamamo" DataField="Tamano" HeaderText="Tamaño"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="TipoCil" DataField="TipoCil" HeaderText="Tipo de Cilindro"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:RadioButton ID="Agregar" runat="server" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("Id_Det_Venta")%>' value2='<%# Eval("CodigosCil")%>'  OnCheckedChanged="SeleccionCilCaso_onClick"  />
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
                    </div>    
                    <div id="divEscape" runat="server" visible="false">
             <br />
                <br />
                  <asp:Label ID="lblEscape" runat="server" Text="Seleccione el código del cilindro a entregar:"></asp:Label> 
                 <br />
                 <asp:ListBox ID="lstCilEntrega" runat="server" Rows="1" />         
           </div>
           <div id="divCodCorrecto" runat="server" visible="false">
             <br />
                 <asp:Label ID="lblCodigoVerific" runat="server" 
                   Text="Digite el código del cilindro correcto y presione la tecla enter:"></asp:Label> 
                 <br />
                 <asp:TextBox ID="txtCodigoVerific" runat="server" CssClass="textEntry" 
                   ontextchanged="txtCodigoVerific_TextChanged"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;
                  <asp:RegularExpressionValidator ID="validarCodigoExpresion" runat="server" ControlToValidate="txtCodigoVerific" 
                            CssClass="failureNotification" ErrorMessage="El código del cilindro debe contener 12 dígitos." 
                            ValidationExpression="^([\d]{12})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="validarCodigo" ></asp:RegularExpressionValidator>
           </div>
               <br />
                    <asp:Label ID="lblObserva" runat="server" Text="Observaciones"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtObserva" runat="server" CssClass="textEntry" Height="77px" Width="306px"></asp:TextBox>
                     <br />
             </div>           
          </fieldset>
        </div>
                <p class="submitButton">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="115px" 
                        visible="false" onclick="btnGuardar_Click" ValidationGroup="RegistrarCaso"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                        onclick="btnMenu_Click" />
               </p>
           
</asp:Content>
