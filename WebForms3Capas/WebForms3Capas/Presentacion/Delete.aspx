<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Presentacion.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h1>Eliminar Alumno</h1>
    <div>
        <h2>¿Esta seguro que desea eliminar al Alumno?</h2>
        <dl class="dl-horizontal">
            <dt> <asp:Label ID="lblIdK" runat="server" Text="Id "></asp:Label></dt>
            <dd><asp:Label ID="lblIdV" runat="server" Text=""></asp:Label></dd>
       
            <dt><asp:Label ID="lblNomK" runat="server" Text="Nombre "></asp:Label></dt>
            <dd><asp:Label ID="lblNomV" runat="server" Text=""></asp:Label></dd>
         
            <dt><asp:Label ID="lblprimerApellidoK" runat="server" Text="Primer Apellido "></asp:Label></dt>
            <dd> <asp:Label ID="lblprimerApellidoV" runat="server" Text=""></asp:Label></dd>
        
            <dt><asp:Label ID="lblsegundoApellidoK" runat="server" Text="Segundo Apellido "></asp:Label></dt>
            <dd> <asp:Label ID="lblsegundoApellidoV" runat="server" Text=""></asp:Label></dd>
       
            <dt><asp:Label ID="lblNacimientoK" runat="server" Text="Fecha de Nacimiento"></asp:Label></dt>
            <dd> <asp:Label ID="lblNacimientoV" runat="server" Text=""></asp:Label></dd>
       
            <dt><asp:Label ID="lblCurpK" runat="server" Text="CURP"></asp:Label></dt>
            <dd> <asp:Label ID="lblCurpV" runat="server" Text=""></asp:Label></dd>
        
            <dt><asp:Label ID="lblCorreoK" runat="server" Text="Correo"></asp:Label></dt>
            <dd> <asp:Label ID="lblCorreoV" runat="server" Text=""></asp:Label></dd>
        
            <dt><asp:Label ID="lblTelK" runat="server" Text="Telefono"></asp:Label></dt>
            <dd> <asp:Label ID="lblTelV" runat="server" Text=""></asp:Label></dd>

            <dt><asp:Label ID="lblSueldoK" runat="server" Text="Sueldo"></asp:Label></dt>
            <dd> <asp:Label ID="lblSueldoV" runat="server" Text=""></asp:Label></dd>
        
            <dt><asp:Label ID="lblEstadoK" runat="server" Text="Estado"></asp:Label></dt>
            <dd> <asp:Label ID="lblEstadoV" runat="server" Text=""></asp:Label></dd>
      
            <dt><asp:Label ID="lblEstatusK" runat="server" Text="Estatus"></asp:Label></dt>
            <dd> <asp:Label ID="lblEstatusV" runat="server" Text=""></asp:Label></dd>


        </dl>
        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" OnClick="btnDelete_Click" Height="31px" />
    </div>
        <asp:HyperLink ID="HyperLink1" href="Index.aspx" runat="server">Regresar a la Lista</asp:HyperLink>
</asp:Content>
