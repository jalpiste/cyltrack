<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReporteSiembras.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Reporte.frmReporteSiembras" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

    <h1 style="margin-top: 75px">
        Reporte de Siembras
    </h1>
    <br />
    <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="LoginUserValidationGroup" Width="385px" />
    
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Inicial: "></asp:Label>
            <asp:TextBox ID="txtFechaIni" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="imgFechaIni" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
            <asp:MaskedEditExtender runat="server" ID="MEEtxtFechaIni" TargetControlID="txtFechaIni"
            Mask="99/99/9999" MaskType="Date">
            </asp:MaskedEditExtender>
            <asp:CalendarExtender ID="calrExtFechaIni" runat="server" TargetControlID="txtFechaIni"
            PopupButtonID="imgFechaIni" Format="dd/MM/yyyy" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Final: "></asp:Label>
            <asp:TextBox ID="txtFechaFin" runat="server" Width="70px" MaxLength="10" 
                ontextchanged="txtFechaFin_TextChanged"></asp:TextBox>
            <asp:ImageButton runat="Server" ID="imgFechaFin" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
            <asp:MaskedEditExtender runat="server" ID="MEEtxtFechaFin" TargetControlID="txtFechaFin"
            Mask="99/99/9999" MaskType="Date">
            </asp:MaskedEditExtender>
            <asp:CalendarExtender ID="calrExtFechaFin" runat="server" TargetControlID="txtFechaFin"
            PopupButtonID="imgFechaFin" Format="dd/MM/yyyy" />
            
            <h3>
            <asp:Label ID="lblTipoRepSiembra" runat="server" Text="Reporte por: "></asp:Label>
            </h3>
            
        <asp:ListBox ID="lstReportes" runat="server" Width="176px" AutoPostBack="True" 
                Rows="1" onselectedindexchanged="lstReportes_SelectedIndexChanged" >
        <asp:ListItem>Seleccionar...</asp:ListItem>
        <asp:ListItem>Ciudad</asp:ListItem>
        <asp:ListItem>Tamaño Cilindro</asp:ListItem>
        <asp:ListItem>Vehículo</asp:ListItem>
        </asp:ListBox>
        <br />
        <br />
        <asp:Label ID="lblVehiculo" runat="server" Text="Placa: "></asp:Label>      
        <br />
        <asp:ListBox ID="lstPlaca" runat="server" Width="98px" AutoPostBack="True" 
                Rows="1" onselectedindexchanged="lstReportes_SelectedIndexChanged" 
                Height="17px" visible ="false">
        <asp:ListItem>Seleccionar...</asp:ListItem>
        <asp:ListItem>XHN322</asp:ListItem>
        <asp:ListItem>ADD455</asp:ListItem>
        <asp:ListItem>SWE215</asp:ListItem>
        </asp:ListBox>
        
        <br />
        <br />
        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: " visible ="false"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: " visible ="false"></asp:Label>
        <br />
        
        <asp:ListBox ID="lstDepto" runat="server" Width="176px" AutoPostBack="True" Rows="1" visible ="false">
        <asp:ListItem>Seleccionar...</asp:ListItem>
        </asp:ListBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lstCiudad" runat="server" Width="176px" AutoPostBack="True" Rows="1" visible ="false">
        <asp:ListItem>Seleccionar...</asp:ListItem>
        </asp:ListBox>
        
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" 
                onclick="btnBuscar_Click" />
        </p>
    </div>
    <div id= "DivReporte" runat = "server" class="InfoInventarios" visible ="false">
        <fieldset class="login">
            <legend>Reporte</legend>
            <div style="height: 1468px; width: 477px; margin-right: 4px;">
            <asp:Label ID="lblfecha" runat="server" Text="Fecha:   "></asp:Label>
            <asp:Label ID="lblImpresionFecha" runat="server" Text="xxxxxxxxx"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="gvReporteCiudad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="CiudadSiembra" DataField="CiudadSiembra" HeaderText="Ciudad"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil30" DataField="Cil30" HeaderText="Cil 30"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil40" DataField="Cil40" HeaderText="Cil 40"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil80" DataField="Cil80" HeaderText="Cil 80"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil100" DataField="Cil100" HeaderText="Cil 100"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Total" DataField="Total" HeaderText="Total Siembra"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                    </Columns>
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
                    <br />
           <%----------------------------------------------------%>
           <asp:GridView ID="gvReporteTamano" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="Tamano" DataField="Tamano" HeaderText="Tamaño Cilindro"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cantidad" DataField="Cantidad" HeaderText="Cantidad"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                    </Columns>
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



                <rsweb:ReportViewer ID="ReportViewer1" runat="server" 
                    style="margin-right: 94px" ProcessingMode="Remote">
                </rsweb:ReportViewer>
            </div>
              <div class="submitButton" id="divBotones" runat="server" visible="false">
        <p class="submitButton">
            <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                onclick="btnMenu_Click" />
                </p>
        </div>
    </fieldset>
    </div>
</asp:Content>
