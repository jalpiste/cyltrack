<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRevisionCasosEspeciales.aspx.cs" Inherits="CYLTRACK_WebApp.Ventas.frmRevisionCasosEspeciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Revisión Casos Especiales
    </h1>
    <div class="accountInfo">
  <fieldset class="login" style="width: 777px">
                <legend>Revisión Casos Especiales</legend>
                <h3>
                Seleccione la opción del caso a revisar:
                </h3>
                <br />
                 <asp:ListBox ID="lstCaso" runat="server" Rows="1" AutoPostBack="True"
                        onselectedindexchanged="lstCaso_SelectedIndexChanged">
                        <asp:ListItem>Seleccionar...</asp:ListItem>
                        <asp:ListItem>Escape de Cilindro</asp:ListItem>
                        <asp:ListItem>Terminación del Contrato </asp:ListItem>
                        <asp:ListItem>Error en el Código del Cilindro Entregado por el Cliente</asp:ListItem>
                    </asp:ListBox>
                           <br />
                           <br />
       <asp:GridView ID="gvReporte" runat="server" Visible="false" CellPadding="4" ForeColor="#333333" 
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
 </fieldset>
 <p class="submitButton">
  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                    onclick="btnMenu_Click"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
 </div>

</asp:Content>
