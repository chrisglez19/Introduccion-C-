<%@ Page Title="Eliminar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="WebEstatusAlumno.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Eliminar</h1>
<div>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        <asp:TextBox disabled="true" ID="txtId" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox disabled="true" ID="txtNombre" runat="server"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox disabled="true" ID="txtClave" runat="server"></asp:TextBox>
    </div>
    <div>
         <asp:HyperLink href="Index.aspx" ID="regresarAg" runat="server">Regresar a la Lista</asp:HyperLink>
         <asp:Button ID="btnGuardarDel" runat="server" Text="Eliminar" OnClick="btnGuardarDel_Click" />
    </div>
</asp:Content>
