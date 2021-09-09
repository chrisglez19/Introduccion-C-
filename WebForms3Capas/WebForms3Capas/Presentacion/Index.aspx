<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Presentacion.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <h1>Listado Alumnos</h1>
    <hr />
    <div class="acomodo"> <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary btn-sm" Height="29px" />

    </div>
    <div>
     
    <asp:GridView ID="gvAlumnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" PageSize="5" OnRowCommand="gvAlumnos_RowCommand" OnPageIndexChanging="gvAlumnos_PageIndexChanging" BorderStyle="None" 
    CssClass="table" 
    GridLines="Horizontal"  >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" />
            <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" />
            <asp:BoundField DataField="Correo" HeaderText="Correo" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Estado" HeaderText="Estado" />
            <asp:BoundField DataField="Estatus" HeaderText="Estatus" />
            <asp:ButtonField CommandName="Consultar" ShowHeader="True" Text="Consultar" >
            <ControlStyle CssClass="btn btn-success btn-sm" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Actualizar" ShowHeader="True" Text="Actualizar">
            <ControlStyle CssClass="btn btn-warning btn-sm" />
            </asp:ButtonField>
            <asp:ButtonField CommandName="Eliminar" ShowHeader="True" Text="Eliminar">
            <ControlStyle CssClass="btn btn-danger btn-sm" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
        </div>
</asp:Content>
