<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="BusinessEdit.aspx.cs"
    Inherits="ManageBusinessFront.Business.BusinessEdit"
    MasterPageFile="~/Site1.Master" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-danger { color: #dc2626; font-size: 0.875rem; }
        .input-text { width:100%; padding:0.5rem; border:1px solid #d1d5db; border-radius:0.5rem; }
        .input-text:focus { outline:none; border-color:#3b82f6; box-shadow:0 0 0 1px #3b82f6; }
        .label-text { display:block; font-weight:500; color:#374151; margin-bottom:0.25rem; }
    </style>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-2xl font-bold text-center text-blue-700 mb-6">✏️ Editar Negocio</h2>

    <div class="max-w-xl mx-auto bg-white shadow-md rounded-xl p-6 space-y-4">
        <asp:TextBox ID="idTextBox" runat="server" Visible="false" />

        <!-- Nombre -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Nombre del negocio:" />
            <asp:TextBox CssClass="input-text" ID="nameTextBox" runat="server" />
        </div>

        <!-- Rubro -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Rubro:" />
            <asp:TextBox CssClass="input-text" ID="industryTextBox" runat="server" />
        </div>

        <!-- Teléfono -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Teléfono:" />
            <asp:TextBox CssClass="input-text" ID="phoneNumberTextBox" runat="server" />
        </div>

        <!-- Email -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Correo electrónico:" />
            <asp:TextBox CssClass="input-text" ID="emailTextBox" runat="server" />
        </div>

        <!-- CUIT -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="CUIT:" />
            <asp:TextBox CssClass="input-text" ID="taxIdTextBox" runat="server" />
        </div>

        <!-- Condición IVA -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Condición frente al IVA:" />
            <asp:DropDownList ID="VATStatusDropDown" runat="server" CssClass="input-text">
                <asp:ListItem Text="-- Seleccione --" Value="" />
                <asp:ListItem Text="Monotributista" Value="Monotributista" />
                <asp:ListItem Text="Responsable Inscripto" Value="Responsable Inscripto" />
                <asp:ListItem Text="Consumidor Final" Value="Consumidor Final" />
            </asp:DropDownList>
        </div>

        <!-- Razón Social -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Razón Social:" />
            <asp:TextBox CssClass="input-text" ID="legalNameTextBox" runat="server" />
        </div>

        <!-- Inicio de Actividades -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Inicio de actividades:" />
            <asp:TextBox CssClass="input-text" ID="startOfActivitiesTextBox" runat="server" TextMode="Date" />
        </div>

        <!-- Años en el rubro -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Años en el rubro:" />
            <asp:TextBox CssClass="input-text" ID="yearsInIndustryTextBox" runat="server" />
        </div>

        <!-- Calle -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Calle:" />
            <asp:TextBox CssClass="input-text" ID="streetTextBox" runat="server" />
        </div>

        <!-- Ciudad -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Ciudad:" />
            <asp:TextBox CssClass="input-text" ID="cityTextBox" runat="server" />
        </div>

        <!-- Provincia -->
        <div>
            <asp:Label CssClass="label-text" runat="server" Text="Provincia:" />
            <asp:TextBox CssClass="input-text" ID="stateTextBox" runat="server" />
        </div>

        <!-- Botones -->
        <div class="flex justify-center gap-4 pt-4">
            <asp:Button CssClass="bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg"
                ID="btnSave" runat="server" Text="💾 Guardar cambios" OnClick="btnSave_Click" />
            <asp:Button CssClass="bg-gray-400 hover:bg-gray-500 text-white font-semibold py-2 px-6 rounded-lg"
                ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" CausesValidation="False" />
        </div>

        <asp:Label CssClass="block text-center mt-4 font-semibold text-green-600" ID="lblMsg" runat="server" />
    </div>
</asp:Content>
