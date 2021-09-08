<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="WebEstatusAlumno.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Agregar</h1>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
    </div>
    <div>
         <asp:HyperLink ID="regresarAg" href="Index.aspx"  runat="server">Regresar a la Lista</asp:HyperLink>
         <asp:Button ID="btnGuardarAg" runat="server" Text="Guardar" OnClick="btnGuardarAg_Click" />
    </div>
</asp:Content>
