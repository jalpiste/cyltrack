<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaryDescargarCilindros.aspx.cs" Inherits="CYLTRACK_WebApp.Cilindros.frmCargaryDescargarCilindros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width: 837px; margin-right: 45px;">
       <h1> 
        Cargue o Descargue de Cilindros:
       </h1>
       <span class="failureNotification">
       <asp:Literal ID="FailureText" runat="server"></asp:Literal>
        </span>       
      
       <asp:ValidationSummary ID="LoginValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="LoginValidationGroup" Width="385px"/>
       <div class="accountInfo"> 
       <fieldset class="login">
       <legend>Cambio de Ubicación</legend>
       <div id="DivCodigo" runat="server" visible="true">
       <h3>Seleccione la opción según corresponda</h3>
       <br />
           <asp:ListBox ID="lstOpcion" AutoPostBack="True" runat="server" Rows="1" 
               onselectedindexchanged="lstOpcion_SelectedIndexChanged">
               <asp:ListItem>Seleccionar...</asp:ListItem>
               <asp:ListItem>Cargue de Cilindros al Vehiculo</asp:ListItem>
               <asp:ListItem>Descargue de Cilindros en Plataforma</asp:ListItem>
           </asp:ListBox>
           <br />        
       </div> 
                 <div id="DivUbicacionCil" runat="server" visible="false">
                  <div class="post" >
                      <asp:Label ID="lblPost" runat="server" Text="Información Cilindro"></asp:Label>
                      </div> 
                     <asp:Label ID="lblPlaca" runat="server" Text="Placa del vehículo:"></asp:Label>
                     <br />
                     <asp:ListBox ID="lstPlaca" runat="server" Rows="1" >
                         <asp:ListItem>XHA940</asp:ListItem>
                         <asp:ListItem>UZK201</asp:ListItem>
                         <asp:ListItem>UZK345</asp:ListItem>
                     </asp:ListBox>
                     <br />
                     <br />
                     
       
       
       <asp:GridView ID="gvReporte" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
            <Columns>
               <asp:CheckBoxField  DataField="" HeaderText="Seleccionar" Text="88098766"/>
             </Columns>
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
       
      </div>
       </fieldset><p class="submitButton">
                 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" 
                    Width="140px" Visible="false" onclick="BtnGuardar_Click1" />  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="BtnMenu" runat="server" Text="Menú Principal" Width="140px" 
                        onclick="BtnMenu_Click"     /> 
                    </p>
       </div>
  </div> 
</asp:Content>
