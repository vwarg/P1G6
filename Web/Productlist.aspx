<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productlist.aspx.cs" Inherits="Web.Productlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="js/ProductManager.js"></script>
    <script>
        setTimeout(GetProducts, 500);
    </script>
    <div class="containerFourItems">
    </div>
</asp:Content>
