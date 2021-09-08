<%@ Page Title="Indice" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebEstatusAlumno.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Indice</h1>
    <asp:DropDownList ID="ddlStatus" runat="server"  Width="195px">
    </asp:DropDownList>    
  



    <div>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />

    <asp:Button ID="btnDetalles" runat="server" Text="Detalles" OnClick="btnDetalles_Click" />

    <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnDelete_Click"/>
    </div>




</asp:Content>
