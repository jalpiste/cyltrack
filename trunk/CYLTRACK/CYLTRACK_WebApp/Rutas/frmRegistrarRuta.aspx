<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarRuta.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Autenticacion.frmRegistrarRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Registrar Ruta
                </h1>
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="RegistrarRutaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarRutaValidationGroup"/>

                 <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Registro de Ruta</legend>
                     <div id="DivNomRuta" runat="server" >
                     <asp:Label ID="lblNombreRuta" runat="server" Text="Nombre de Ruta: "></asp:Label>           
                     <br />
                     <asp:TextBox ID="txtNombreRuta" runat="server" CssClass="textEntry" Width="197px" 
                             ontextchanged="txtNombreRuta_TextChanged"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegistrarRutaRequired" runat="server" 
                     ControlToValidate="txtNombreRuta" CssClass="failureNotification" 
                     ErrorMessage="El nombre de la ruta es obligatorio." ToolTip="El nombre de la ruta es obligatorio." 
                     ValidationGroup="RegistrarRutaValidationGroup"> * </asp:RequiredFieldValidator>
                     </div>
                    <div id="DivSelCiudades" runat="server" visible ="false">
                    <h3>
                    Seleccione la(s) ciudad(es) que hace(n) parte de la ruta.
                    </h3>
                    <br />
                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: "></asp:Label>                                   
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
                    <br />                
                    <asp:ListBox ID="lstDepartamento" runat="server" AutoPostBack="True" Rows="1" Width="170px"> 
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:ListBox>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ListBox ID="lstCiudad" runat="server" AutoPostBack="True" Rows="1" Width="170px"> 
                    <asp:ListItem>Seleccionar</asp:ListItem>
                    <asp:ListItem>Cali</asp:ListItem>
                    <asp:ListItem>Chiquinquirá</asp:ListItem>
                    </asp:ListBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="115px" 
                         onclick="btnAgregar_Click"/>
                         
                    <br />
                    <br />
                     <asp:ListBox ID="lstAgregar" runat="server" Height="55px" Width="120px" 
                         visible ="false"></asp:ListBox> 
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                         <asp:Button ID="btnRemover" runat="server" Text="Remover" Width="115px" 
                           onclick="btnRemover_Click"/>    
                    </div> 
                   
                 </fieldset>
                 <p class="submitButton">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Visible="false" Width="115px"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                    onclick="btnMenu_Click"/>  
               </p>
                 </div>
</asp:Content>
