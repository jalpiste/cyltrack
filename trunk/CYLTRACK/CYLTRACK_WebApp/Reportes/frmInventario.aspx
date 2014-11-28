<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="frmInventario.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Inventario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <h1 style="margin-top: 75px">
        Reporte de Inventario de Cilindros
    </h1>
    <br />
    <div style="width: 381px">
        Seleccione un parámetro de búsqueda.
    </div>
    <span class="failureNotification">
        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
    </span>
 <asp:ValidationSummary ID="InventarioCilindros" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Inventario" />
    <div class="accountInfo">
        <fieldset class="login">
            <legend>Parámetros</legend>
            <span style="height: 20px; text-align: left">
        <label>
            Fecha CYLTRACK</label>
        <asp:TextBox ID="txtFecha" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="fechaRequerido" runat="server" ControlToValidate="txtFecha" 
                             CssClass="failureNotification" ErrorMessage="La fecha del reporte es obligatorio" ToolTip="La fecha del reporte es obligatorio" 
                             ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
        <asp:ImageButton runat="Server" ID="imgFecha" ImageUrl="~/Imagenes/Calendar_scheduleHS.png"
            AlternateText="Click para mostrar el calendario" Height="16px" />
        <asp:MaskedEditExtender runat="server" ID="MEEtxtFecha" TargetControlID="txtFecha"
            Mask="99/99/9999" MaskType="Date">
        </asp:MaskedEditExtender>
        <asp:CalendarExtender ID="calrExtFecha" runat="server" TargetControlID="txtFecha"
            PopupButtonID="imgFecha" Format="dd/MM/yyyy" />
    </span>
    <br />
    <br />
    <asp:Label ID="lblTipoCil" runat="server" Text="Tipo de Cilindro: "></asp:Label>
            &nbsp;&nbsp;
            <asp:ListBox ID="lstTipoCil" runat="server" AutoPostBack="True" Rows="1" >
               </asp:ListBox>
               <asp:RequiredFieldValidator ID="tipoCilRequerido" runat="server" ControlToValidate="lstTipoCil" 
               CssClass="failureNotification" ErrorMessage="El tipo de cilindro del reporte es obligatorio" ToolTip="El tipo de cilindro del reporte es obligatorio" 
               ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
               
            
                <br />
                <br />
                <asp:Label ID="lblNota" runat="server" Text="Ubicación: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="lstUbicacion" runat="server" AutoPostBack="True" Rows="1" 
                onselectedindexchanged="lstUbicacion_SelectedIndexChanged" >
                </asp:ListBox>
               <asp:RequiredFieldValidator ID="UbicacionRequerida" runat="server" ControlToValidate="lstUbicacion" 
               CssClass="failureNotification" ErrorMessage="La ubicación del reporte es obligatorio" ToolTip="La ubicación del reporte es obligatorio" 
               ValidationGroup="Inventario">*</asp:RequiredFieldValidator>
               <br />
            <br />
               
            <div id="divPlaca" runat="server" visible="false">
            <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo:  " Visible="true"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ListBox ID="lstPlacaVehículo" runat="server" AutoPostBack="True" Rows="1" Visible="true">
                </asp:ListBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstTipoCil" 
               CssClass="failureNotification" ErrorMessage="La placa del vehiculo es obligatorio" ToolTip="la placa del vehiculo es obligatorio" 
               ValidationGroup="Inventario">*</asp:RequiredFieldValidator>         
            </div>
        </fieldset>
        <p class="submitButton" >
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" OnClick="btnBuscar_Click" ValidationGroup="Inventario" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
        </p>
    </div>
     <div id="divInventario" runat="server" class="accountInfo" visible="false">
        <fieldset class="login">
            <legend>Inventario de Cilindros</legend>
           
               <asp:GridView ID="gvInventario" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="Both"  >
                    <AlternatingRowStyle BackColor="White"  />                    
                    <Columns>
                        <asp:BoundField SortExpression="Ubicacion" HeaderStyle-VerticalAlign="Middle" DataField="Ubicacion"  HeaderText="Ubicación Cilindros"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="CodigosCilindros" DataField="CodigosCil" HeaderText="Códigos Cilindros"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamamo" DataField="Tamano" HeaderStyle-HorizontalAlign="Center"  HeaderText="Tamaño"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="TipoCil" DataField="TipoCil" HeaderText="Tipo de Cilindro"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>                       
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57"  />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB"  />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
       
             <h4>
             <asp:Label ID="lblTotalCil" runat="server" Text="Total Cilindros:"></asp:Label>
             </h4>  
             <br />
               <asp:GridView ID="gvCantidad" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="Both"  >
                    <AlternatingRowStyle BackColor="White"  />                    
                    <Columns>
                        <asp:BoundField SortExpression="Ubicacion" HeaderStyle-VerticalAlign="Middle" DataField="Ubicacion"  HeaderText="Ubicación Cilindros"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Cantidad" DataField="Cantidad" HeaderText="Cantidad"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamano" DataField="Tamano" HeaderText="Tamaño"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57"  />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB"  />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>    
        </fieldset>
    </div>
    <div class="submitButton" id="divBotones" runat="server" visible="false">
        <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" 
            onclick="btnImp_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" OnClick="btnMenu_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
    </div>
</asp:Content>
