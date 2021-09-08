<%@ Page Title="Detalles" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="WebEstatusAlumno.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Detalles</h1>
    <div>
        <dl>
            <dt> <asp:Label ID="lblIdK" runat="server" Text="Id "></asp:Label></dt>
            <dd><asp:Label ID="lblIdV" runat="server" Text=""></asp:Label></dd>

        <dt><asp:Label ID="lblNomK" runat="server" Text="Nombre "></asp:Label></dt>
        <dd><asp:Label ID="lblNomV" runat="server" Text=""></asp:Label></dd>

    <dt><asp:Label ID="lblClveK" runat="server" Text="Clave "></asp:Label></dt>
    <dd> <asp:Label ID="lblClveV" runat="server" Text=""></asp:Label></dd>
</dl>
        <asp:HyperLink ID="HyperLink1" href="Index.aspx" runat="server">Regresar a la Lista</asp:HyperLink>
        

</asp:Content>
