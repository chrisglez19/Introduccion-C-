<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebEstatusAlumno.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Actualizar</h1>
<div>
        <asp:Label ID="lblId" runat="server" Text="Id"></asp:Label>
        <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    </div>
     <div>
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
    </div>
    <div>
         <asp:HyperLink href="Index.aspx" ID="regresarAg" runat="server">Regresar a la Lista</asp:HyperLink>
         <asp:Button ID="btnGuardarEdit" runat="server" Text="Guardar" OnClick="btnGuardarEdit_Click" />
    </div>
</asp:Content>
