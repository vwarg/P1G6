<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

            <h2>Veckans erbjudanden</h2>
            <div class="containerFourItems">
                <div class="productBox">
                    <img src="img/products/ballpoint_pen.png" alt="" />
                    <p class="productName">Pilot Vega Gel (50-pack)</p>
                    <p class="productPrice">729,90:-</p>
                    <form>
                        <select name="variation" disabled>
                            <option selected="selected" disabled>...</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/binder.png" alt="" />
                    <p class="productName">Pärmar - Blandade färger</p>
                    <p class="productPrice">9,90:-</p>
                    <form>
                        <select name="variation" required>
                            <option selected="selected" disabled>Välj färg</option>
                            <option value="red">Röd</option>
                            <option value="blue">Blå</option>
                            <option value="green">Grön</option>
                            <option value="purple">Lila</option>
                            <option value="orblue">Organgeblåafärgen</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/binder_deluxe.png" alt="" />
                    <p class="productName">Pärmar deluxe 40x30 cm</p>
                    <p class="productPrice">19,90:-</p>
                    <form>
                        <select name="variation" required>
                            <option selected="selected" disabled>Välj storlek</option>
                            <option value="size4030">40 x 30 (cm)</option>
                            <option value="size3025">30 x 25 (cm)</option>
                            <option value="size2015">20 x 15 (cm)</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/calculator.png" alt="" />
                    <p class="productName">Casio Miniräknare</p>
                    <p class="productPrice">49,90:-</p>
                    <form>
                        <select name="variation" required>
                            <option selected="selected" disabled>Välj typ</option>
                            <option value="simple">Enkel</option>
                            <option value="advance">Mer avancerad</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
            </div>
            <h2>Populära produkter</h2>
            <div class="containerFourItems">
                <div class="productBox">
                    <img src="img/products/clamp_remover.png" alt="" />
                    <p class="productName">Klämborttagare</p>
                    <p class="productPrice">39,90:-</p>
                    <form>
                        <select name="variation" disabled>
                            <option selected="selected" disabled>...</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/colored_pens.png" alt="" />
                    <p class="productName">Färgpennor (20-pack)</p>
                    <p class="productPrice">39,90:-</p>
                    <form>
                        <select name="variation" disabled>
                            <option selected="selected" disabled>...</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/paperclips.png" alt="" />
                    <p class="productName">Gem - blandade färger (500-pack)</p>
                    <p class="productPrice">9,90:-</p>
                    <form>
                        <select name="variation" disabled>
                            <option selected="selected" disabled>...</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
                <div class="productBox">
                    <img src="img/products/pens.png" alt="" />
                    <p class="productName">Stiftpennor (50-pack)</p>
                    <p class="productPrice">329,90:-</p>
                    <form>
                        <select name="variation" disabled>
                            <option selected="selected" disabled>...</option>
                        </select>
                        <input type="submit" name="addToCart" value="+" />
                    </form>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
