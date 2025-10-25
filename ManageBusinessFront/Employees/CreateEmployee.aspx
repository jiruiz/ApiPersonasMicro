<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="CreateEmployee.aspx.cs"
    Inherits="ManageBusinessFront.Employees.CreateEmployee"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Dar de alta al empleado: </h2>
      <div class="mb-2">
      <div class="mb-2">
        <asp:Label runat="server" AssociatedControlID="txtFirst" Text="Nombre"></asp:Label><br />
        <asp:TextBox ID="txtFirst" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="reqFirst" runat="server"
            ControlToValidate="txtFirst"
            ErrorMessage="El nombre es obligatorio."
            CssClass="text-red-600 text-sm ml-1"
            Display="Dynamic" />
        <asp:RegularExpressionValidator ID="valLetters" runat="server"
            ControlToValidate="txtFirst"
            ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]{1,25}$"
            ErrorMessage="El nombre no puede superar los 25 caracteres y no debe tener numeros."
            CssClass="text-red-600 text-sm ml-1"
            Display="Dynamic" />
      </div>
      <div class="mb-2">
        <asp:Label runat="server" AssociatedControlID="txtLast" Text="Apellido"></asp:Label><br />
        <asp:TextBox ID="txtLast" runat="server" CssClass="form-control" />
      </div>
      <div>
          <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Email"></asp:Label><br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
      </div>
      <div>
          <asp:Label runat="server" AssociatedControlID="txtPhone" Text="Telefono"></asp:Label><br />
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" />
      </div>
      <div>
          <asp:Label runat="server" AssociatedControlID="txtBirth" Text="F.Nacimiento (dd/MM/yyyyy)"></asp:Label><br />
            <asp:TextBox ID="txtBirth" runat="server" CssClass="form-control" />
      </div>
      <asp:Label runat="server" AssociatedControlID="txtDept" Text="Departamento laboral"></asp:Label><br />
        <asp:TextBox ID="txtDept" runat="server" CssClass="form-control" />
      </div>
      <div>
           <asp:Label runat="server" AssociatedControlID="txtRange" Text="Rango laboral"></asp:Label><br />
            <asp:TextBox ID="txtRange" runat="server" CssClass="form-control" />
      </div>

      <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary"
                  OnClick="btnSave_Click" />
      <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secondary ms-2"
                  OnClick="btnCancel_Click" />
      <br /><br />
      <asp:Label ID="lblMsg" runat="server" />
</asp:Content>

