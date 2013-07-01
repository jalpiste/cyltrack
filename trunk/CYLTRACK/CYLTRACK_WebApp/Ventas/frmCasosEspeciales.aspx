<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCasosEspeciales.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmCasosEspeciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Casos Especiales
    </h1>
     <div class="accountInfo">
  <fieldset class="login" style="width: 777px">
                <legend>Casos Especiales</legend>
                <h3>
                Digite el número de cédula del cliente
                </h3>
                <br />
                    <asp:Label ID="lblCedulaCliente" runat="server" Text="Cédula cliente:"></asp:Label>
                        <br />
                    <asp:TextBox ID="txtCedulaCliente" runat="server" CssClass="textEntry" 
                    Width="197px" ontextchanged="txtCedulaCliente_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConsultarVentaRequired" runat="server" ControlToValidate="txtCedulaCliente"
                        CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio."
                        ToolTip="El número de cédula del cliente es obligatorio." ValidationGroup="ConsultarVentaValidationGroup">*</asp:RequiredFieldValidator>
                    <br />
         <div id="DivInfoVenta" runat = "server" visible ="false" >
                <div class="post">Información Venta</div>   
                <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtFecha" runat="server" enabled ="false" CssClass="textEntry"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblHora" runat="server" Text="Hora: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtHora" runat="server" Width="90px" enabled ="false" CssClass="textEntry"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblNumCed" runat="server" text="Número de Cédula: "></asp:Label>
                <br />
               <asp:TextBox ID="txtNumCedula" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox> <br />
               <br />
               <asp:Label ID="lblNombreCliente" runat="server" text="Nombres del cliente:"></asp:Label>
                <br />
               <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox> <br />
               <br />
                       <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                       <br />
               <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" enabled ="false" Width="197px" ></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido"  runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
                                <br /><br />
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <br />
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <br/><br/>
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Label ID="DepartamentoLabel" runat="server" text="Departamento:"></asp:Label><br/>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox><br/><br/>
             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
             <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br/><br/>
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <br />
                <asp:TextBox ID="txtObservacion" runat="server" Height="77px" Width="306px" enabled ="false" CssClass="textEntry"></asp:TextBox>
                <br /><br />
                 </div>
                <div id="divVerifInfo" runat="server" visible="false">
                 <div class="post">Verificación de Información</div> 
                 
               <h3>Seleccione la opcion correspondiente a su caso: </h3>
                    <asp:ListBox ID="lstCaso" runat="server" Rows="1" AutoPostBack="True"
                        onselectedindexchanged="lstCaso_SelectedIndexChanged">
                        <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                        <br />

                    <div id="divGrid" runat="server" visible="false">
                    <h3>Seleccione el cilindro del caso a registrar: </h3>
                    
                    <asp:Label ID="lblMsn" runat="server" Visible="False"></asp:Label>
                    <br />
                    <asp:GridView ID="gvCargue" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None"  >
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
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:RadioButton ID="Agregar" runat="server" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("CodigosCil")%>' OnCheckedChanged="Agregar_onClick"  />
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
                    <div id="divEscape" runat="server" visible="false">
             <br />
                  <asp:Label ID="lblEscape" runat="server" Text="Seleccione el código del cilindro a entregar:"></asp:Label> 
                 <br />
                 <asp:ListBox ID="lstCilEntrega" runat="server" Rows="1" />         
           </div>
           <div id="divCodCorrecto" runat="server" visible="false">
             <br />
                 <asp:Label ID="lblCodigoVerific" runat="server" Text="Digite el código del cilindro correcto:"></asp:Label> 
                 <br />
                 <asp:TextBox ID="txtCodigoVerific" runat="server" CssClass="textEntry"></asp:TextBox>
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
                        visible="false" onclick="btnGuardar_Click"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                        onclick="btnMenu_Click" />
               </p>
           
</asp:Content>
