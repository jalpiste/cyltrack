<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmConsultarVenta.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmConsultarVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Consultar Venta
    </h1>
<span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>

            <asp:ValidationSummary ID="ConsultarVentaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="ConsultarVentaValidationGroup"/>
    <div>
            <fieldset class="login" style="width: 777px">
                <legend>Consulta de Venta</legend>
                    <asp:Label ID="lblCedulaCliente" runat="server" Text="Cédula cliente:"></asp:Label>
                        <br />
                    <asp:TextBox ID="txtCedulaCliente" runat="server" CssClass="textEntry" 
                    Width="197px" ontextchanged="txtCedulaCliente_TextChanged"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConsultarVentaRequired" runat="server" ControlToValidate="txtCedulaCliente"
                        CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio."
                        ToolTip="El número de cédula del cliente es obligatorio." ValidationGroup="ConsultarVentaValidationGroup">*</asp:RequiredFieldValidator>
                    <br />
         <div id="DivInfoVenta" runat = "server" visible ="false" >
                <div class="post">Información Venta</div>   
                <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtFecha" runat="server" enabled ="false" CssClass="textEntry"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblHora" runat="server" Text="Hora: "></asp:Label>
                &nbsp;
                <asp:TextBox ID="txtHora" runat="server" Width="90px" enabled ="false" CssClass="textEntry"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="lblNumCed" runat="server" text="Número de Cédula: "></asp:Label>
                <br />
               <asp:TextBox ID="txtNumCedula" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox> <br />
               <br />
               <asp:Label ID="lblNombreCliente" runat="server" text="Nombres del cliente:"></asp:Label>
                <br />
               <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox> <br />
               <br />
                       <asp:Label ID="lblPrimerApellido" runat="server" text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                        <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label>
                       <br />
               <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" enabled ="false" Width="197px" ></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido"  runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
                                <br /><br />
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección:  "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<asp:Label ID="lblBarrio" runat="server" Text="Barrio:" ></asp:Label> 
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <br />
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="Barrio" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                <br/><br/>
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Label ID="DepartamentoLabel" runat="server" text="Departamento:"></asp:Label><br/>
                <asp:TextBox ID="txtCiudad" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtDepartamento" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox><br/><br/>
             <asp:Label ID="lblTelefono" runat="server" Text="Teléfono: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <br />
             <asp:TextBox ID="txtTelefono" runat="server" CssClass="textEntry" Width="197px" enabled ="false"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br/><br/>
                <asp:Label ID="lblCilindro" runat="server" Text="Código cilindro: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="lblTamano" runat="server" Text="Tamaño: "></asp:Label>               
                <br />
                <asp:TextBox ID="txtCilindro" runat="server" CssClass="textEntry" Width="127px" enabled ="false"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtTamano" runat="server" CssClass="textEntry" Width="51px" enabled ="false"></asp:TextBox>
                <br /><br />
                <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones: "></asp:Label>
                <br />
                <asp:TextBox ID="txtObservacion" runat="server" Height="77px" Width="306px" enabled ="false" CssClass="textEntry"></asp:TextBox>
                <br /><br />
                 <div class="post">Vendedor</div>  
             <asp:Label ID="lblNombreConductor" runat="server" Text="Nombre: "></asp:Label><br />
             <asp:TextBox ID="txtNombreConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false"></asp:TextBox>
             <br /><br />
             <asp:Label ID="lblApellidoConductor" runat="server" Text="Primer Apellido: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Label ID="lblSegundoApellidoConductor" runat="server" Text="Segundo Apellido: "></asp:Label><br />
             <asp:TextBox ID="txtApellidoConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtSegundoApellidoConductor" CssClass="textEntry" Width="197px" runat="server" enabled ="false"></asp:TextBox>
             <br /><br />
             <asp:Label ID="lblPlaca" runat="server" Text="Placa Vehículo: "></asp:Label>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
             <asp:Label ID="lblRuta" runat="server" Text="Ruta: "></asp:Label><br />
             <asp:TextBox ID="txtPlaca" CssClass="textEntry" Width="127px" runat="server" enabled ="false"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
             <asp:TextBox ID="txtRuta" CssClass="textEntry" Width="127px" runat="server" enabled ="false"></asp:TextBox>
             <br />
             <br />
             <asp:CheckBox ID="chckCasoEspecial" runat="server" Text="Reportar código erroneo en venta" 
                    oncheckedchanged="chckCasoEspecial_CheckedChanged" />
           </div> 
           <div id="divCilCorrecto" runat="server" visible="false">
           <br />
           <div class="post">Datos Cilindro</div> 
               <h3>Digite el código del cilindro correcto entregado al cliente:</h3>
               <br />
               <asp:Label ID="lblCilindroCorrecto" runat="server" Text="Código Cilindro:"></asp:Label>
               <br />
               <asp:TextBox ID="txtCilCorrecto" runat="server" CssClass="textEntry"></asp:TextBox>
           </div>
        </fieldset>
        <p class="submitButton">
                     
                <asp:Button ID="btnNuevaConsulta" runat="server" Visible="false" 
                    Text="Nueva Consulta" Width="115px" onclick="btnNuevaConsulta_Click"/> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                    onclick="btnMenu_Click"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    </p>
        </div>
</asp:Content>
