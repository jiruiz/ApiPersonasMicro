<%@ Page Title=""
    Async="true"
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="BusinessAdd.aspx.cs"
    Inherits="ManageBusinessFront.Business.BusinessAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .text-danger { color: #dc2626; font-size: 0.875rem; }
        .input-text { width:100%; padding:0.5rem; border:1px solid #d1d5db; border-radius:0.5rem; }
        .input-text:focus { outline:none; border-color:#3b82f6; box-shadow:0 0 0 1px #3b82f6; }
        .label-text { display:block; font-weight:500; color:#374151; margin-bottom:0.25rem; }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-2xl font-bold text-center text-blue-700 mb-6">🧾 Registrar Negocio</h2>

    <div class="max-w-xl mx-auto bg-white shadow-md rounded-xl p-6 space-y-4">

        <!-- Nombre -->
        <div>
            <asp:Label CssClass="label-text" ID="nameLabel" runat="server" Text="Nombre del negocio:" />
            <asp:TextBox CssClass="input-text" ID="nameTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvName" runat="server"
                ControlToValidate="nameTextBox" ErrorMessage="⚠️ El nombre es obligatorio." Display="Dynamic" />
        </div>

        <!-- Rubro -->
        <div>
            <asp:Label CssClass="label-text" ID="industryLabel" runat="server" Text="Rubro:" />
            <asp:TextBox CssClass="input-text" ID="industryTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvIndustry" runat="server"
                ControlToValidate="industryTextBox" ErrorMessage="⚠️ El rubro es obligatorio." Display="Dynamic" />
        </div>

        <!-- Teléfono -->
        <div>
            <asp:Label CssClass="label-text" ID="phoneNumberLabel" runat="server" Text="Teléfono:" />
            <asp:TextBox CssClass="input-text" ID="phoneNumberTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvPhoneNumber" runat="server"
                ControlToValidate="phoneNumberTextBox" ErrorMessage="⚠️ El teléfono es obligatorio." Display="Dynamic" />
            <asp:RegularExpressionValidator CssClass="text-danger" ID="revPhoneNumber" runat="server"
                ControlToValidate="phoneNumberTextBox" ErrorMessage="⚠️ Ingrese un número de 10 dígitos válido."
                ValidationExpression="^\d{10}$" Display="Dynamic" />
        </div>

        <!-- Email -->
        <div>
            <asp:Label CssClass="label-text" ID="emailLabel" runat="server" Text="Correo electrónico:" />
            <asp:TextBox CssClass="input-text" ID="emailTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvEmail" runat="server"
                ControlToValidate="emailTextBox" ErrorMessage="⚠️ El correo es obligatorio." Display="Dynamic" />
            <asp:RegularExpressionValidator CssClass="text-danger" ID="revEmail" runat="server"
                ControlToValidate="emailTextBox" ErrorMessage="⚠️ Formato de correo inválido."
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" Display="Dynamic" />
        </div>

        <!-- CUIT -->
        <div>
            <asp:Label CssClass="label-text" ID="taxIdLabel" runat="server" Text="CUIT:" />
            <asp:TextBox CssClass="input-text" ID="taxIdTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvTaxId" runat="server"
                ControlToValidate="taxIdTextBox" ErrorMessage="⚠️ El CUIT es obligatorio." Display="Dynamic" />
            <asp:RegularExpressionValidator CssClass="text-danger" ID="revTaxId" runat="server"
                ControlToValidate="taxIdTextBox" ErrorMessage="⚠️ El CUIT debe tener 11 dígitos."
                ValidationExpression="^\d{11}$" Display="Dynamic" />
        </div>

        <!-- Condición IVA (ComboBox) -->
        <div>
            <asp:Label CssClass="label-text" ID="VATStatusLabel" runat="server" Text="Condición frente al IVA:" />
            <asp:DropDownList ID="VATStatusDropDown" runat="server" CssClass="input-text">
                <asp:ListItem Text="-- Seleccione --" Value="" />
                <asp:ListItem Text="Monotributista" Value="Monotributista" />
                <asp:ListItem Text="Responsable Inscripto" Value="Responsable Inscripto" />
                <asp:ListItem Text="Consumidor Final" Value="Consumidor Final" />
            </asp:DropDownList>

            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvVATStatus" runat="server"
                ControlToValidate="VATStatusDropDown"
                InitialValue=""
                ErrorMessage="⚠️ Debe seleccionar una condición IVA." Display="Dynamic" />
        </div>


        <!-- Razón Social -->
        <div>
            <asp:Label CssClass="label-text" ID="legalNameLabel" runat="server" Text="Razón Social:" />
            <asp:TextBox CssClass="input-text" ID="legalNameTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvLegalName" runat="server"
                ControlToValidate="legalNameTextBox" ErrorMessage="⚠️ La razón social es obligatoria." Display="Dynamic" />
        </div>

        <!-- Inicio de Actividades (moderno con selector de fecha) -->
        <div>
            <asp:Label CssClass="label-text" ID="startOfActivitiesLabel" runat="server" Text="Inicio de actividades:" />
            <asp:TextBox ID="startOfActivitiesTextBox" runat="server" CssClass="input-text" TextMode="Date" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvStartDate" runat="server"
                ControlToValidate="startOfActivitiesTextBox"
                ErrorMessage="⚠️ La fecha de inicio es obligatoria." Display="Dynamic" />
        </div>


        <!-- Años en el rubro -->
        <div>
            <asp:Label CssClass="label-text" ID="yearsInIndustryLabel" runat="server" Text="Años en el rubro:" />
            <asp:TextBox CssClass="input-text" ID="yearsInIndustryTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvYearsInIndustry" runat="server"
                ControlToValidate="yearsInIndustryTextBox" ErrorMessage="⚠️ Este campo es obligatorio." Display="Dynamic" />
            <asp:RangeValidator CssClass="text-danger" ID="rvYearsInIndustry" runat="server"
                ControlToValidate="yearsInIndustryTextBox" ErrorMessage="⚠️ Debe ser entre 1 y 100."
                MinimumValue="1" MaximumValue="100" Type="Integer" Display="Dynamic" />
        </div>

        <!-- Calle -->
        <div>
            <asp:Label CssClass="label-text" ID="streetLabel" runat="server" Text="Calle:" />
            <asp:TextBox CssClass="input-text" ID="streetTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvStreet" runat="server"
                ControlToValidate="streetTextBox" ErrorMessage="⚠️ La calle es obligatoria." Display="Dynamic" />
        </div>

        <!-- Ciudad -->
        <div>
            <asp:Label CssClass="label-text" ID="cityLabel" runat="server" Text="Ciudad:" />
            <asp:TextBox CssClass="input-text" ID="cityTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvCity" runat="server"
                ControlToValidate="cityTextBox" ErrorMessage="⚠️ La ciudad es obligatoria." Display="Dynamic" />
        </div>

        <!-- Provincia -->
        <div>
            <asp:Label CssClass="label-text" ID="stateLabel" runat="server" Text="Provincia:" />
            <asp:TextBox CssClass="input-text" ID="stateTextBox" runat="server" />
            <asp:RequiredFieldValidator CssClass="text-danger" ID="rfvState" runat="server"
                ControlToValidate="stateTextBox" ErrorMessage="⚠️ La provincia es obligatoria." Display="Dynamic" />
        </div>

        <!-- Botones -->
        <div class="flex justify-center gap-4 pt-4">
            <asp:Button CssClass="bg-blue-600 hover:bg-blue-700 text-white font-semibold py-2 px-6 rounded-lg"
                ID="btnAddBusiness" runat="server" Text="Registrar" OnClick="btnAddBusiness_Click" />
            <asp:Button CssClass="bg-gray-400 hover:bg-gray-500 text-white font-semibold py-2 px-6 rounded-lg"
                ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" CausesValidation="False" />
        </div>

        <asp:Label CssClass="block text-center mt-4 font-semibold text-green-600" ID="lblMsg" runat="server" />
    </div>
</asp:Content>
