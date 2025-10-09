<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Business.aspx.cs" Inherits="Business.Web.Business" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-2xl font-bold mb-4">📊 Lista de Negocios</h2>

    <asp:GridView ID="GridView1" runat="server" CssClass="table-auto w-full border border-gray-300"
        AutoGenerateColumns="true">
    </asp:GridView>

    <asp:Button ID="btnCargar" runat="server" Text="Cargar Negocios" CssClass="bg-blue-500 text-white px-4 py-2 rounded"
        OnClick="btnCargar_Click" />
</asp:Content>
