<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="js/ProductManager.js"></script>
    <script>
        setTimeout(GetProducts, 500);
    </script>
    <main>
        <div id="mainContent">
            <h2>Nya spännande produkter / pågående kampanjer</h2>
            <div id="sliderBox">
                <div class="spotlightSlider">
                    <ul>
                        <li>
                            <img src="img/slider/organized.jpg" alt="Organized" /></li>
                        <li>
                            <img src="img/slider/productivity.jpg" alt="Productivity" /></li>
                        <li>
                            <img src="img/slider/deluxe_pen.jpg" alt="Deluxe pen" /></li>
                    </ul>
                </div>
            </div>

            <h2>Nya produkter</h2>
            <div class="containerFourItems"></div>
            
        </div>
    </main>

</asp:Content>
