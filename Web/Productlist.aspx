<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productlist.aspx.cs" Inherits="Web.Productlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="js/ProductManager.js"></script>
    <script>
        setTimeout(GetProducts, 500);
    </script>
    <main>
        <div id="mainContent">
            <h2>Produkter</h2>

            <div class="containerFourItems"></div>
        </div>

    </main>
</asp:Content>
