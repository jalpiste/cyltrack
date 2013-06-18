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
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Registro de Cilindros</legend>
                                   <p>
                        <asp:Label ID="LblCodigoCilindro" runat="server" AssociatedControlID="TxtCodigoCilindro">Código Cilindro:</asp:Label><br />
                        <asp:TextBox ID="TxtCodigoCilindro" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="TxtCodigoCilindro_TextChanged"  ></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:RequiredFieldValidator ID="TxtCodigoCilindroRequired" runat="server" ControlToValidate="TxtCodigoCilindro" 
                             CssClass="failureNotification" ErrorMessage="El codigo del cilindro es obligatorio." ToolTip="El Codigo del Cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                                       &nbsp;&nbsp;&nbsp;&nbsp;
                        </p>
                    <div id="DivDatosCilindro" runat="server" visible="false">
                     <div class="post" >
                         <asp:Label ID="LblPoster" runat="server" Text="Datos del Cilindro" ></asp:Label>
                       </div>
                    <p>
                         <asp:Label ID="LblAno" runat="server" Text="Año Fabricación:" ></asp:Label>
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Label ID="LblEmpresa" runat="server" Text="Código Empresa:" ></asp:Label>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           <asp:Label ID="LblCodigo" runat="server" Text="Identificador Cilindro:" ></asp:Label>
                    </p>
                    <p>
                         <asp:ListBox ID="LstAno" runat="server" AutoPostBack="True" Rows="1" >
                             <asp:ListItem>1990</asp:ListItem>
                             <asp:ListItem>1991</asp:ListItem>
                             <asp:ListItem>1992</asp:ListItem>
                             <asp:ListItem>1993</asp:ListItem>
                             <asp:ListItem></asp:ListItem>
                             </asp:ListBox>
                             <asp:RequiredFieldValidator ID="ValidAno" runat="server" ControlToValidate="LstAno" 
                             CssClass="failureNotification" ErrorMessage="El año de fabricación es obligatorio." ToolTip="El año de fabricacion es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:TextBox ID="TxtEmpresa" runat="server" Width="80px" CssClass="textEntry"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="validEmpresa" runat="server" ControlToValidate="TxtEmpresa" 
                             CssClass="failureNotification" ErrorMessage="El código de la empresa es obligatorio." ToolTip="El código de la empresa es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        
                    &nbsp;&nbsp;
                         <asp:TextBox ID="TxtCodigo" runat="server" Width="80px" CssClass="textEntry" ></asp:TextBox>
                           <asp:RequiredFieldValidator ID="validCodigo" runat="server" ControlToValidate="TxtCodigo" 
                             CssClass="failureNotification" ErrorMessage="El nuip del cilindro es obligatorio." ToolTip="El nuip del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                    </p>
                    <p> 
                        <asp:Label ID="LblUbicacion" runat="server" Text="Ubicación: " ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LblTamano" runat="server" Text="Tamaño: " ></asp:Label>
                        </p>
                        <p>
                        <asp:ListBox ID="LstUbicacion" runat="server" AutoPostBack="True" Rows="1" >
                            <asp:ListItem>Plataforma</asp:ListItem>
                            <asp:ListItem>Chatarra</asp:ListItem>
                            <asp:ListItem>Bodega</asp:ListItem>
                            <asp:ListItem>Vehiculo</asp:ListItem>
                        </asp:ListBox>
                           <asp:RequiredFieldValidator ID="validUbicacion" runat="server" ControlToValidate="LstUbicacion" 
                             CssClass="failureNotification" ErrorMessage="La ubicacion del cilindro es obligatorio." ToolTip="La ubicacion del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="LstTamano" runat="server" AutoPostBack="True" Rows="1" >
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>80</asp:ListItem>
                            <asp:ListItem>100</asp:ListItem>
                        </asp:ListBox>
                            <asp:RequiredFieldValidator ID="validTamano" runat="server" ControlToValidate="LstTamano" 
                             CssClass="failureNotification" ErrorMessage="El tamaño del cilindro es obligatorio." ToolTip="El tamaño del cilindro es obligatorio." 
                             ValidationGroup="RegistrodeCilindro">*</asp:RequiredFieldValidator>
                    </p>
                        <p>
                        <asp:Label ID="Lbltotal" runat="server" text="codigo total" Width="30%" ></asp:Label>
                </p>
                </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar"  Width="115px"
                       /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" visible="false" Width="115px"
                        onclick="BtnGuardar_Click" ValidationGroup="RegistrodeCilindro"  />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="BtnMenu" runat="server" Text="Menú Principal" 
                        onclick="BtnMenu_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
               </p>
            </div>
</asp:Content>
