<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="frmConsultarCilindro.aspx.cs" Inherits="CYLTRACK_WebApp.Account.frmConsultarCilindro" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h1>
        </h1>
        <p>
        Los campos marcados con asterisco (*) son obligatorios
        </p>
            <asp:ValidationSummary ID="ConsultaCilindroValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ConsultaCilindroValidationGroup"/>
            <div class="accountInfo">
             <fieldset class="login">

                    <legend>Consulta de Cilindros</legend>
                                   <p>
                        <asp:Label ID="lblCodigoCilindro" runat="server" AssociatedControlID="txtCodigoCilindro">Código Cilindro:</asp:Label><br />
                        <asp:TextBox ID="txtCodigoCilindro" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCodigoCilindro_TextChanged"  ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtCodigoCilindroRequired" runat="server" ControlToValidate="txtCodigoCilindro" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="ConsultaCilindroValidationGroup"> * </asp:RequiredFieldValidator>
                                     
                        </p>
                    <div id="DivDatosCilindro" runat="server" visible="false">
                     <div class="post" >
                          <asp:Label ID="LblPoster" runat="server" Text="Datos Cilindro"></asp:Label>
                      </div> 
                     <p>
                         <asp:Label ID="LblAno" runat="server" Text="Año Fabricación:" ></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="LblEmpresa" runat="server" Text="Código Empresa:" ></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="LblCodigo" runat="server" Text="Código Cilindro:" ></asp:Label>
                    </p>
                    <p>
                         <asp:TextBox ID="TxtAno" runat="server" CssClass="textEntry" Enabled="false" Width="80px"></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:TextBox ID="TxtEmpresa" runat="server" Width="80px" CssClass="textEntry" 
                             Enabled="False" ></asp:TextBox>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        
                         &nbsp;
                         <asp:TextBox ID="TxtCodigo" runat="server" Width="80px" CssClass="textEntry" Enabled="False" 
                            ></asp:TextBox>
                    </p>
                    <p> 
                        <asp:Label ID="LblUbicacion" runat="server" Text="Ubicación: " ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        </p>
                        <p>
                            <asp:TextBox ID="TxtUbicacion" runat="server" CssClass="textEntry" Width="80px" 
                                text="Cliente" Enabled="False"
                                ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TxtTamano" runat="server" CssClass="textEntry" Width="80px" 
                                Enabled="False"></asp:TextBox>
                    </p>
                        <p>
                        <asp:Label ID="LblTotal" runat="server" text="codigo total" Width="30%" ></asp:Label>
                            &nbsp;&nbsp;<asp:Label ID="lblregistro" runat="server" Text="Fecha Registro:"></asp:Label>
                 </p>
                 <p>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:TextBox ID="TxtRegistro" runat="server" CssClass="textEntry" Enabled="false" Width="80px"></asp:TextBox>
                        </p>
                        
                        <div class="post" >
                            <asp:Label ID="LblPost" runat="server" Text="Información Ubicación Cilindro" ></asp:Label>
                        </div>
                    <p>
                        <asp:Label ID="LblNombreCliente" runat="server" 
                            AssociatedControlID="TxtNombreCliente" >Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="TxtNombreCliente" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="false"></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="LblPrimerApellido" runat="server" text="Primer Apellido:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                         <asp:Label ID="LblSegundoApellido" runat="server" Text="Segundo Apellido:" ></asp:Label>
                    </p>
                        <p>
                        <asp:TextBox ID="TxtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="TxtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                    </p> 
                    <p>
                        <asp:Label ID="LblDireccion" runat="server" Text="Dirección:  " ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                        &nbsp;
                        <asp:Label ID="LblBarrio" runat="server" Text="Barrio:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="LblTipoDireccion" runat="server" Text="Tipo de Dirección:" ></asp:Label>
                        &nbsp;</p> 
                   
                      <p>
                        <asp:TextBox ID="TxtDireccion" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; 
                          <asp:TextBox ID="TxtBarrio" runat="server" CssClass="textEntry" Width="197px" Enabled="false"></asp:TextBox>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                          <asp:TextBox ID="TxtTipoDireccion" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                    </p> 
                    <p><asp:Label ID="LblCiudad" runat="server" >Ciudad:</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="LblDepartamento" runat="server" text="Departamento:" ></asp:Label></p>
                    <p><asp:TextBox ID="TxtCiudad" runat="server" CssClass="textEntry"  Width="197px" Enabled="false" ></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                           <asp:TextBox ID="TxtDepartamento" runat="server" CssClass="textEntry" Width="197px" Enabled="false"></asp:TextBox>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </p>  
                    
                     <p> 
                        <asp:Label ID="LblTipoTelefono" runat="server" Text="Tipo de Teléfono: " ></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="LblTelefono" runat="server" Text="Telefono:" ></asp:Label>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                    
                        <asp:Label ID="LblEntrega" runat="server" Text="Fecha de Entrega: " ></asp:Label>
                    </p>
                        <p>
                            <asp:TextBox ID="TxtTipoTelefono" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            &nbsp;
                            <asp:TextBox ID="TxtTelefono" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   
                    <asp:TextBox ID="Txtentrega" runat="server" CssClass="textEntry" Enabled="false"></asp:TextBox>
                    </p>
                  
                    </div>  
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="BtnNuevaConsulta" runat="server" Text="Nueva Consulta" 
                       /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="BtnMenuPrincipal" runat="server" Text="Menú Principal" />  
                   
               </p>
            </div>
</asp:Content>
