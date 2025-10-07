<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="EmployeesList.aspx.cs"
    Inherits="ManageBusinessFront.EmployeesList"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listado de empleados</h2>   
    <br /><br /> 
    <div style="max-width: 900px; margin: 0 auto;">
        <asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False"
            CssClass="table table-striped table-bordered table-hover table-sm mt-3"
            HeaderStyle-BackColor="#343a40"
            HeaderStyle-ForeColor="White"
            GridLines="None">

            <Columns>
                <asp:BoundField DataField="EmployeeCode" HeaderText="Código de Empleado" />
                <asp:BoundField DataField="FirstName" HeaderText="Nombre" />
                <asp:BoundField DataField="LastName" HeaderText="Apellido" />
                <asp:BoundField DataField="Departament" HeaderText="Sector" />
                <asp:BoundField DataField="Range" HeaderText="Rango" />
                <asp:BoundField DataField="HireDate" HeaderText="F. Contratación" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Email" HeaderText="E-mail" />
                <asp:BoundField DataField="Phone" HeaderText="Teléfono" />
            </Columns>

        </asp:GridView>
    </div>

</asp:Content>



