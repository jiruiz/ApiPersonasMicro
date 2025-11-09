<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="Login.aspx.cs" Inherits="ManageBusinessFront.Login" MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="max-width: 400px; margin: 0 auto; padding: 20px; border: 1px solid #ccc; border-radius: 8px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);">
        <h2 class="text-center text-gray-800 font-semibold mb-4">🔒 Iniciar Sesión</h2>

        <div class="mb-4">
            <asp:Label ID="lblUser" runat="server" Text="Usuario" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Ingrese su usuario"></asp:TextBox>
        </div>

        <div class="mb-4">
            <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="block text-sm font-medium text-gray-700"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5" placeholder="Ingrese su contraseña"></asp:TextBox>
        </div>

        <div class="flex justify-between items-center">
            <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar Sesión" CssClass="bg-blue-600 hover:bg-blue-700 text-white font-semibold px-6 py-2 rounded-lg shadow-md transition-all duration-200 hover:scale-105" OnClick="btnIniciarSesion_Click" />
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-6 py-2 rounded-lg shadow-md transition-all duration-200 hover:scale-105" OnClick="btnRegistrarse_Click" />
        </div>

        <div class="mt-4 text-center text-red-600">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>