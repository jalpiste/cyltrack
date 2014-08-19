<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultarVenta.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmConsultarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Consultar Venta
    </h1>
<span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="ConsultarVentaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ConsultarVentaValidationGroup"/>
    <div>
            <fieldset class="login" style="width: 777px">
                <legend>Consulta de Venta</legend>
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
                <div id="divInfoCilindro" runat = "server" visible ="false" >
                <div class="post">Información Venta</div>   
                 <asp:GridView ID="gvCargue" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
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
                <div id="divInfoVendedor" runat="server" visible="false">
                 <div class="post">Vendedor</div>  
             <asp:Label ID="lblNombreConductor" runat="server" Text="Nombre: "></asp:Label><br />
             <asp:TextBox ID="txtNombreConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false" ></asp:TextBox>
             <br /><br />
             <asp:Label ID="lblApellidoConductor" runat="server" Text="Primer Apellido: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Label ID="lblSegundoApellidoConductor" runat="server" Text="Segundo Apellido: "></asp:Label><br />
             <asp:TextBox ID="txtApellidoConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false" ></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtSegundoApellidoConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false" ></asp:TextBox>
             <br /><br />
             <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Label ID="lblRuta" runat="server" Text="Ruta: "></asp:Label><br />
             <asp:TextBox ID="txtPlaca" CssClass="textEntry" Width="127px" runat="server" enabled ="false" ></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtRuta" CssClass="textEntry" Width="127px" runat="server" enabled ="false" ></asp:TextBox>
            <br /><br />
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <br />
                <asp:TextBox ID="txtObservacion" runat="server" Height="77px" Width="306px" enabled ="false" CssClass="textEntry"></asp:TextBox>
             <br />
             <br />
             </div>
             </fieldset>
           </div>        
        <p class="submitButton">                     
                <asp:Button ID="btnNuevaConsulta" runat="server" Visible="false" 
                    Text="Nueva Consulta" Width="115px" onclick="btnNuevaConsulta_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                    onclick="btnMenu_Click"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>     
</asp:Content>
