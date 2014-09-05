<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmRegistrarCilindro.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros.frmRegistrarCilindro" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Registrar Cilindro
    </h1>
     <span class="failureNotification">
       <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span> 
            <asp:ValidationSummary ID="RegistrarCilindro" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrodeCilindro" />
                 <asp:ValidationSummary ID="validarPlaca" runat="server" CssClass="failureNotification" 
                 ValidationGroup="validarPlaca" />
                             <asp:ValidationSummary ID="validarCodigo" runat="server" CssClass="failureNotification" 
                 ValidationGroup="validarCodigo" />
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Cilindros</legend>
                                   <p>
                        <asp:Label ID="lblCodigoCilindro" runat="server" AssociatedControlID="txtCodigoCilindro">Código Cilindro:</asp:Label><br />
                        <asp:TextBox ID="txtCodigoCilindro" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCodigoCilindro_TextChanged"  ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="txtCodigoCilindroRequired" runat="server" ControlToValidate="txtCodigoCilindro" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="validarCodigo">*</asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="ValidarDatosCilindro" runat="server" ControlToValidate="txtCodigoCilindro" 
                            CssClass="failureNotification" ErrorMessage="El código del cilindro debe contener 12 dígitos." 
                            ValidationExpression="^([\d]{12})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="validarCodigo" ></asp:RegularExpressionValidator>
                                       &nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <div id="DivDatosCilindro" runat="server" visible="false">
                     <div class="post" >
                         <asp:Label ID="lblPoster" runat="server" Text="Datos del Cilindro" ></asp:Label>
                       </div>
                    
                    <p>
                    <asp:Label ID="lblCil" runat="server" AssociatedControlID="txtCodigoCilindro">Código Cilindro:</asp:Label><br />
                    <asp:TextBox ID="txtCil" runat="server" CssClass="textEntry" 
                            Width="197px" Enabled="false"  ></asp:TextBox>
                    </p><p>
                         <asp:Label ID="lblAno" runat="server" Text="Año Fabricación:" ></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="lblEmpresa" runat="server" Text="Código Empresa:" ></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="lblCodigo" runat="server" Text="Identificador Cilindro:" ></asp:Label>
                    </p>
                    <p>
                         
                             
                             <asp:TextBox ID="txtAno" runat="server" Width="80px" CssClass="textEntry" Enabled="false"></asp:TextBox>
                         
                             
                             <asp:RequiredFieldValidator ID="ValidAno" runat="server" ControlToValidate="txtAno" 
                             CssClass="failureNotification" ErrorMessage="El año de fabricación es obligatorio." ToolTip="El año de fabricacion es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:TextBox ID="txtEmpresa" runat="server" Width="80px" CssClass="textEntry" Enabled="false"
                             ontextchanged="txtEmpresa_TextChanged"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="validEmpresa" runat="server" ControlToValidate="txtEmpresa" 
                             CssClass="failureNotification" ErrorMessage="El código de la empresa es obligatorio." ToolTip="El código de la empresa es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="validarDatosEmpresa" runat="server" ControlToValidate="txtEmpresa" 
                            CssClass="failureNotification" ErrorMessage="El código de la empresa debe contener entre 3 a 4 digitos." 
                            ValidationExpression="^([\d]{3,4})$"  Font-Size = "Small" ValidationGroup="RegistrodeCilindro">*</asp:RegularExpressionValidator>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                         <asp:TextBox ID="txtCodigo" runat="server" Width="80px" CssClass="textEntry" Enabled="false" ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="validSerial" runat="server" ControlToValidate="txtCodigo" 
                             CssClass="failureNotification" ErrorMessage="El nuip del cilindro es obligatorio." ToolTip="El nuip del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="ValidarSerialCil" runat="server" ControlToValidate="txtCodigo" 
                            CssClass="failureNotification" ErrorMessage="El identificador del cilindro debe contener entre 6 y 8 dígitos." 
                            ValidationExpression="^([\d]{6,8})$"  Font-Size = "Small" 
                            ValidationGroup="RegistrodeCilindro">*</asp:RegularExpressionValidator>
                    </p>
                    <p> 
                        <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación: " ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPlaca" runat="server" Text="Placa:" Width="30%" Visible = "false" ></asp:Label>
                        </p>
                        <p>
                        <asp:ListBox ID="lstUbicacion" runat="server" Rows="1" 
                          AutoPostBack="True"      onselectedindexchanged="lstUbicacion_SelectedIndexChanged1" >
                            <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                           <asp:RequiredFieldValidator ID="validUbicacion" runat="server" ControlToValidate="lstUbicacion" 
                             CssClass="failureNotification" ErrorMessage="La ubicacion del cilindro es obligatorio." ToolTip="La ubicacion del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                        
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ListBox ID="lstTamano" runat="server" AutoPostBack="True" Rows="1" >
                            <asp:ListItem>Seleccionar...</asp:ListItem>
                        </asp:ListBox>
                            <asp:RequiredFieldValidator ID="validTamano" runat="server" ControlToValidate="lstTamano" 
                             CssClass="failureNotification" ErrorMessage="El tamaño del cilindro es obligatorio." ToolTip="El tamaño del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ListBox ID="lstPlacas" runat="server" AutoPostBack="True" Rows="1" Visible = "false"  >
                             </asp:ListBox>
                        <asp:RequiredFieldValidator ID="validPlaca" runat="server" ControlToValidate="lstPlacas" 
                             CssClass="failureNotification" ErrorMessage="La placa del vehículo es obligatorio." ToolTip="La placa del vehículo es obligatorio." 
                             ValidationGroup="validarPlaca">*</asp:RequiredFieldValidator>
                    </p>
                        
                </div>
                </fieldset>
                <p class="submitButton">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" visible="false" Width="115px"
                        onclick="btnGuardar_Click" ValidationGroup="RegistrodeCilindro"  />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Visible="false" 
                        onclick="btnMenu_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
               </p>
            </div>
</asp:Content>
