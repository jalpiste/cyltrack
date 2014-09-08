<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="frmModificarCliente.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Clientes.frmModificarCliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
       <h1 style="margin-top: 75px">
        Modificar Cliente
    </h1>
     <asp:ValidationSummary ID="ModificarClienteValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarCliente" Font-Size = "Small"/>
     <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarCedula" Font-Size = "Small"/>
     
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificación de Cliente</legend>
                                   <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="ValidarCedula" >*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  ValidationGroup="ValidarCedula" >*</asp:RegularExpressionValidator>
                    
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Datos Personales del Cliente</div>   
                    <p>
                        <asp:Label ID="lblCedulaCli" runat="server" >Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedulaCli" runat="server" CssClass="textEntry" Enabled="false"
                            Width="197px"  ></asp:TextBox>                         
                        <asp:Label ID="lblIdCliente" runat="server" Visible="false"></asp:Label>
                    </p>
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" >Nombre del Cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtNombreCliente_TextChanged"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="ValidarNombre" runat="server" ControlToValidate="txtNombreCliente" 
                             CssClass="failureNotification" ErrorMessage="El nombre del cliente es obligatorio." ToolTip="El nombre del cliente es obligatorio." 
                             ValidationGroup="ModificarCliente">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosNom" runat="server" ControlToValidate="txtNombreCliente" 
                    CssClass="failureNotification" ErrorMessage="El nombre debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="ModificarCliente" >*</asp:RegularExpressionValidator>
                    
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:"></asp:Label>
                   <br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtPrimerApellido_TextChanged"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="ValidarApellido" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del cliente es obligatorio." ToolTip="El apellido del cliente es obligatorio." 
                             ValidationGroup="ModificarCliente">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="ValidarDatosApe" runat="server" ControlToValidate="txtPrimerApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20})$"  
                    ValidationGroup="ModificarCliente" >*</asp:RegularExpressionValidator>
                    
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" 
                                Width="197px" ontextchanged="txtSegundoApellido_TextChanged" ></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="ValidarDatosApe2" runat="server" ControlToValidate="txtSegundoApellido" 
                    CssClass="failureNotification" ErrorMessage="El apellido debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z]{0,20} {0,20})$"   
                    ValidationGroup="ModificarCliente" >*</asp:RegularExpressionValidator>                    
                    </p> 
                    </div>
                   <div id="divDireccionesCli" runat="server" visible="false">
                     <div class="post">Direcciones Registradas del Cliente</div> 
                    <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" 
                    CellPadding="7" ForeColor="#333333" GridLines="None"  > 
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
                                <asp:Button ID="modificarCliente" Text="Modificar" runat="server" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("IdUbicacion")%>' OnClick="Agregar_onClick" />
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
                <div id="divModificacionCiente" runat="server" visible="false">
                 <div class="post">Información de la Dirección Seleccionada</div> 
                <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:"  ></asp:Label>
                        <br />
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtDireccion_TextChanged" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtDirecciónRequired" runat="server" ControlToValidate="txtDireccion" 
                             CssClass="failureNotification" ErrorMessage="La dirección del cliente es obligatoria." ToolTip="La dirección del cliente es obligatoria." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                                              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" 
                                Width="197px" ontextchanged="txtBarrio_TextChanged" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtBarrioRequired" runat="server" ControlToValidate="txtBarrio" 
                             CssClass="failureNotification" ErrorMessage="El barrio es obligatorio." ToolTip="El barrio es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>

                              <asp:RegularExpressionValidator ID="ValidarDatosBarrio" runat="server" ControlToValidate="txtBarrio" 
                    CssClass="failureNotification" ErrorMessage="El barrio debe contener sólo caracteres alfabéticos." 
                        ValidationExpression="^([A-Za-z](.{0,20}))$"  
                    ValidationGroup="RegistrarClienteValidationGroup" >*</asp:RegularExpressionValidator>
                    
                   </p>  
                         <p><asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label>
                            <br />
                        <asp:ListBox ID="lstDepartamento" runat="server" Rows="1"  AutoPostBack="true"
                                 onselectedindexchanged="lstDepartamento_SelectedIndexChanged" 
                                 Width="123px"/>

                            <asp:RequiredFieldValidator ID="lstDepartamentoRequired" runat="server" ControlToValidate="lstDepartamento" 
                             CssClass="failureNotification" ErrorMessage="El departamento es obligatorio." ToolTip="El departamento es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                       
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:ListBox ID="lstCiudad" runat="server" Rows="1" 
                                 onselectedindexchanged="lstCiudad_SelectedIndexChanged" />

                     <asp:RequiredFieldValidator ID="lstCiudadRequired" runat="server" ControlToValidate="lstCiudad" 
                             CssClass="failureNotification" ErrorMessage="La ciudad es obligatorio." ToolTip="La ciudad es obligatorio." 
                             ValidationGroup="ModificarCliente">*</asp:RequiredFieldValidator>
                             <asp:Label ID="lblIdUbica" runat="server" Visible="false"></asp:Label>
                           </p>
                  <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Teléfono:"></asp:Label>
                    <br />
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" 
                             ontextchanged="txtTelefono_TextChanged" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTelefonoRequiredField" runat="server" ControlToValidate="txtTelefono" 
                             CssClass="failureNotification" ErrorMessage="El teléfono del cliente es obligatorio." ToolTip="El teléfono del cliente es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>

                    <asp:RegularExpressionValidator ID="ValidarDatosTel" runat="server" ControlToValidate="txtTelefono" 
                    CssClass="failureNotification" ErrorMessage="El número de teléfono (fijo o móvil) debe contener entre 7 y 10 dígitos." 
                        ValidationExpression="^([\d]{7,10})$"  ToolTip="Sólo caractéres numéricos." 
                    ValidationGroup="RegistrarClienteValidationGroup" >*</asp:RegularExpressionValidator>
                    </p>
                   </div>
                <div id="divNuevaDir" runat="server" visible="false">
                <p>
                   <asp:HyperLink ID="hprNuevaUbicacion" runat="server" >Agregar Nueva Ubicación del cliente</asp:HyperLink>
                </p> 
                     </div>                    
                </fieldset>
                 </div> 
                <p class="submitButton">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" visible="false"
                        Width="115px" onclick="btnGuardar_Click" ValidationGroup="ModificarCliente"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="115px"  onclick="btnMenuPrincipal_Click" />
               </p>
           
</asp:Content>
