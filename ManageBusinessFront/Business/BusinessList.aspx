<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="BusinessList.aspx.cs"
    Inherits="ManageBusinessFront.Business.BusinessList"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-2xl font-bold text-center text-blue-700 mb-6">📊 Listado de Negocios</h2>

    <!-- botón dar de alta -->
    <div class="text-center mb-6">
        <asp:Button ID="btnAdd" runat="server" Text="➕ Dar de alta negocio"
            CssClass="bg-green-600 hover:bg-green-700 text-white font-semibold px-6 py-2 rounded-lg shadow-md transition-all duration-200 hover:scale-105"
            OnClick="btnAdd_Click" />
    </div>

    <!-- contenedor con scroll y margen -->
    <div style="overflow-x:auto; max-width:100%; padding:0 12px 12px 12px;">
        <table style="width:100%; border-collapse:collapse;">
            <tr>
                <td>
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
                                    <div style="display:flex; gap:6px; flex-wrap:nowrap;">
                                        <asp:Button ID="btnEdit" runat="server" Text="✏️ Editar"
                                            CssClass="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                            CommandName="EditRow"
                                            CommandArgument='<%# Eval("Id") %>' />

                                        <asp:Button ID="btnDelete" runat="server" Text="🗑️ Eliminar"
                                            CssClass="bg-red-600 hover:bg-red-700 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                            CommandName="DeleteRow"
                                            CommandArgument='<%# Eval("Id") %>'
                                            OnClientClick="return confirm('¿Seguro que deseas eliminar este negocio?');" />

                                        <asp:Button ID="btnEmployees" runat="server" Text="👨‍💼 Empleados"
                                            CssClass="bg-blue-600 hover:bg-blue-700 text-white px-3 py-1 rounded-md text-xs font-semibold transition"
                                            CommandName="GoToEmployees"
                                            CommandArgument='<%# Eval("Id") %>' />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
