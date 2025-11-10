<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="EmployeesList.aspx.cs"
    Inherits="ManageBusinessFront.Employees.EmployeesList"
    MasterPageFile="~/Site1.Master" %>
<%@ Register Src="~/Common/ConfirmDeleteModal.ascx" TagPrefix="uc" TagName="ConfirmDeleteModal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ConfirmDeleteModal ID="ConfirmDeleteModal1" runat="server" />

    <!-- titulo -->
<h1 class="text-3xl font-bold text-gray-800 mb-6 text-center">
    Listado de empleados del negocio <span class="text-blue-600"><%= ViewState["BusinessName"] ?? "Negocio de Test" %></span>
</h1>


    <!-- boton dar de alta -->
    <div class="text-center mb-6">
        <asp:Button ID="btnAddEmployee" runat="server" Text="➕ Dar de alta empleado"
            CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-6 py-2 rounded-lg shadow-md transition-all duration-200 hover:scale-105"
            OnClick="btnAddEmployee_Click" />
    </div>

    <!-- tabla -->
    <div class="overflow-x-auto shadow-lg rounded-lg border border-gray-200 max-w-6xl mx-auto bg-white">
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False"
            CssClass="min-w-full table-auto border-collapse text-sm text-gray-800"
            HeaderStyle-BackColor="#1e3a8a"
            HeaderStyle-ForeColor="White"
            GridLines="None"
            RowStyle-CssClass="border-b hover:bg-gray-100 transition"
            AlternatingRowStyle-CssClass="bg-gray-50"
            OnRowCommand="gvEmployees_RowCommand">

            <Columns>
                <asp:BoundField DataField="EmployeeCode" HeaderText="Código" />
                <asp:BoundField DataField="FirstName" HeaderText="Nombre" />
                <asp:BoundField DataField="LastName" HeaderText="Apellido" />
                <asp:BoundField DataField="Departament" HeaderText="Sector" />
                <asp:BoundField DataField="Range" HeaderText="Rango" />
                <asp:BoundField DataField="HireDate" HeaderText="F. Contratación" />
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:BoundField DataField="Phone" HeaderText="Teléfono" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <div class="flex space-x-2">
                            <asp:Button ID="btnEdit" runat="server" Text="✏️ Editar"
                                CssClass="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                CommandName="EditRow"
                                CommandArgument='<%# Eval("Id") %>' />

                            <asp:Button ID="btnDelete" runat="server" Text="🗑️ Eliminar"
                                CssClass="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                CommandName="DeleteRow"
                                OnClientClick='<%# "showDeleteModal(\"" + Eval("Id") + "\"); return false;" %>' />

                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
    </div>
    <script>
        function showDeleteModal(id) {
        var hiddenField = document.getElementById('<%= ConfirmDeleteModal1.FindControl("hfObjectId").ClientID %>');
            hiddenField.value = id;
            $('#confirmModal').modal('show');
        }
    </script>

</asp:Content>




