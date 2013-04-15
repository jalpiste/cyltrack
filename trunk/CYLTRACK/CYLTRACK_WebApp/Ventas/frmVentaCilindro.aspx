<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmVentaCilindro.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmVentaCilindro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h1 style="margin-top: 75px">
        Venta de Cilindro
    </h1>
              <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="EntregaCilindroValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="EntregaCilindroValidationGroup"/>
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
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="EntregaCilindroValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="TxtNumPedido" CssClass="textEntry" runat="server" 
                            ontextchanged="TxtNumPedido_TextChanged"></asp:TextBox><br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>   
                    <h5>
                        <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" Text="2323432"></asp:Label>
                    </h5>
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" text="Nombres del cliente:"></asp:Label></p>
                       <p>
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                       
                             </p>
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                       
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido"  runat="server" CssClass="textEntry" 
                                Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                      <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                       
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;
                       
                       <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; 
                        <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label></p>
                     
                     <p> 
                    <asp:ListBox ID="lstDireccion" runat="server" Rows="1"> 
                    <asp:ListItem>Calle 3 Nº 2-49</asp:ListItem></asp:ListBox>                        
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                       <asp:TextBox ID="Barrio" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="False"></asp:TextBox>
                    &nbsp;</p>
                   

                   
                    <p>
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                    <asp:Label ID="DepartamentoLabel" runat="server" text="Departamento:"></asp:Label> </p>
                    <p>
                    <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="False"></asp:TextBox>
                       
                         </p>
                                         
                   <div class="post">Información Cilindro Cliente</div>
                  <p>
                      <asp:Label ID="lblCilindro" runat="server" Text="Cilindro:"></asp:Label>
                      &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label>
                  &nbsp;&nbsp;
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                      <asp:Label ID="lblCantidad" runat="server" Text="Cantidad: "></asp:Label>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblTipo" runat="server" Enabled="false" Text="Tipo Cilindro:"></asp:Label>
                        </p>
                  <p>
                  
                      <asp:TextBox ID="txtCilindro" runat="server" Text="11809615345" CssClass="textEntry" Enabled="False"></asp:TextBox>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:TextBox ID="txtTamano" runat="server" Enabled="false" CssClass="textEntry" Text="30" Width="51px"></asp:TextBox>
                  
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                  <asp:TextBox ID="txtCantidadCil" runat="server" CssClass="textEntry" Width="49px" Text="1" 
                          Enabled="False"></asp:TextBox>
                  
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:TextBox ID="txtTipoCil" Enabled="false" CssClass="textEntry"  Text="universal" runat="server"></asp:TextBox>
                  
                  </p>
                   <div class="post">Información Cilindro del Pedido</div>
                    <p>

                        <asp:Label ID="lblCilindroPedido" runat="server" Text="Codigo Cilindro a Entregar: "></asp:Label>
                       
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="lblTamanoCil" runat="server" Text="Tamaño:"></asp:Label>
                       
                    </p>
                    <p>
                    
                       <asp:ListBox ID="LstCodigos" runat="server" Rows="1">
                            <asp:ListItem>11809656781</asp:ListItem>
                            <asp:ListItem>11809656782</asp:ListItem>
                            <asp:ListItem>11809656783</asp:ListItem>
                            <asp:ListItem>11809656784</asp:ListItem>
                        </asp:ListBox>
                         <asp:RequiredFieldValidator ID="LstCodigosRequired" runat="server" ControlToValidate="LstCodigos" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El codigo del cilindro es obligatorio." 
                             ValidationGroup="EntregaCilindroValidationGroup">*</asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="TxtTamanoCil" runat="server" Width="44px" CssClass="textEntry" Enabled="false"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="TxtTamanoCilRequired" runat="server" ControlToValidate="TxtTamanoCil" 
                             CssClass="failureNotification" ErrorMessage="El tamaño del cilindro es obligatorio." ToolTip="El tamaño del cilindro es obligatorio." 
                             ValidationGroup="EntregaCilindroValidationGroup">*</asp:RequiredFieldValidator>

                    </p>
                    <p>
                    
                        <asp:Label ID="lblObservacion" runat="server" Text="Observación: "></asp:Label><br />
                        <asp:TextBox ID="txtObservacion" runat="server" Height="77px" Width="306px"></asp:TextBox>
                    </p>
                    </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnGuardar" runat="server" Visible="false" Text="Guardar" Width="115px"
                        onclick="btnGuardar_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" onclick="btnMenuPrincipal_Click1" 
                       />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
            </div>
</asp:Content>
