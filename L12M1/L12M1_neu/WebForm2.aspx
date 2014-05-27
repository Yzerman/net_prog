<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="L12M1_neu.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:TextBox ID="txtBox" runat="server"></asp:TextBox>
     <asp:RequiredFieldValidator ID="ReqFValidator" runat="server"
        ErrorMessage="Mandatory field" ControlToValidate="txtBox" 
        ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
    <asp:Button ID="btn" runat="server" Text="submit" OnClick="btn_Click" />
</asp:Content>
