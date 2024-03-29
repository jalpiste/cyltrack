﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmConsultarPedido.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp.Pedido.frmConsultarPedido" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 75px">
        Consultar Pedido
    </h1>
         <asp:ValidationSummary ID="ValidarCedulaValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="Validar" Font-Size = "Small"/>
                 
            <div class="accountInfo">
                <fieldset class="login">
                    <legend>Consulta de Pedidos</legend>
                                      <p>
                        <asp:Label ID="lblCedula" runat="server" AssociatedControlID="txtCedula" >Número de Cédula:</asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNumPedido" runat="server" Text="Número de Pedido: "></asp:Label>
&nbsp;&nbsp; <br />
                        <asp:TextBox ID="txtCedula" runat="server" CssClass="textEntry" 
                            Width="197px" ontextchanged="txtCedula_TextChanged"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="ValidarDatosCedula" runat="server" ControlToValidate="txtCedula" 
                            CssClass="failureNotification" ErrorMessage="El número de cédula debe contener entre 6 y 10 dígitos." 
                            ValidationExpression="^([\d]{6,10})$"  Font-Size = "Small" Display ="Dynamic"
                            ValidationGroup="Validar" >*</asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="txtCedulaRequired" runat="server" ControlToValidate="txtCedula" 
                             CssClass="failureNotification" ErrorMessage="El número de cédula del cliente es obligatorio." ToolTip="El número de cédula del cliente es obligatorio." 
                             ValidationGroup="Validar" >*</asp:RequiredFieldValidator>
                     
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:TextBox ID="txtNumPedido" CssClass="textEntry" runat="server" 
                                  Width="112px" ontextchanged="NumPedidoTxt_TextChanged"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="ValidarDatosPedido" runat="server" ControlToValidate="txtNumPedido" 
                             CssClass="failureNotification" ErrorMessage="El número del pedido es obligatorio." 
                             ValidationGroup="Validar" >*</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="ValidarPedido" runat="server" ControlToValidate="txtNumPedido" 
                            CssClass="failureNotification" ErrorMessage="El número del pedido debe contener entre 3 y 5 dígitos." 
                            ValidationExpression="\d*"  
                            ValidationGroup="Validar" >*</asp:RegularExpressionValidator>
                       
                     
                 <br />

                       
                        
                        </p>
                    <div id="divInfoCliente" runat="server" visible="false">
                 <div class="post">Información General del Cliente</div>
                  <h4><asp:Label ID="lblPedidoCancelado" runat="server" Enabled="false"></asp:Label>
                        </h4> 
                 <h5>
                 <asp:Label ID="lblPedido" runat="server" Text="Pedido N°: "></asp:Label>
                        <asp:Label ID="lblCodigoPedido" runat="server" ></asp:Label>
                    </h5>                    
                    <p>
                        <asp:Label ID="lblCedulaCliente" runat="server" AssociatedControlID="txtCedulaCliente" Text="Número de Cédula: "></asp:Label><br />
                        <asp:TextBox ID="txtCedulaCliente" CssClass="textEntry" enabled = "false" runat="server" Width="197px"></asp:TextBox>
                    </p>                   
                    <p>
                        <asp:Label ID="lblNombreCliente" runat="server" AssociatedControlID="txtNombreCliente">Nombres del cliente:</asp:Label><br />
                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                    </p>  
                    <p>
                        <asp:Label ID="lblPrimerApellido" runat="server" Text="Primer Apellido:"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                               <asp:Label ID="SegundoApellidoLabel" runat="server" Text="Segundo Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="textEntry" Width="197px" Enabled="False" ></asp:TextBox>
                     <asp:Label ID="lblIdUbica" runat="server" Visible="false"></asp:Label>                      
                    </p> 
                   <div id="divDirCliente" runat="server" visible="false">  
                   <div class="post">Direcciones del Cliente</div> 
                    <asp:GridView ID="gvDirecciones" runat="server" AutoGenerateColumns="False" 
                    CellPadding="7" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField SortExpression="IdUbicacion" DataField="IdUbicacion" HeaderText="IdUbicacion"
                            HeaderStyle-Width="100px" Visible="false">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Direccion" DataField="Direccion" HeaderText="Dirección"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Barrio" DataField="Barrio"  HeaderText="Barrio"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="110px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Telefono" DataField="Telefono" HeaderText="Teléfono"
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="130px" />
                        </asp:BoundField>
                        <asp:BoundField SortExpression="Ciudad" DataField="Ciudad" HeaderText="Ciudad"
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
                <div id="divInfoPedido" runat="server" visible="false" >
                   <div class="post">Información Pedido</div>
                                     
                    <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="False" 
                    CellPadding="3" ForeColor="#333333" GridLines="None" > 
                              
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
                        <asp:BoundField SortExpression="FechaPedido" DataField="FechaPedido" HeaderText="Fecha "
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="200px" />
                        </asp:BoundField>
                         <asp:BoundField SortExpression="CodigoPedido" DataField="CodigoPedido" HeaderText="Código Pedido "
                            HeaderStyle-Width="100px">
                            <HeaderStyle Width="200px" />
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
                   </div>
                </fieldset>
                <p class="submitButton">
                <asp:Button ID="btnNuevaConsulta" runat="server" Text="Nueva Consulta" Visible="false" 
                        onclick="btnNuevaConsulta_Click" /> 
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                    <asp:Button ID="btnMenuPrincipal" runat="server" Text="Menú Principal" onclick="btnMenuPrincipal_Click"  
                       />  
                    
                    </p>
            </div>
</asp:Content>
