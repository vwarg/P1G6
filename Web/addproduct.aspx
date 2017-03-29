<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addproduct.aspx.cs" Inherits="Web.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="js/ProductManager.js"></script>
    <script>
        setTimeout(___getstuff, 500);
    </script>
<main>
	<div id="mainContent">
		<div id="addProductSection">
			<h3>Lägg till ny produkt</h3>
			<form id="addProductForm">
				<input type="text" name="name" placeholder="Produktnamn" />
				<textarea name="shortDesc" placeholder="Kort produktbeskrivning"></textarea>
				<textarea name="longDesc" placeholder="Fullständig produktbeskrivning"></textarea>
				<!-- <input type="text" name="parentProduct" placeholder="Förälderprodukt" /> -->
                <select name="parentProduct" id="parentProductSelect"><option value="-1">Ingen</option></select>
				<input type="text" name="price" placeholder="Pris" />
				<input type="text" name="countPerUnit" placeholder="Antal per förpackning" />
				<input type="text" name="quantity" placeholder="Antal i lager" />
				<input type="text" name="comment" placeholder="Produktkommentar" />
				<input type="text" name="image" placeholder="Bildnamn.filformat" />
				<input type="text" name="video" placeholder="Länk till video" />
				<input type="text" name="status" placeholder="Varustatus" />
				<!-- <input type="text" name="manufacturerID" placeholder="Tillverkarens ID" /> -->
                <select name="manufacturerID" id="manufacturerIDSelect"><option value="-1">Ingen</option></select>
				<input type="text" name="manufacturerProdNum" placeholder="Tillverkarens produktnummer" />
				<!-- <input type="text" name="categoryID" placeholder="Kategorins ID" /> -->
                <select name="categoryID" id="categoryIDSelect"><option value="-1">Ingen</option></select>
				<input type="submit" name="addProduct" value="Lägg till i databasen" onclick="AddProduct" />
			</form>
		</div>
	</div>
</main>
</asp:Content>
