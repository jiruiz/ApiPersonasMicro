<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="BusinessList.aspx.cs"
    Inherits="ManageBusinessFront.Business.BusinessList"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>📊 Listado de Negocios</h2>
    <br />
    <br />
    <div style="max-width: 1000px; margin: 0 auto;">
        <asp:GridView ID="gvBusiness" runat="server" AutoGenerateColumns="False"
            CssClass="min-w-full table-auto border-collapse text-sm text-gray-800"
            HeaderStyle-BackColor="#1e3a8a"
            HeaderStyle-ForeColor="White"
            GridLines="None"
            RowStyle-CssClass="border-b hover:bg-gray-100 transition"
            AlternatingRowStyle-CssClass="bg-gray-50"
            OnRowCommand="gvBusiness_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Name" HeaderText="Nombre" />
                <asp:BoundField DataField="Industry" HeaderText="Rubro" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Correo" />
                <asp:BoundField DataField="TaxId" HeaderText="CUIT" />
                <asp:BoundField DataField="VATStatus" HeaderText="Condición IVA" />
                <asp:BoundField DataField="LegalName" HeaderText="Razón Social" />
                <asp:BoundField DataField="StartOfActivities" HeaderText="Inicio Actividades" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="YearsInIndustry" HeaderText="Antigüedad" />
                <asp:BoundField DataField="Street" HeaderText="Calle" />
                <asp:BoundField DataField="City" HeaderText="Localidad" />
                <asp:BoundField DataField="State" HeaderText="Provincia" />

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
                                CommandArgument='<%# Eval("Id") %>'
                                OnClientClick="return confirm('¿Seguro que deseas eliminar este empleado?');" />

                            <asp:Button ID="btnEmployees" runat="server" Text="👨‍🦳 ver empleados"
                                CssClass="bg-blue-600 hover:bg-blue-700 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                CommandName="GoToEmployees"
                                CommandArgument='<%# Eval("Id") %>' />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

