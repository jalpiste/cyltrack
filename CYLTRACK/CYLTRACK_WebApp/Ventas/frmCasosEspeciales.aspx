<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCasosEspeciales.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Ventas.frmCasosEspeciales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1 style="margin-top: 75px">
        Casos Especiales
    </h1>
     <div class="accountInfo">
  <fieldset class="login" style="width: 777px">
                <legend>Casos Especiales</legend>
                <h3>
                Digite el número de cédula del cliente
                </h3>
                <br />
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
                 </div>
                <div id="divVerifInfo" runat="server" visible="false">
                 <div class="post">Verificación de Información</div>  
               <h3>Seleccione la opcion correspondiente a su caso: </h3>
                    <asp:ListBox ID="lstCaso" runat="server" Rows="1" AutoPostBack="True"
                        onselectedindexchanged="lstCaso_SelectedIndexChanged">
                        <asp:ListItem>Seleccionar...</asp:ListItem>
                        <asp:ListItem>Escape de Cilindro</asp:ListItem>
                        <asp:ListItem>Terminación del Contrato </asp:ListItem>
                        <asp:ListItem>Error en el Código del Cilindro Entregado por el Cliente</asp:ListItem>
                    </asp:ListBox>

                    <div id="divEscape" runat="server" visible="false">
             <br />
             <p>
                 <asp:Label ID="lblEscape" runat="server" Text="Seleccione el código del cilindro a entregar:"></asp:Label> 
                 <br />
                 <asp:ListBox ID="lstCilEntrega" runat="server" Rows="1">
                     <asp:ListItem>889898776</asp:ListItem>
                     <asp:ListItem>998987655</asp:ListItem>
                 </asp:ListBox>
           </p>
           </div>
           <div id="divCodCorrecto" runat="server" visible="false">
             <br />
             <p>
                 <asp:Label ID="lblCodigoVerific" runat="server" Text="Digite el código del cilindro correcto:"></asp:Label> 
                 <br />
                 <asp:TextBox ID="txtCodigoVerific" runat="server" CssClass="textEntry"></asp:TextBox>
           </p>
           </div>
             </div>

           
            
          </fieldset>
        </div>
                <p class="submitButton">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Width="115px" 
                        visible="false" onclick="btnGuardar_Click1"/>  
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  
                    <asp:Button ID="btnMenu" runat="server" Text="Menú Principal" Width="115px" 
                        onclick="btnMenu_Click" />
               </p>
           
</asp:Content>
