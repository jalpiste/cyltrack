<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHistoricoCilindro.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Reporte.frmHistoricoCilindro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1 style="margin-top: 75px">
        Histórico de Cilindro
    </h1>
    <br />
     <asp:ValidationSummary ID="HistorialValidationSummary" runat="server" CssClass="failureNotification"
        ValidationGroup="HistorialValidationGroup" Width="385px" />

        <div class="accountInfo">
                 <fieldset class="login">
                    <legend>Historial</legend>
                    <div id="DivHistorial" runat="server">
                     <asp:Label ID="lblCodigoCil" runat="server" Text="Código Cilindro: "></asp:Label>           
                     <br />
                     <asp:TextBox ID="txtCodigoCil" runat="server" CssClass="textEntry" Width="197px" 
                            ontextchanged="txtCodigoCil_TextChanged" ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="HistorialRequired" runat="server" 
                     ControlToValidate="txtCodigoCil" CssClass="failureNotification" 
                     ErrorMessage="El código del cilindro es obligatorio." ToolTip="El código del cilindro es obligatorio." 
                     ValidationGroup="HistorialValidationGroup"> * </asp:RequiredFieldValidator>
                     </div>
                     <br />
                </fieldset>
                 <p class="submitButton">
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" onclick="btnMenu_Click"/>  
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
               </p>

        <div id= "DivHistoricoCilindro" runat = "server" class="accountInfo" visible="false">
       <fieldset class ="login">
            <legend>Reporte</legend>
              <asp:Label ID="lblCodigo" runat="server" Text="Código: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblTamaño" runat="server" Text="Tamaño: "></asp:Label><br />
                <asp:TextBox ID="txtCódigo" runat="server" CssClass="textEntry" Enabled ="false" ></asp:TextBox>               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtTamano" runat="server" CssClass="textEntry" Width="97px" Enabled ="false" ></asp:TextBox>   
                <br /> 
               <p>  
               <br />        
             <asp:GridView ID="gvReporte" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
            </p>    
            </fieldset>
             </div>
                 <p class="submitButton">
             <asp:Button ID="btnImp" runat="server" Text="Imprimir" Width="115px" Visible="false"/>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
             </p>
        </div> 
        
               
</asp:Content>
