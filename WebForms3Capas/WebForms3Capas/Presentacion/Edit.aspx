<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Presentacion.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Actualizar</h1>
    <div class="form-group" >
        
        <asp:Label ID="lblId" class="control-label col-md-2"  runat="server" Text="Id "></asp:Label>
        <asp:TextBox ID="txtId" disabled="true" runat="server"></asp:TextBox>
    </div>
    
    <div class="form-group">
        <asp:Label ID="lblNombre" class="control-label col-md-2" runat="server" Text="Nombre "></asp:Label>
        
          <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            
    </div>
     <div class="form-group">
         <asp:Label ID="lblprimerApellido" class="control-label col-md-2" runat="server" Text="Primer Apellido "></asp:Label>
        <asp:TextBox ID="txtpApp" runat="server"></asp:TextBox>
         <asp:RequiredFieldValidator ID="validaFieldApellido" runat="server" ErrorMessage="Debes ingresar un Apellido" ControlToValidate="txtpApp"></asp:RequiredFieldValidator>
         
    </div>
     <div class="form-group">
         <asp:Label ID="lblsegundoApellido" class="control-label col-md-2" runat="server" Text="Segundo Apellido "></asp:Label>
        <asp:TextBox ID="txtsApp" runat="server"></asp:TextBox>
    </div>
     <div class="form-group">
         <asp:Label ID="lblNacimiento" class="control-label col-md-2" runat="server" Text="Fecha de Nacimiento"></asp:Label>
        <asp:TextBox ID="txtNacimiento" runat="server" TextMode="Date" ></asp:TextBox>
    </div> 
         <asp:RequiredFieldValidator ID="validaFieldFecha" runat="server" ErrorMessage="Debes ingresar una Fecha de Nacimiento" ControlToValidate="txtNacimiento"></asp:RequiredFieldValidator>
         
         <asp:RangeValidator ID="validaRangoFecha" runat="server" ErrorMessage="Debe ser mayor a 18 años" MaximumValue="2003-01-01" MinimumValue="1990-01-01" Type="Date" Width="130px" ControlToValidate="txtNacimiento"></asp:RangeValidator>
         
     <div class="form-group">
         <asp:Label ID="lblCurp" class="control-label col-md-2" runat="server" Text="CURP "></asp:Label>
        <asp:TextBox ID="txtCurp" runat="server"></asp:TextBox>
    </div>
         <asp:RequiredFieldValidator ID="validaFieldCurp" runat="server" ErrorMessage="Debes ingresar tu CURP" ControlToValidate="txtCurp"></asp:RequiredFieldValidator>
 
         <asp:RegularExpressionValidator ID="validaExRegCurp" runat="server" ErrorMessage="Formato de curp no válido" ControlToValidate="txtCurp" ValidationExpression="(^[A-Z]{1}[AEIOU]{1}[A-Z]{2}[0-9]{6}[HM]{1}[DF|HG|MC|MN|ZS]{2}[^AEIOU]{3}[0-9]{2})"></asp:RegularExpressionValidator>
         
    <asp:CustomValidator ID="validaCurpFecha" runat="server" ErrorMessage="La fecha de nacimiento no coincide con la CURP" ControlToValidate="txtCurp" OnServerValidate="validaCurpFecha_ServerValidate"></asp:CustomValidator>
        
     <div class="form-group">
         <asp:Label ID="lblCorreo" class="control-label col-md-2" runat="server" Text="Correo"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
    </div>
         <asp:RequiredFieldValidator ID="validaFieldCorreo" runat="server" ErrorMessage="Debes ingresar un Correo" ControlToValidate="txtCorreo"></asp:RequiredFieldValidator>
         
         <asp:RegularExpressionValidator ID="validaExRegCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[a-zA-Z0-9]*(@gmail.com|@hotmail.com|@outlook.com)$">Formato de correo incorrecto</asp:RegularExpressionValidator>
         
    <div  class="form-group">
         <asp:Label ID="lblTel" class="control-label col-md-2" runat="server" Text="Telefono "></asp:Label>
        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
    </div>
         <asp:RequiredFieldValidator ID="validaFieldTel" runat="server" ErrorMessage="Debes ingresar un Telefono" ControlToValidate="txtTel"></asp:RequiredFieldValidator>
         
         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtTel" ErrorMessage="Formato de Telefono incorrecto" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
         
     <div class="form-group">
         <asp:Label ID="lblSueldo" class="control-label col-md-2" runat="server" Text="Sueldo"></asp:Label>
        <asp:TextBox ID="txtSueldo" runat="server"></asp:TextBox>
    </div>
     <div class="form-group">
         <asp:Label ID="lblEstado" class="control-label col-md-2" runat="server" Text="Estado"></asp:Label>
        <asp:DropDownList ID="ddlEstados" runat="server"></asp:DropDownList>
    </div>
    <div class="form-group">
         <asp:Label ID="lblEstatus" class="control-label col-md-2" runat="server" Text="Estatus "></asp:Label>
       <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
    </div>
     <div class="form-group">
         <asp:Button ID="btnGuardarEdit" runat="server" Text="Guardar" Height="25px" OnClick="btnGuardarEdit_Click"  />
     </div>
    <div>
         <asp:HyperLink ID="regresarAg" href="Index.aspx"  runat="server">Regresar a la Lista</asp:HyperLink>
    </div>
</asp:Content>
