<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarRuta.aspx.cs" Inherits="CYLTRACK_WebApp.Rutas.frmModificarRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Modificar Ruta
                </h1>
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="ModificarRutaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ModificarRutaValidationGroup"/>

                 <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Modificar Ruta</legend>
                    <div id="DivModRuta" runat="server">
                     <asp:Label ID="lblNombreRuta" runat="server" Text="Nombre de Ruta: "></asp:Label>           
                     <br />
                     <asp:TextBox ID="txtNombreRuta" runat="server" CssClass="textEntry" Width="197px" 
                            ontextchanged="txtNombreRuta_TextChanged"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RegistrarRutaRequired" runat="server" 
                     ControlToValidate="txtNombreRuta" CssClass="failureNotification" 
                     ErrorMessage="El nombre de la ruta es obligatorio." ToolTip="El nombre de la ruta es obligatorio." 
                     ValidationGroup="ModificarRutaValidationGroup"> * </asp:RequiredFieldValidator>
                     </div>
                     <br />
                     <div id= "DivPost" runat = "server" class="post" visible ="false" >
                          <asp:Label ID="lblPost" runat="server" Text="Información de Ruta"></asp:Label>
                      </div> 
                    <div id="DivDatos" runat ="server"  visible ="false" >
                        <asp:Label ID="lblNuevoNombre" runat="server" Text="Nombre: "></asp:Label>               
                        <br />
                        <asp:TextBox ID="txtNuevoNombre" runat="server" CssClass="textEntry" Width="197px"
                        Enabled ="false" ></asp:TextBox>
                      </div>  
                    
                    <div id="DivModificarDatos" runat ="server" visible ="false" >
                    <h3>
                    Seleccione la(s) ciudad(es) que hace(n) parte de la ruta.
                    </h3>
                    <br />
                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: "></asp:Label>                                   
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
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
                   <h4>
                    "Si desea remover una ciudad del listado, selecciónela y a continuación haga click en Remover."
                    </h4>       
                   </div>
                   <br /> 
                   <div id="DivCiudad" runat ="server" visible ="false" >
                   
                     <asp:Label ID="lblCiudades" runat="server" Text="Ciudades: " ></asp:Label><br />
                     <asp:ListBox ID="lstCiudades" runat="server" Height="55px" Width="120px" enabled="false"></asp:ListBox>    
                     
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="115px" 
                            onclick="btnModificar_Click"/>    
                     <asp:Button ID="btnRemover" runat="server" Text="Remover" Width="115px" 
                           Visible ="false" onclick="btnRemover_Click"/>                              
                    </div>
                </fieldset> 
                <p class="submitButton">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="115px"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="115px" 
                    onclick="btnCancelar_Click"/>  
               </p>
                </div>
                    
</asp:Content>
