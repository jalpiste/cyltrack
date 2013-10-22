<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Unisangil.CYLTRACK.CYLTRACK_WebApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 856px;
            height: 450px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h1 style="margin-top: 90px; height: 428px;">
        <img alt="Principal" class="style1" src="Imagenes/Inicio.png" /></h1>
    <p>
        Para obtener más información acerca de Cyltrack, visite <a href="http://www.cyltrack.net" title="Sitio web de Cyltrack">www.Cyltrack.net</a>.
    </p>
    <p>
        Mayor información en nuestras sedes: Bogotá (Autopista Medellín Km 2. Tel: 091-5776908), Chiquinquirá (Km 2 via Chiquinquirá-Bogotá. Tel: 098-7265900).
    </p>
</asp:Content>
