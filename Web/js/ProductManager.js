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
            var divContent = '<div class="productBox" id="product_' + pid + '"><img src="/img/products/' + imageUrl + '" alt="" /><p class="productName">' + name + '</p><p class="productPrice">' + parseFloat(price).toFixed(2).replace(".", ",") + ':-</p><form>';
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
              //console.log("OOPS! (GetProducts())");
          });
}

function GetProductListOnly() {
    var jqxhr = $.getJSON("/_services/Products/GetProducts")
          .done(function (data) {
              for (var i = 0; i < data.length; i++) {
                  var p = data[i];
                  var ppSel = $("#parentProductSelect");
                  var htmlString = '<option value="' + p.ID + '">' + p.Name + '</option>';
                  ppSel.html(ppSel.html() + htmlString);
              }
          })
          .fail(function () {
              //console.log("OOPS! (GetProductListOnly())");
          });
}

function GetCategoryList() {
    var jqxhr = $.getJSON("/_services/Products/GetCategories")
          .done(function (data) {
              for (var i = 0; i < data.length; i++) {
                  var c = data[i];
                  var cidSel = $("#categoryIDSelect");
                  var htmlString = '<option value="' + c.ID + '">' + c.Name + '</option>';
                  cidSel.html(cidSel.html() + htmlString);
              }
          })
          .fail(function () {
              //console.log("OOPS! (GetCategoryList())");
          });
}

function GetManufacturerList() {
    var jqxhr = $.getJSON("/_services/Products/GetManufacturers")
          .done(function (data) {
              for (var i = 0; i < data.length; i++) {
                  var m = data[i];
                  var mSel = $("#manufacturerIDSelect");
                  var htmlString = '<option value="' + m.ID + '">' + m.Name + '</option>';
                  mSel.html(mSel.html() + htmlString);
              }
          })
          .fail(function () {
              //console.log("OOPS! (GetManufacturerList())");
          });
}

function ___getstuff() {
    GetProductListOnly();
    GetManufacturerList();
    GetCategoryList();
}




function PagedGet(productsPerPage, offset) {
    var jqxhr = $.getJSON("/_services/Products/GetProducts")
      .done(function (data) {
          RenderProductsPaged(data, productsPerPage, offset);
      })
      .fail(function () {
          //console.log("OOPS! (PagedGet("+productsPerPage+", "+offset+"))");
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
        var divContent = '<div class="productBox" id="product_' + pid + '"><img src="/img/products/' + imageUrl + '" alt="" /><p class="productName">' + name + '</p><p class="productPrice">' + parseFloat(price).toFixed(2).replace(".", ",") + ':-</p><form>';
        divContent += '<select name="variation" disabled><option selected="selected" disabled>...</option></select><input type="button" name="addToCart" value="+" onclick="AddToCart('+pid+', false);" /></form></div>';
        parent.html(parent.html() + divContent);
    }
    for (var i = 0; i < children.length; i++) {
        var child = children[i];
        var parentProductDivSelect = $("#product_" + child.ParentProductID + ' select[name=variation]');
        parentProductDivSelect.prop('disabled', false);
        parentProductDivSelect.html(parentProductDivSelect.html() + '<option value="' + child.ID + '">' + child.Name + '</option>');
    }
}
var cartObj = {};
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
          if (!cartObj[pid + ""]) {
              cartObj[pid + ""] = 1;
          }
          else {
            cartObj[pid + ""] += q;
          }

          GetCart();

      })
      .fail(function () {
          //console.log("OOPS! (AddToCart("+pid+", "+selectedVariation+", "+decrease+"))");
      });
}

function AddProduct() {
    var obj = {};
    $("#addProductForm").find("input[type!=submit], textarea").each(function (i, o) {
        obj[$(o).attr("name")] = $(o).val();
    });
    var jqxhr = $.post("/_services/Product/AddProduct", obj)
      .done(function () {
          //TODO
          //console.log("YAY");
          alert("ny produkt tillagd!");
      })
      .fail(function () {
          //console.log("OOPS! (AddProduct())");
      });
}

function GetOrderList(user) {
    var params = {};
    if (user) {
        params.uid = user;
    }

    var jqxhr = $.getJSON("/_services/Products/GetOrders", params)
      .done(function (data) {
          RenderOrders(data);
      })
      .fail(function () {
          //console.log("OOPS! (GetOrderList(" + user + "))");
      });
}

function GetCart() {

    var jqxhr = $.getJSON("/_services/Order/GetCurrentOrder")
      .done(function (data) {
          $(".cartArticle").remove();
          for (var i = 0; i < data.Products.length; i++) {
              var product = data.Products[i];
              var pid = product.ID;
              if (!cartObj[pid + ""]) {
                  cartObj[pid + ""] = parseInt(product.NumberInOrder);
              }
              var cartItemHtml = '<div class="cartArticle"> \
                        <div class="cartProdImg"> \
                            <img src="/img/products/'+ product.Image + '" alt="Produkt" /> \
                        </div> \
                        <div class="cartProdDesc"> \
                            '+ product.Name + ' \
                        </div> \
                        <div class="cartProdQuanBox"> \
                            <div class="cartDecreaseQuan" onclick="AddToCart('+ pid + ', true)">-</div> \
                            <input type="text" maxlength="3" value="'+ cartObj[pid + ""] + '" class="cartProdQuan" /> \
                            <div class="cartIncreaseQuan" onclick="AddToCart(' + pid + ', false)">+</div> \
                            <div class="cartTrashItem"></div> \
                        </div> \
                        <div class="cartProdPriceTotalBox"> \
                            <p class="cartProdPriceTotal">'+ parseFloat(product.Price).toFixed(2) + '</p> \
                            <span class="cartProdPriceDiscount"></span> \
                        </div> \
                    </div><hr class="overlayLine" />';
              //$("#overlayCartBox").append
              $(cartItemHtml).insertBefore("#cartSumBox");
          }
          /*
           */
      })
      .fail(function () {
          console.log("OOPS! (GetCart())");
      });
    
}

function RenderOrders(orderArray) {
    var hdr = $("#orderHeader");
    for (var i = 0; i < orderArray.length; i++) {
        var order = orderArray[i];
        var htmlStr = '<hr class="overlayLine" />\
                <div class="orderBox"> \
					<div class="orderNumber"> \
						<p>'+ order.ID + '</p> \
					</div> \
					<div class="orderDate"> \
						<p>'+ order.DateCreated + '</p> \
					</div> \
					<div class="orderItems"> \
						<p>'+ order.NumProducts + '</p> \
					</div> \
					<div class="orderTotal"> \
						<p>'+ order.TotalPrice + 'p</p> \
					</div> \
					<div class="orderStatus"> \
						<p>'+ order.Status + '</p> \
					</div> \
				</div>';
        hdr.parent().append(htmlStr);
    }
}

function GetProductsInOrder(orderId) {
    var jqxhr = $.getJSON("/_services/Order/GetProductsInOrder", { oid: oid })
          .done(function (data) {
              RenderProducts(data);
          })
          .fail(function () {
              //console.log("OOPS! (GetProductsInOrder("+orderId+"))");
          });
}


