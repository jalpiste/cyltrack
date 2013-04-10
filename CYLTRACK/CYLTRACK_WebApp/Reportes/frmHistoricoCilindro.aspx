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
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" onclick="btnMenu_Click"/>  
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  
               </p>

        <div id= "DivReporte" runat = "server" class="accountInfo" visible="false">
       <fieldset class ="login">
            <legend>Reporte</legend>
              <asp:Label ID="lblCodigo" runat="server" Text="Código: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblTamaño" runat="server" Text="Tamaño: "></asp:Label><br />
                <asp:TextBox ID="txtCódigo" runat="server" CssClass="textEntry" Enabled ="false" ></asp:TextBox>               
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtTamano" runat="server" CssClass="textEntry" Width="97px" Enabled ="false" ></asp:TextBox>               
              <h3>
                <asp:Label ID="lblfecha" runat="server" Text="Fecha"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblHora" runat="server" Text="Hora"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblRuta" runat="server" Text="Ruta"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblUbicacion" runat="server" Text="Ubicación"></asp:Label>
                </h3>
                <div id="DivMostrarReporte" runat = "server" class="accountInfo">
                
                <asp:Label ID="lblResFecha" runat="server" Text="20/02/2013"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblResHora" runat="server" Text="14:36"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblResRuta" runat="server" ></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                <asp:Label ID="lblResUbica" runat="server" Text="Bodega"></asp:Label>
                
                </div>
            </fieldset>
            <p class="submitButton">
            <asp:Button ID="btnImp" runat="server" Text="Imprimir" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             </p>
        </div> 
        
                </div>
</asp:Content>
