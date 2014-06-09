<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCargaryDescargarCilindros.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Cilindros.frmCargaryDescargarCilindros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
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
           <asp:ListBox ID="lstOpcion" AutoPostBack="True" runat="server" Rows="1" onselectedindexchanged="lstOpcion_SelectedIndexChanged" 
              >
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
                     <asp:Label ID="lblPlaca" runat="server" Text="Placa del vehículo:" Visible="false"></asp:Label>
                     <br />
                     <asp:ListBox ID="lstPlaca" runat="server" Rows="1" Visible="false" >
                         <asp:ListItem>Seleccionar</asp:ListItem>
                     </asp:ListBox>
                     <br />
                     <br />
                      
      <asp:GridView ID="gvCargue" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None" Visible="false">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="CodigosCilindros" DataField="CodigosCil" HeaderText="Códigos Cilindros"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamamo" DataField="Tamano"  HeaderText="Tamaño"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="TipoCil" DataField="TipoCil" HeaderText="Tipo de Cilindro"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Seleccionar">
                            <ItemTemplate>
                                <asp:Button ID="Agregar" runat="server" Text="Agregar" Width="100px"   
                                AutoPostBack="true" value='<%# Eval("CodigosCil")%>' OnClick="Agregar_onClick"  />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                     <asp:GridView ID="gdAdd" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" ForeColor="#333333" GridLines="None" Visible="false" AutoGenerateDeleteButton = "true" onrowdeleting="gvCargueyDescargue_RowDeleting">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="CodigosAdd" DataField="CodigosAdd" HeaderText="Códigos Agregados"
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
        
       <br />
                     
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
