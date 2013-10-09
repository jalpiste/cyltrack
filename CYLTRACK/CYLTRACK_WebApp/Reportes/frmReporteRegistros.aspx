<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReporteRegistros.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Reporte.frmReporteRegistros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

 <h1 style="margin-top: 75px">
        Reporte de Registros
    </h1>
    <br />
    
    <asp:ValidationSummary ID="ReporteValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="ReporteValidationGroup" Width="385px" />

    <div style="width: 450px">
        Seleccione a continuación el ítem del que desea generar el reporte de registros.
    </div>
     <div id="DivRegistros" runat="server">
        
        <asp:RadioButtonList ID="rblstRegistros" runat="server" Width="205px">  
        <asp:ListItem>Cilindros</asp:ListItem>
        <asp:ListItem>Clientes</asp:ListItem>
        <asp:ListItem>Pedidos</asp:ListItem>
        <asp:ListItem>Rutas</asp:ListItem>
        <asp:ListItem>Usuarios</asp:ListItem>
        <asp:ListItem>Vehículos</asp:ListItem>
        <asp:ListItem>Ventas</asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
   <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <br />
            
            <label>
            Fecha Desde<span class="requerido" style="color: Red"> *</span></label>
        <asp:TextBox ID="txtFechaDesde" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
        <asp:ImageButton runat="Server" ID="imgFecha" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
        <asp:MaskedEditExtender runat="server" ID="MEEtxtFecha" TargetControlID="txtFechaDesde"
            Mask="99/99/9999" MaskType="Date">
        </asp:MaskedEditExtender>
        <asp:CalendarExtender ID="calrExtFecha" runat="server" TargetControlID="txtFechaDesde"
            PopupButtonID="imgFecha" Format="dd/MM/yyyy" />
    
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <label>
            Fecha Hasta<span class="requerido" style="color: Red"> *</span></label>
        <asp:TextBox ID="txtFechaHasta" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
        <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
        <asp:MaskedEditExtender runat="server" ID="MaskedEditExtender1" TargetControlID="txtFechaHasta"
            Mask="99/99/9999" MaskType="Date">
        </asp:MaskedEditExtender>
        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaHasta"
            PopupButtonID="imgFecha" Format="dd/MM/yyyy" />
    
            <br />
            <br />
            <div id="divSeleccion" runat="server" visible="false">
            <asp:Label ID="lblPlacaVehiculo" runat="server" Text="Placa Vehículo: "></asp:Label>            
            <asp:ListBox ID="lstPlaca" runat="server" AutoPostBack="True" Rows="1">
                <asp:ListItem>Seleccionar</asp:ListItem>
                </asp:ListBox>
            <br />
            <br />
            <asp:Label ID="lblCedulaConductor" runat="server" Text="Cédula Conductor: "></asp:Label>
            &nbsp;<asp:TextBox ID="txtCedulaConductor" runat="server" CssClass="textEntry" Width="197px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="CedulaConductorRequired" runat="server" ControlToValidate="txtCedulaConductor" 
                             CssClass="failureNotification" ErrorMessage="La cedula del conductor es obligatorio." ToolTip="La cedula del conductor es obligatorio." 
                             ValidationGroup="ReporteValidationGroup">*</asp:RequiredFieldValidator>
                             </div>
       </fieldset>
        <p class="submitButton">
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" 
                onclick="btnBuscar_Click" />
        </p>
        <div id= "DivReporte" runat = "server" class="InfoInventarios" visible="false">
       <fieldset class ="login">
            <legend>Reporte</legend>
            <asp:Label ID="lblfecha" runat="server" Text="Fecha:   "></asp:Label>
            <asp:Label ID="lblImpresionFecha" runat="server" ></asp:Label>
            <br />
            <br />
                      
                <asp:GridView ID="gvRegistro" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" Visible="false"> 
                              
                    <AlternatingRowStyle BackColor="White"  />
                    <Columns>
                        <asp:BoundField SortExpression="TamanoCil" DataField="TamanoCil" HeaderText="Tamaño Cilindro"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="CantidadPedido" DataField="CantidadPedido" HeaderText="Cantidad"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
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
           

            </div> 
        </fieldset>
        </div> 
         <div class="submitButton" id="divBotones" runat="server" visible="false">
        <p class="submitButton">
            <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                onclick="btnMenu_Click" />
        </p>
        </div>
    </div>
</asp:Content>
