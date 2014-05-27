<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="L12M1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="ReqFValidator" runat="server"
        ErrorMessage="Mandatory field" ControlToValidate="txtBox" 
        ForeColor="Red" SetFocusOnError="true"></asp:RequiredFieldValidator>
    <asp:Button ID="btn" runat="server" OnClick="btn_Click" />
</asp:Content>
