// ProductManager.js

function RenderProducts(productsArray) {
    var parent = $(".containerFourItems");
    for (var i = 0; i < productsArray.length; i++) {
        var imageUrl = (productsArray[i].Image ? productsArray[i].Image : "/img/products/binder.png");
        var name = productsArray[i].Name;
        var price = productsArray[i].Price.replace(",", ".");
        var divContent = '<div class="productBox"><img src="' + imageUrl + '" alt="" /><p class="productName">' + name + '</p><p class="productPrice">' + parseFloat(price).toFixed(2).replace(".", ",") + ':-</p><form>';
        divContent += '<select name="variation" disabled><option selected="selected" disabled>...</option></select><input type="submit" name="addToCart" value="+" /></form></div>';
        parent.html(parent.html() + divContent);
    }
}

function GetProducts() {
    var jqxhr = $.getJSON("/_services/Products/GetProducts")
          .done(function (data) {
              RenderProducts(data);
          })
          .fail(function () {
              console.log("OOPS! (GetProducts())");
          });
}


/*
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
                */