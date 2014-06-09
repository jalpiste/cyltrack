<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrarRuta.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Rutas.frmRegistrarRuta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top:75px">
                     Registrar Ruta
                </h1>
                <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="validarNombreRuta" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ValidarRuta"/>
        <asp:ValidationSummary ID="RegistrarRuta" runat="server" CssClass="failureNotification" 
                 ValidationGroup="RegistrarRuta"/>
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
                     ValidationGroup="ValidarRuta" Font-Size="Small"></asp:RequiredFieldValidator>

                     <br />
                     <br />
                     <div id= "divRuta" runat="server" visible="false">
                     <asp:Label ID="lblNomRuta" runat="server" Text="Nombre de Ruta: "></asp:Label>           
                     <br />
                     <asp:TextBox ID="txtNomRuta" runat="server" CssClass="textEntry" Width="197px" 
                      Enabled="false" ></asp:TextBox>
                       <asp:RequiredFieldValidator ID="validarNombre" runat="server" 
                     ControlToValidate="txtNomRuta" CssClass="failureNotification" 
                     ErrorMessage="El nombre de la ruta es obligatorio." ToolTip="El nombre de la ruta es obligatorio." 
                     ValidationGroup="RegistrarRuta" Font-Size="Small"></asp:RequiredFieldValidator>

                      </div>
                     </div>
                    <div id="DivSelCiudades" runat="server" visible ="false">
                    <h3>
                    Seleccione la(s) ciudad(es) que hace(n) parte de la ruta.
                    </h3>
                    <br />
                    <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: "></asp:Label>                                   
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:Label ID="lblCiudad" runat="server" Text="Ciudad: "></asp:Label>
                    <br />                
                    <asp:ListBox ID="lstDepartamento" runat="server" AutoPostBack="True" Rows="1" 
                            Width="170px" 
                            onselectedindexchanged="lstDepartamento_SelectedIndexChanged" > 
                    </asp:ListBox>
                     <asp:RequiredFieldValidator ID="validadorDepart" runat="server" 
                     ControlToValidate="lstDepartamento" CssClass="failureNotification" 
                     ErrorMessage="El nombre del departamento es obligatorio." ToolTip="El nombre del departamento es obligatorio." 
                     ValidationGroup="RegistrarRuta" Font-Size="Small">*</asp:RequiredFieldValidator>

                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:ListBox ID="lstCiudad" runat="server" AutoPostBack="True" Rows="1" 
                            Width="170px" onselectedindexchanged="lstCiudad_SelectedIndexChanged" > 
                    </asp:ListBox>
                    <asp:RequiredFieldValidator ID="validadorCiudad" runat="server" 
                     ControlToValidate="lstCiudad" CssClass="failureNotification" 
                     ErrorMessage="El nombre de la ciudad es obligatorio." ToolTip="El nombre de la ciudad es obligatorio." 
                     ValidationGroup="RegistrarRuta" Font-Size="Small">*</asp:RequiredFieldValidator>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="115px" Visible="false"
                         onclick="btnAgregar_Click"/>
                         
                    <br />
                    <br />
                    <asp:GridView ID="gdAdd" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" AutoGenerateDeleteButton = "true" onrowdeleting="gdAdd_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="CiudadesAdd" DataField="CiudadesAdd" HeaderText="Ciudades Agregadas"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <%--<asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:Button ID="Remover" runat="server" Text="Remover" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("CiudadesAdd")%>' OnClick="btnRemover_Click"  />
                            </ItemTemplate>
                        </asp:TemplateField>
--%>                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                    </asp:GridView>  
                    </div> 
                   
                 </fieldset>
                 <p class="submitButton">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" 
                         Width="115px" onclick="btnGuardar_Click" ValidationGroup="RegistrarRuta"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                    onclick="btnMenu_Click"/>  
               </p>
                 </div>
</asp:Content>
