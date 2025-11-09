<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="CreateUser.aspx.cs"
    Inherits="ManageBusinessFront.Users.CreateUser"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="max-w-md mx-auto mt-12 bg-white shadow-lg rounded-2xl p-8">
        <h2 class="text-2xl font-bold text-blue-700 mb-6 text-center">
            👤 Alta de Usuario
        </h2>

        <!-- Nombre -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtFirst"
                Text="Nombre:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtFirst" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqFirst" runat="server"
                ControlToValidate="txtFirst" ErrorMessage="⚠️ El nombre es obligatorio."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="valLetters" runat="server"
                ControlToValidate="txtFirst"
                ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúñÑ\s]{1,25}$"
                ErrorMessage="⚠️ Solo letras, máximo 25 caracteres."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Apellido -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtApellido"
                Text="Apellido:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtApellido" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqApellido" runat="server"
                ControlToValidate="txtApellido" ErrorMessage="⚠️ El apellido es obligatorio."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Email -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtEmail"
                Text="Correo electrónico:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtEmail" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqEmail" runat="server"
                ControlToValidate="txtEmail" ErrorMessage="⚠️ El correo es obligatorio."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="valEmail" runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="⚠️ Formato de correo inválido."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Password -->
        <div class="mb-6">
            <asp:Label runat="server" AssociatedControlID="txtpassword"
                Text="Contraseña:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqPassword" runat="server"
                ControlToValidate="txtpassword" ErrorMessage="⚠️ La contraseña es obligatoria."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="valPass" runat="server"
                ControlToValidate="txtpassword"
                ValidationExpression="^(?=.*[A-Za-z])(?=.*\d).{6,}$"
                ErrorMessage="⚠️ Debe tener al menos 6 caracteres y un número."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Botones -->
        <div class="flex justify-center gap-4">
            <asp:Button ID="btnSave" runat="server" Text="💾 Guardar"
                CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold py-2 px-6 rounded-lg shadow-md transition-transform transform hover:scale-105"
                OnClick="btnSave_Click" />

            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="❌ Cancelar"
                CssClass="bg-gray-400 hover:bg-gray-500 text-white font-semibold py-2 px-6 rounded-lg shadow-md transition-transform transform hover:scale-105"
                OnClick="btnCancel_Click" />
        </div>

        <!-- Mensaje -->
        <asp:Label ID="lblMsg" runat="server"
            CssClass="block text-center mt-4 font-semibold"></asp:Label>
    </div>

</asp:Content>
