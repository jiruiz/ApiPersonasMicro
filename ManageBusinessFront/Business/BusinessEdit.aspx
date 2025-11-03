<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="BusinessEdit.aspx.cs" Inherits="ManageBusinessFront.Business.BusinessEdit"
    MasterPageFile="~/Site1.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h4>Edit Business</h4>
    <div class="mb-2">
        <asp:Label ID="idLabel" runat="server" Text="ID:" Visible="false"></asp:Label>
        <asp:TextBox ID="idTextBox" runat="server" Visible="false"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="nameLabel" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="industryLabel" runat="server" Text="Industry:"></asp:Label>
        <asp:TextBox ID="industryTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="phoneNumberLabel" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="phoneNumberTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="taxIdLabel" runat="server" Text="Taax ID (CUIT):"></asp:Label>
        <asp:TextBox ID="taxIdTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="VATStatusLabel" runat="server" Text="Condicion IVA:"></asp:Label>
        <asp:TextBox ID="VATStatusTextBox" runat="server"></asp:TextBox>
        <br />
        <br />


        <asp:Label ID="legalNameLabel" runat="server" Text="Legal Name (Razon Social):"></asp:Label>
        <asp:TextBox ID="legalNameTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="startOfActivitiesLabel" runat="server" Text="Start Of Activities:" AutoPostBack="true"></asp:Label>
        <asp:Calendar ID="startOfActivitiesCalendar" runat="server"></asp:Calendar>
        <br />
        <br />


        <asp:Label ID="yearsInIndustryLabel" runat="server" Text="Years In Industry:"></asp:Label>
        <asp:TextBox ID="yearsInIndustryTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="streetLabel" runat="server" Text="Street:"></asp:Label>
        <asp:TextBox ID="streetTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="cityLabel" runat="server" Text="City:"></asp:Label>
        <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
        <br />
        <br />

        <asp:Label ID="stateLabel" runat="server" Text="State:"></asp:Label>
        <asp:TextBox ID="stateTextBox" runat="server"></asp:TextBox>

        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary"
            OnClick="btnSave_Click" />
        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancelar" CssClass="btn btn-secondary ms-2"
            OnClick="btnCancel_Click" />
        <br />
        <br />
        <asp:Label ID="lblMsg" runat="server" />
    </div>
</asp:Content>
