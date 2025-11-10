<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="CreateEmployee.aspx.cs"
    Inherits="ManageBusinessFront.Employees.CreateEmployee"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="max-w-lg mx-auto mt-10 bg-white shadow-lg rounded-2xl p-8">
        <h2 class="text-2xl font-bold text-blue-700 mb-6 text-center">
            👤 Alta de Empleado
        </h2>

        <!-- Nombre -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtFirst" Text="Nombre:" CssClass="block font-medium text-gray-700 mb-1" />
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
            <asp:Label runat="server" AssociatedControlID="txtLast" Text="Apellido:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtLast" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqLast" runat="server"
                ControlToValidate="txtLast" ErrorMessage="El apellido es obligatorio."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

    <!-- Documento -->
    <div class="mb-4">
        <asp:Label runat="server" AssociatedControlID="txtDocument" Text="Nro Documento:"
            CssClass="block font-medium text-gray-700 mb-1" />

        <asp:TextBox ID="txtDocument" runat="server"
            MaxLength="8"
            CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        <!-- Campo obligatorio -->
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="txtDocument"
            ErrorMessage="El documento es obligatorio."
            CssClass="text-red-600 text-sm"
            Display="Dynamic" />
        <!-- Solo num y max 8 -->
        <asp:RegularExpressionValidator ID="RegexValidator1" runat="server"
            ControlToValidate="txtDocument"
            ValidationExpression="^\d{1,8}$"
            ErrorMessage="El documento solo debe contener numero y no debe superar los 8 digitos."
            CssClass="text-red-600 text-sm"
            Display="Dynamic" />
    </div>


        <!-- Email -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtEmail" Text="Correo electrónico:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtEmail" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqEmail" runat="server"
                ControlToValidate="txtEmail" ErrorMessage="El correo es obligatorio."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="valEmail" runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="⚠️ Formato de correo inválido."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Teléfono -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtPhone" Text="Teléfono:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtPhone" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RegularExpressionValidator ID="valPhone" runat="server"
                ControlToValidate="txtPhone" ValidationExpression="^\d{7,15}$"
                ErrorMessage="Ingrese solo números (7 a 15 dígitos)."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Fecha de Nacimiento -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtBirth" Text="Fecha de nacimiento (dd/MM/yyyy):"
                CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtBirth" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
            <asp:RequiredFieldValidator ID="reqBirth" runat="server"
                ControlToValidate="txtBirth"
                ErrorMessage="La fecha de nacimiento es obligatoria."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
    
            <!-- Validación formato dd/MM/yyyy -->
            <asp:RegularExpressionValidator ID="valBirth" runat="server"
                ControlToValidate="txtBirth"
                ValidationExpression="^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[0-9]{4}$"
                ErrorMessage="Formato de fecha inválido. Tiene que ser dd/MM/yyyy (ej: 25/12/1995)."
                CssClass="text-red-600 text-sm" Display="Dynamic" />
        </div>

        <!-- Departamento -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtDept" Text="Departamento laboral:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtDept" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

        <!-- Rango -->
        <div class="mb-6">
            <asp:Label runat="server" AssociatedControlID="txtRange" Text="Rango laboral:" CssClass="block font-medium text-gray-700 mb-1" />
            <asp:TextBox ID="txtRange" runat="server"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
        </div>

                <!-- Fecha de contratación -->
        <div class="mb-4">
            <asp:Label runat="server" AssociatedControlID="txtHireDate" Text="Fecha de contratación (dd/MM/yyyy):"
                CssClass="block font-medium text-gray-700 mb-1" />
    
            <asp:TextBox ID="txtHireDate" runat="server"
                placeholder="Opcional - se completará automáticamente si se deja vacío"
                CssClass="w-full border border-gray-300 rounded-lg px-3 py-2 focus:outline-none focus:ring-2 focus:ring-blue-500" />
    
            <!-- Validación formato dd/MM/yyyy o vacío -->
            <asp:RegularExpressionValidator ID="valHireDate" runat="server"
                ControlToValidate="txtHireDate"
                ValidationExpression="^$|^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[0-9]{4}$"
                ErrorMessage="Formato de fecha inválido. Debe ser dd/MM/yyyy (ej: 25/12/1995). O vacio para usar la fecha actual."
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
        <asp:Label ID="lblMsg" runat="server" CssClass="block text-center mt-4 font-semibold"></asp:Label>
    </div>

</asp:Content>
