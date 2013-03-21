<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="frmModificarCliente.aspx.cs" Inherits="CYLTRACK_WebApp.Account.Clientes.frmModificarCliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
       <h1 style="margin-top: 75px">
        Modificar Cliente
    </h1>
     <asp:ValidationSummary ID="ModificarClienteValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarClienteValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificación de Cliente</legend>
                                   <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="ModificarClienteValidationGroup">*</asp:RequiredFieldValidator>
                   
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Datos Personales del Cliente</div>   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" >Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:"></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" 
                            Width="197px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" 
                                Width="197px" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoDireccion" runat="server" Text="Tipo de Dirección:"></asp:Label>
                        &nbsp;</p> 
                   
                      <p>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" 
                            Width="197px"></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" 
                                Width="197px" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:ListBox ID="lstTipoDireccion" runat="server" Rows="1">
                              <asp:ListItem>Residencia</asp:ListItem>
                              <asp:ListItem>Oficina</asp:ListItem>
                              <asp:ListItem>Deposito</asp:ListItem>
                          </asp:ListBox>
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server">Ciudad:</asp:Label></p>
                    <p>
                        <asp:ListBox ID="lstCiudad" runat="server" Rows="1">
                            <asp:ListItem>Chiquinquirá</asp:ListItem>
                            <asp:ListItem>Bogotá</asp:ListItem>
                            <asp:ListItem>Tunja</asp:ListItem>
                        </asp:ListBox>
                          
                        </p>  
                        <p><asp:Label ID="lblDepartamento" runat="server" >Departamento:</asp:Label></p>
                    <p>
                        <asp:ListBox ID="lstDepartamento" runat="server" Rows="1">
                            <asp:ListItem>Boyacá</asp:ListItem>
                            <asp:ListItem>Cundinamarca</asp:ListItem>
                        </asp:ListBox>
                          
                        </p>
                    
                     <p> 
                        <asp:Label ID="lblTipoTelefono" runat="server" Text="Tipo de Teléfono: "></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
                    </p>
                        <p>
                            <asp:ListBox ID="lstTipoTelefono" runat="server" Rows="1">
                                <asp:ListItem>Celular</asp:ListItem>
                                <asp:ListItem>Telefono</asp:ListItem>
                                <asp:ListItem>PBX</asp:ListItem>
                            </asp:ListBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry"></asp:TextBox>
                    </p>
                  <p>
                  
                      <asp:HyperLink ID="hprNuevaDireccion" runat="server">Agregar Nueva Dirección del cliente</asp:HyperLink>
                     </p> 
                     
                <p>
                
                    <asp:HyperLink ID="hprNuevoTelefono" runat="server">Agregar Nuevo Teléfono del cliente</asp:HyperLink>
                
                </p>
                    </div>
                </fieldset>
                <p class="submitButton">
                    <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar Datos" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
               </p>
            </div>
</asp:Content>
