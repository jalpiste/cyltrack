<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAsignarUbicacion.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros.frmAsignarUbicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 837px; margin-right: 45px;">
       <h1> 
        Asignación de Ubicación de Cilindros
       </h1>
       <span class="failureNotification">
       <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>       
      
       <asp:ValidationSummary ID="LoginValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="LoginValidationGroup" Width="385px"/>
       <div class="accountInfo"> 
       <fieldset class="login">
       <legend>Asignación de Ubicación</legend>
       <div id="DivCodigo" runat="server" visible="true">
           <asp:Label ID="lblCodeCil" runat="server" Text="Código Cilindro:"></asp:Label>
           <br /> 
           <asp:TextBox ID="txtCodeCilindro" runat="server" CssClass="textEntry" Width="197px" ontextchanged="txtCodeCilindro_TextChanged" 
           ValidationGroup = "LoginValidationGroup"></asp:TextBox>
           <asp:RequiredFieldValidator ID="CodeCilindroRequired" runat="server" 
           ControlToValidate="txtCodeCilindro" CssClass="failureNotification" 
           ErrorMessage="El código del cilindro es obligatorio." ToolTip="El Código del Cilindro es obligatorio." 
           ValidationGroup="LoginValidationGroup" Display="Static" Font-Size="Small"></asp:RequiredFieldValidator>          
            <asp:RegularExpressionValidator ID="ValidarDatosCilindro" runat="server" ControlToValidate="txtCodeCilindro" 
             CssClass="failureNotification" ErrorMessage="El código del cilindro debe contener entre 11 y 12 dígitos." 
             ValidationExpression="^([\d]{11,12})$"  Font-Size = "Small" Display ="Static"
             ValidationGroup="RegistrodeCilindro" ></asp:RegularExpressionValidator>
       
            </div> 
                  <div id="DivUbicacionCil" runat="server" visible="false">
                  <div class="post" >
                      <asp:Label ID="lblPost" runat="server" Text="Información Ubicación Cilindro"></asp:Label>
                      </div> 
                   <asp:Label ID="lblCodigo" runat="server" Text="Código Cilindro:"></asp:Label>
           <br /> 
           <asp:TextBox ID="txtCodigo" runat="server" CssClass="textEntry" Width="197px" Enabled="false" ontextchanged="txtCodeCilindro_TextChanged" 
           ValidationGroup = "LoginValidationGroup"></asp:TextBox>
           <br />
           <br />
                        <asp:Label ID="lblUbicacionActual" runat="server" Text="Ubicación Actual:  " 
                            Enabled="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtUbicacionActual" runat="server" CssClass="textEntry" Enabled="False"></asp:TextBox>                       
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                      <asp:Label ID="lblPlacaActual" runat="server" Text="Placa: " Visible="false"></asp:Label>
&nbsp;&nbsp;&nbsp;                       
                        <asp:TextBox ID="txtPlacaActual" runat="server" CssClass="textEntry" Enabled="False" Visible="false"></asp:TextBox>
                        <br />
                    </div>
                    <br />
                    <div id = "DivNuevaUbicacion" runat ="server" visible ="False">
                        <asp:Label ID="lblUbicacion" runat="server" Text="Nueva Ubicación:  " 
                            Enabled="False"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ListBox ID="lstUbica" runat="server" AutoPostBack="true"  Rows="1" 
                            onselectedindexchanged="Ubica_SelectedIndexChanged">
                            <asp:ListItem>Seleccionar...</asp:ListItem>                            
                         </asp:ListBox>
                          
                        <div id="diVehiculo" runat="server" visible="false">
                        <br />
                        <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " ></asp:Label>
                        <asp:ListBox ID="lstPlacaVehiculo" runat="server" AutoPostBack="true" Rows="1" onselectedindexchanged="lstPlacaVehiculo_SelectedIndexChanged"  
                                >
                          <asp:ListItem>Seleccionar...</asp:ListItem>                            
                         </asp:ListBox>
                         <br /><br />
                         <div id = "DivConductor" runat ="server" visible ="False">
                        <asp:Label ID="LblConductor" runat="server" Text="Conductor Vehiculo:" ></asp:Label>

                        &nbsp;&nbsp;&nbsp;

                        <asp:TextBox ID="TxtConductor" runat="server" CssClass="textEntry" Enabled="false" 
                                Width="242px"></asp:TextBox>
                       
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       
                            <asp:Label ID="LblRuta" runat="server" Text="Ruta:" ></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="LblRutaVehiculo" runat="server" ></asp:Label>
                                    </div>
                        </div>
                        </div>
       </fieldset><p class="submitButton">
          
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" Width="140px" Visible="false" onclick="BtnGuardar_Click" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="BtnMenu" runat="server" Text="Menú Principal" Width="140px"     /> 
                    </p>
       </div>
  </div> 
</asp:Content>
