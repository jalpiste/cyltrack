<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmConsultarCliente.aspx.cs" Inherits="CYLTRACK_WebApp.Account.frmconsultarcliente" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
     <h1 style="margin-top: 75px">
        Consultar Cliente
    </h1>
       <asp:ValidationSummary ID="ConsultarClienteValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ConsultarClienteValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Consulta de Clientes</legend>
                                   <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" Width="725px">Número de Cédula:</asp:Label><br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" Width="197px" 
                                           ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cedula del cliente es obligatorio." ToolTip="La cedula del cliente es obligatorio." 
                             ValidationGroup="ConsultarClienteValidationGroup">*</asp:RequiredFieldValidator>
 
                    </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Datos Personales del Cliente</div>   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Text="Angelica" Width="197px" Enabled="False"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Text="Durán" Width="197px" Enabled="False"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Text="Suarez" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        </p> 
                   
                      <p>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Text="Cra 10 N 22-56" Width="197px" Enabled="False"></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" Text="La Pola" Width="197px" Enabled="False" ></asp:TextBox>
                    </p> 
                    <p><asp:Label ID="lblCiudad" runat="server"  >Ciudad:</asp:Label></p>
                    <p><asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Text="Chiquinquirá" Width="197px" Enabled="False"></asp:TextBox>
                      
                        </p>  
                        <p><asp:Label ID="lblDepartamento" runat="server" >Departamento:</asp:Label></p>
                    <p><asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Text="Boyacá" Width="197px" Enabled="False"></asp:TextBox>
                           
                        </p>
                    
                     <p> 
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:"></asp:Label>
                    </p>
                        <p>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Text="3203445555" Enabled="False"></asp:TextBox>
                    </p>
                    <p>
                    
                        <asp:Label ID="lblCodigoCilindro" runat="server" Text="Código Cilindro: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoCilindro" runat="server" Text="Tipo de Cilindro: "></asp:Label>
                    </p>
                    <p>
                        <asp:TextBox ID="txtCodigoCilindro" CssClass="textEntry" Enabled="false" runat="server" Text="99158354679"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTamano" runat="server" CssClass="textEntry" Enabled="false" Text="100"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtTipoCilindro" Enabled="false" CssClass="textEntry" Text="Marca" runat="server"></asp:TextBox>
                    </p>
                  </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnNuevaConsulta" runat="server" Text="Nueva Consulta" 
                        onclick="btnNuevaConsulta_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menu Principal" 
                        onclick="btnMenuPrincipal_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
            </div>
</asp:Content>
