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
    <asp:ValidationSummary ID="ValidadorBuscar" runat="server" CssClass="failureNotification"
        ValidationGroup="ValidarBusqueda" Width="385px" />
    
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <asp:Label ID="lblFechaDesde" runat="server" Text="Fecha Inicial: "></asp:Label>
            <asp:TextBox ID="txtFechaIni" runat="server" Width="70px" MaxLength="10"  ></asp:TextBox>
            <asp:ImageButton runat="Server" ID="imgFechaIni" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
            <asp:MaskedEditExtender runat="server" ID="MEEtxtFechaIni" TargetControlID="txtFechaIni"
            Mask="99/99/9999" MaskType="Date">
                
</asp:MaskedEditExtender>
<asp:RequiredFieldValidator ID="RequeridoFecha" runat="server" ControlToValidate="txtFechaIni" 
                             CssClass="failureNotification" ErrorMessage="La fecha inicial es obligatoria" ToolTip="La fecha inicial es obligatoria" 
                             ValidationGroup="ValidarBusqueda">*</asp:RequiredFieldValidator>
        
            <asp:CalendarExtender ID="calrExtFechaIni" runat="server" TargetControlID="txtFechaIni"
            PopupButtonID="imgFechaIni" Format="dd/MM/yyyy" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            
            <asp:Label ID="lblFechaHasta" runat="server" Text="Fecha Final: "></asp:Label>
            <asp:TextBox ID="txtFechaFin" runat="server" Width="70px" MaxLength="10" 
                ontextchanged="txtFechaFin_TextChanged" ></asp:TextBox>
            <asp:ImageButton runat="Server" ID="imgFechaFin" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
            <asp:MaskedEditExtender runat="server" ID="MEEtxtFechaFin" TargetControlID="txtFechaFin"
            Mask="99/99/9999" MaskType="Date">
                
 </asp:MaskedEditExtender>
            <asp:CalendarExtender ID="calrExtFechaFin" runat="server" TargetControlID="txtFechaFin"
            PopupButtonID="imgFechaFin" Format="dd/MM/yyyy" />
<asp:RequiredFieldValidator ID="RequeridoFechaFinal" runat="server" ControlToValidate="txtFechaFin" 
                             CssClass="failureNotification" ErrorMessage="La fecha final es obligatoria" ToolTip="La fecha final es obligatoria" 
                             ValidationGroup="ValidarBusqueda">*</asp:RequiredFieldValidator>
        
            
            <h3>
            <asp:Label ID="lblTipoRepSiembra" runat="server" Text="Reporte por: "></asp:Label>
            </h3>
            
        <asp:ListBox ID="lstReportes" runat="server" Width="176px" AutoPostBack="True" 
                Rows="1" onselectedindexchanged="lstReportes_SelectedIndexChanged" ValidationGroup="ValidarBusqueda" >
        <asp:ListItem>Seleccionar...</asp:ListItem>
        </asp:ListBox>
         <asp:RequiredFieldValidator ID="requeridolstReportes" runat="server" ControlToValidate="lstReportes" 
                             CssClass="failureNotification" ErrorMessage="El tipo de reporte es obligatorio" ToolTip="El tipo de reporte es obligatorio" 
                             ValidationGroup="ValidarBusqueda">*</asp:RequiredFieldValidator>
        <br />
        
       
        
        <div id="divCiudad" runat="server" visible="false">
        <asp:Label ID="lblDepartamento" runat="server" Text="Departamento: " ></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCiudad" runat="server" Text="Ciudad: " ></asp:Label>
        <br />
        
        <asp:ListBox ID="lstDepto" runat="server" Width="176px" AutoPostBack="True" 
                Rows="1" onselectedindexchanged="lstDepto_SelectedIndexChanged" >
        <asp:ListItem>Seleccionar...</asp:ListItem>
        </asp:ListBox>
                 <asp:RequiredFieldValidator ID="RequiridoDepartamento" runat="server" ControlToValidate="lstDepto" 
                             CssClass="failureNotification" ErrorMessage="El departamento es obligatorio" ToolTip="El departamento es obligatorio" 
                             ValidationGroup="ValidarBusqueda">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:ListBox ID="lstCiudad" runat="server" Width="176px" AutoPostBack="True" Rows="1" >
        <asp:ListItem>Seleccionar...</asp:ListItem>
        </asp:ListBox>
        <asp:RequiredFieldValidator ID="RequiredCiudad" runat="server" ControlToValidate="lstCiudad" 
                             CssClass="failureNotification" ErrorMessage="La ciudad es obligatoria" ToolTip="La ciudad es obligatoria" 
                             ValidationGroup="ValidarBusqueda">*</asp:RequiredFieldValidator>
        
        </div>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" 
                onclick="btnBuscar_Click" ValidationGroup="ValidarBusqueda"  />
        </p>
    </div>
    <div id= "DivReporte" runat = "server" class="accountInfo" visible ="false">
        <fieldset class="login">
            <legend>Reporte</legend>
            <br />
            <asp:GridView ID="gvReporteCiudad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="CiudadSiembra" DataField="CiudadSiembra" HeaderText="Ciudad"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil30" DataField="Cil30" HeaderText="Cilindro 30"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil40" DataField="Cil40" HeaderText="Cilindro 40"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil80" DataField="Cil80" HeaderText="Cilindro 80"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil100" DataField="Cil100" HeaderText="Cilindro 100"
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
            <br />
            <asp:GridView ID="gvReportePlacas" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="Placa" DataField="Placa" HeaderText="Placa"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamano" DataField="Tamano" HeaderText="Tamaño Cilindro"
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
           
           <%----------------------------------------------------%>
           <asp:GridView ID="gvReporteTamano" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="Cil30" DataField="Cil30" HeaderText="Cilindro 30"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil40" DataField="Cil40" HeaderText="Cilindro 40"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil80" DataField="Cil80" HeaderText="Cilindro 80"
                            HeaderStyle-Width="70px">
                            <HeaderStyle Width="70px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cil100" DataField="Cil100" HeaderText="Cilindro 100"
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
