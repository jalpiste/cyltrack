<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegistrarCliente.aspx.cs" Inherits="CYLTRACK_WebApp.Account.frmcrearcliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Registrar Cliente
    </h1>
        <asp:ValidationSummary ID="RegistrarClienteValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarClienteValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Cliente</legend>
                                   <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                   
                    </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                    <div class="post">
                    
                     Datos Personales del Cliente</div>
                  
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente" >Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtNombreClienteRequired" runat="server" ControlToValidate="txtNombreCliente" 
                             CssClass="failureNotification" ErrorMessage="El nombre del cliente es obligatorio." ToolTip="El nombre del cliente es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:" ></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtPrimerApellidoRequired" runat="server" ControlToValidate="txtPrimerApellido" 
                             CssClass="failureNotification" ErrorMessage="El apellido del cliente es obligatorio." ToolTip="El apellido del cliente es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido"  runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:"  ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        &nbsp;</p> 
                   
                      <p>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtDirecciónRequired" runat="server" ControlToValidate="txtDireccion" 
                             CssClass="failureNotification" ErrorMessage="La dirección es obligatorio." ToolTip="La dirección es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Width="197px" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtBarrioRequired" runat="server" ControlToValidate="txtBarrio" 
                             CssClass="failureNotification" ErrorMessage="El barrio es obligatorio." ToolTip="El barrio es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                          </p> 
                          <p><asp:Label ID="lblDepartamento" runat="server" AssociatedControlID="lstDepartamento" 
                            Width="679px">Departamento:</asp:Label></p>
                    <p>
                        <asp:ListBox ID="lstDepartamento" runat="server" Rows="1">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="lstDepartamentoRequired" runat="server" ControlToValidate="lstDepartamento" 
                             CssClass="failureNotification" ErrorMessage="El departamento es obligatorio." ToolTip="El departamento es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                       
                        </p>
                    <p><asp:Label ID="lblCiudad" runat="server" AssociatedControlID="LstCiudad" Width="685px" >Ciudad:</asp:Label></p>
                    <p>
                        <asp:ListBox ID="LstCiudad" runat="server" Rows="1">
                            <asp:ListItem>Seleccionar</asp:ListItem>
                            </asp:ListBox>
                     <asp:RequiredFieldValidator ID="lstCiudadRequired" runat="server" ControlToValidate="LstCiudad" 
                             CssClass="failureNotification" ErrorMessage="La ciudad es obligatorio." ToolTip="La ciudad es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                            </p>  
                        
                    
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" ></asp:Label>
                    </p>
                        <p>
                           <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="txtTelefonoRequiredField" runat="server" ControlToValidate="txtTelefono" 
                             CssClass="failureNotification" ErrorMessage="El telefono del cliente es obligatorio." ToolTip="El telefono del cliente es obligatorio." 
                             ValidationGroup="RegistrarClienteValidationGroup">*</asp:RequiredFieldValidator>
                    </p>
                    </div>
                  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Width="121px" 
                        onclick="btnLimpiar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="121px" 
                        onclick="btnGuardar_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" 
                        Width="121px" onclick="btnMenuPrincipal_Click" />
               </p>
            </div>
</asp:Content>
