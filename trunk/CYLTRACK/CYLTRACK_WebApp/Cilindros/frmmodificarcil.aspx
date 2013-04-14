 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmmodificarcil.aspx.cs"  MasterPageFile="~/Site.Master"Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Account.frmmodificarcil" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
      <h1 style="margin-top: 75px">
        Modificar Cilindro
    </h1>
      <asp:ValidationSummary ID="ModificacionCilindrosValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificacionCilindrosValidationGroup"/>
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Modificación de datos del Cilindro</legend>
                                   <p>
                        <asp:Label ID="lblCodigoCilindro" runat="server" AssociatedControlID="txtCodigoCilindro">Código Cilindro:</asp:Label><br />
                        <asp:TextBox ID="txtCodigoCilindro" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCodigoCilindro_TextChanged" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="txtCodigoCilindroRequired" runat="server" ControlToValidate="txtCodigoCilindro" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="ModificacionCilindrosValidationGroup">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <p>

                   </p>
                    <div id="divConsultarCilindro" runat="server" visible="false">              
                      <div class="post">
                          <asp:Label ID="PosterLbl" runat="server" Text="Datos Cilindro"></asp:Label>
                      </div> 
                     <p>
                         <asp:Label ID="lblAno" runat="server" Text="Año Fabricación:" ></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblEmpresa" runat="server" Text="Código Empresa:" ></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="lblCodigo" runat="server" Text="Código Cilindro:" ></asp:Label>
                    </p>
                    <p>
                         <asp:ListBox ID="lstAno" runat="server" AutoPostBack="True" Rows="1" 
                            >
                             <asp:ListItem>1990</asp:ListItem>
                             <asp:ListItem>1991</asp:ListItem>
                             <asp:ListItem>1992</asp:ListItem>
                             <asp:ListItem>1993</asp:ListItem>
                             <asp:ListItem></asp:ListItem>
                         </asp:ListBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:TextBox ID="txtEmpresa" runat="server" Width="80px" CssClass="textEntry" ></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        
                    &nbsp;&nbsp;
                         <asp:TextBox ID="txtCodigo" runat="server" Width="80px" CssClass="textEntry" 
                            ></asp:TextBox>
                    </p>
                    <p> 
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación: " ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:Label ID="lblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        </p>
                        <p>
                        <asp:ListBox ID="lstUbicacion" runat="server" AutoPostBack="True" Rows="1" 
                                onselectedindexchanged="lstUbicacion_SelectedIndexChanged" >
                            <asp:ListItem>Plataforma</asp:ListItem>
                            <asp:ListItem>Chatarra</asp:ListItem>
                            <asp:ListItem>Bodega</asp:ListItem>
                            <asp:ListItem>Vehiculo</asp:ListItem>
                            <asp:ListItem>Cliente</asp:ListItem>
                        </asp:ListBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="lstTamano" runat="server" AutoPostBack="True" Rows="1" >
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>80</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:ListBox>
                    </p>
                        <p>
                        <asp:Label ID="lblTotal" runat="server" text="codigo total" Width="30%" ></asp:Label>
                            &nbsp;<asp:Label ID="lblregistro" runat="server" Text="Fecha Registro:"></asp:Label>
                 </p>
                 <p>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtRegistro" runat="server" CssClass="textEntry" Enabled="false" Width="80px"></asp:TextBox>
                        </p>
                        <div id="divInfoCliente" runat="server" visible="false">
                        <div class="post" >
                            <asp:Label ID="lblPost" runat="server" Text="Información Ubicación Cilindro" ></asp:Label>
                        </div>
                    <p>
                        <asp:Label ID="lblCedula" runat="server" Text="N° de Cédula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedula" text="23456742" runat="server" CssClass="textEntry" 
                           ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="La cédula del cliente es obligatorio." ToolTip="La cédula del cliente es obligatorio." 
                             ValidationGroup="ModificacionCilindrosValidationGroup">*</asp:RequiredFieldValidator>
                       
                        </p>
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" 
                            AssociatedControlID="txtNombreCliente" >Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" Enabled="false" CssClass="textEntry" 
                            Width="197px"></asp:TextBox>
                            
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                         <asp:Label ID="lblSegundoApellido" runat="server" Text="Segundo Apellido:" ></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" enabled="false" Width="197px" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" Enabled="false" CssClass="textEntry" Width="197px" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTipoDireccion" runat="server" Text="Tipo de Dirección:" ></asp:Label>
                        &nbsp;</p> 
                   
                      <p>
                          <asp:ListBox ID="lstDireccion" runat="server" Rows="1">
                              <asp:ListItem>Calle 3 N° 2 - 49</asp:ListItem>
                          </asp:ListBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
                          <asp:TextBox ID="txtBarrio" runat="server" CssClass="textEntry" enabled="false" Width="197px" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:TextBox ID="txtTipoDireccion" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                    </p> 

                    <p> 
                    <asp:Label ID="lblDepartamento" runat="server" text="Departamento:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="CiudadLabel" runat="server" >Ciudad:</asp:Label></p>
                    <p>
                        <asp:TextBox ID="txtDepartamento" runat="server" enabled="false" CssClass="textEntry"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtCiudad" runat="server" enabled="false" CssClass="textEntry"></asp:TextBox>
                        </p>  
                    
                     <p> 
                        <asp:Label ID="lblTipoTelefono" runat="server" Text="Tipo de Teléfono: " ></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="lblTelefono" runat="server" Text="Telefono:" ></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                        <asp:Label ID="lblEntrega" runat="server" Text="Fecha de Entrega: " ></asp:Label>
                    </p>
                        <p>
                            <asp:TextBox ID="txtTipoTelefono" CssClass="textEntry" runat="server" Enabled="false"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Enabled="false" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
                    <asp:TextBox ID="txtEntrega" runat="server" CssClass="textEntry" Enabled="false" ></asp:TextBox>
                    </p>
                    <p>
                    
                        <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label><br />
                        <asp:TextBox ID="txtObservaciones" runat="server" Height="75px" Width="373px"></asp:TextBox>
                        

                    
                    </p>
                    </div>
                    </div>  
                    
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardarDatos" runat="server" Text="Guardar" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
               </p>
            </div>
</asp:Content>
