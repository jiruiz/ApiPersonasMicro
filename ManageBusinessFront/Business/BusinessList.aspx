<%@ Page Async="true" Language="C#" AutoEventWireup="true"
    CodeBehind="BusinessList.aspx.cs"
    Inherits="ManageBusinessFront.Business.BusinessList"
    MasterPageFile="~/Site1.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>📊 Listado de Negocios</h2>
    <br />
    <br />
    <div style="max-width: 1000px; margin: 0 auto;">
        <asp:GridView ID="gvBusiness" runat="server" AutoGenerateColumns="False">
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
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

