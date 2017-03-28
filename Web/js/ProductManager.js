// ProductManager.js

function RenderProducts(productsArray) {
    var parent = $(".containerFourItems");
    var children = [];
    for (var i = 0; i < productsArray.length; i++) {
        if (productsArray[i].ParentProductID > 0) {
            children.push(productsArray[i]);
        }
        else {
            var imageUrl = (productsArray[i].Image ? productsArray[i].Image : "/img/products/binder.png");
            var name = productsArray[i].Name;
            var pid = productsArray[i].ID;
            var price = productsArray[i].Price.replace(",", ".");
            var divContent = '<div class="productBox" id="product_' + pid + '"><img src="' + imageUrl + '" alt="" /><p class="productName">' + name + '</p><p class="productPrice">' + parseFloat(price).toFixed(2).replace(".", ",") + ':-</p><form>';
            divContent += '<select name="variation" disabled></select><input type="button" name="addToCart" value="+" onclick="AddToCart(' + pid + ', false);" /></form></div>';
            parent.html(parent.html() + divContent);
        }
        
    }

    for (var i = 0; i < children.length; i++) {
        var child = children[i];
        var parentProductDivSelect = $("#product_" + child.ParentProductID+' select[name=variation]');
        parentProductDivSelect.prop('disabled', false);
        parentProductDivSelect.html(parentProductDivSelect.html() + '<option value="'+child.ID+'">'+child.Name+'</option>');
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

function PagedGet(productsPerPage, offset) {
    var jqxhr = $.getJSON("/_services/Products/GetProducts")
      .done(function (data) {
          RenderProductsPaged(data, productsPerPage, offset);
      })
      .fail(function () {
          console.log("OOPS! (PagedGet("+productsPerPage+", "+offset+"))");
      });
}

function RenderProductsPaged(productsArray, perPage, offset) {
    var children = [];
    var parent = $(".containerFourItems");
    for (var i = offset; i < Math.min(offset + perPage, productsArray.length) ; i++) {
        if (productsArray[i].ParentProductID > 0) {
            children.push(productsArray[i]);
        }
        var imageUrl = (productsArray[i].Image ? productsArray[i].Image : "/img/products/binder.png");
        var name = productsArray[i].Name;
        var pid = productsArray[i].ID;
        var price = productsArray[i].Price.replace(",", ".");
        var divContent = '<div class="productBox"><img src="' + imageUrl + '" alt="" /><p class="productName">' + name + '</p><p class="productPrice">' + parseFloat(price).toFixed(2).replace(".", ",") + ':-</p><form>';
        divContent += '<select name="variation" disabled><option selected="selected" disabled>...</option></select><input type="button" name="addToCart" value="+" onclick="AddToCart('+pid+', '+', false);" /></form></div>';
        parent.html(parent.html() + divContent);
    }
    for (var i = 0; i < children.length; i++) {
        var child = children[i];
        var parentProductDivSelect = $("#product_" + child.ParentProductID + ' select[name=variation]');
        parentProductDivSelect.prop('disabled', false);
        parentProductDivSelect.html(parentProductDivSelect.html() + '<option value="' + child.ID + '">' + child.Name + '</option>');
    }
}

function AddToCart(pid, decrease) {
    var q = 1;
    if (decrease) {
        q = -1;
    }
    var selectedVariation = $("#product_" + pid + ' select[name=variation]').val();
    if (!selectedVariation) {
        selectedVariation = pid;
    }
    var jqxhr = $.post("/_services/Order/AddProductToOrder", {productID: pid, variation: selectedVariation, quantity: q})
      .done(function () {
          //TODO
          console.log("YAY");
      })
      .fail(function () {
          console.log("OOPS! (AddToCart("+pid+", "+selectedVariation+", "+decrease+"))");
      });
}


