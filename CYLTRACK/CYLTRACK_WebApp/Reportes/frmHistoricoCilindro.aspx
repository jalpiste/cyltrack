<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmHistoricoCilindro.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Reportes.frmHistoricoCilindro" %>
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
                            ></asp:TextBox>
                     <asp:RequiredFieldValidator ID="HistorialRequired" runat="server" 
                     ControlToValidate="txtCodigoCil" CssClass="failureNotification" 
                     ErrorMessage="El código del cilindro es obligatorio." ToolTip="El código del cilindro es obligatorio." 
                     ValidationGroup="HistorialValidationGroup"> * </asp:RequiredFieldValidator>
                     </div>
                     <br />
                </fieldset>
                 <p class="submitButton">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="115px" onclick="btnBuscar_Click"/>  
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
               </p>

        <div id= "DivHistoricoCilindro" runat = "server" class="accountInfo" visible="false">
       <fieldset class ="login">
            <legend>Reporte</legend>
              <p>  
               <br />        
             <asp:GridView ID="gvCargue" runat="server" AutoGenerateColumns="False" 
                    CellPadding="5" ForeColor="#333333" GridLines="None"  >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="CodigoCilindro" DataField="CodigosCil" HeaderText="Código Cilindro"
                           >
                            <%--<HeaderStyle Width="130px" />--%>
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Tamamo" DataField="Tamano" HeaderText="Tamaño"
                           >
                            <%--<HeaderStyle Width="110px" />--%>
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Fecha" DataField="Fecha" HeaderText="Fecha/Hora"
                            >
                            <%--<HeaderStyle Width="130px" />--%>
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Ubicacion" DataField="Ubicacion" HeaderText="Ubicación"
                            >
                            <%--<HeaderStyle Width="130px" />--%>
                        </asp:BoundField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#AC3332" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666"
                     ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
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
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
              <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" Width="115px" 
                         Visible="false" onclick="btnMenuPrincipal_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
             </p>
        </div> 
        
               
</asp:Content>
