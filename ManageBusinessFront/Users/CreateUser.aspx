<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs"
    Inherits="ManageBusinessFront.Users.CreateUser"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Dar de alta usuario: </h2>

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

    <div>
        <asp:Label runat="server" AssociatedControlID="txtApellido" Text="Apellido"></asp:Label><br />
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="reqApellido" runat="server"
            ControlToValidate="txtApellido"
            ErrorMessage="El apellido es obligatorio."
            CssClass="text-red-600 text-sm ml-1"
            Display="Dynamic" />
    </div>

    <div>
        <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Email"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="reqEmail" runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="El Email es obligatorio."
            CssClass="text-red-600 text-sm ml-1"
            Display="Dynamic" />
    </div>

    <div>
        <asp:Label runat="server" AssociatedControlID="txtpassword" Text="password"></asp:Label><br />
        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="reqPassword" runat="server"
            ControlToValidate="txtpassword"
            ErrorMessage="La password es obligatoria."
            CssClass="text-red-600 text-sm ml-1"
            Display="Dynamic" />
    </div>

    <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary"
        OnClick="btnSave_Click" />
    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancelar" CssClass="btn btn-secondary ms-2"
        OnClick="btnCancel_Click" />
    <br />
    <br />
    <asp:Label ID="lblMsg" runat="server" />
</asp:Content>

