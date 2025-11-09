<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="ManageBusinessFront.Home.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex flex-col items-center justify-center mt-20 space-y-6 text-center">
        <h1 class="text-3xl font-extrabold text-blue-700">🏢 Bienvenido a ManageBusinessFront</h1>
        <p class="text-gray-600 text-lg max-w-xl">
            Este panel le permite administrar <span class="font-semibold text-blue-600">Negocios</span> y
            <span class="font-semibold text-blue-600">Empleados</span> de forma sencilla y eficiente.
        </p>

        <div class="flex flex-wrap justify-center gap-6 mt-8">
            <asp:Button ID="btnGoToBusinesses" runat="server" Text="🏬 Ir a Negocios"
                CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-8 py-3 rounded-xl shadow-md transition-transform transform hover:scale-105"
                OnClick="btnGoToBusinesses_Click" />

            <asp:Button ID="btnGoToEmployees" runat="server" Text="👨‍💼 Ir a Empleados Generales"
                CssClass="bg-blue-600 hover:bg-blue-700 text-white font-semibold px-8 py-3 rounded-xl shadow-md transition-transform transform hover:scale-105"
                OnClick="btnGoToEmployees_Click" />
        </div>

        <div class="mt-12 text-gray-500 text-sm">
            <p>© 2025 ManageBusinessFront — Panel de Gestión Empresarial</p>
        </div>
    </div>
</asp:Content>
