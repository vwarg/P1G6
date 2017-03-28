$(document).ready(function () {
    // Internal anchor scroll
    $('a[href^=\\#]:not([href=\\#])').on('click', function () {
        var element = $($(this).attr('href'));
        $('html,body').animate({ scrollTop: element.offset().top - 40 }, 'normal', 'swing');
        return false;
    });
    // END Internal anchor


	// Login show/hide
	$('#loginButton').on('click', function(){
		// Hide scrollbar when overlay is active
		$('body').css('overflowY', 'hidden');
		$('#overlayLogin').stop().fadeToggle();
	});
	$('#closeLogin').on('click', function(){
		$('body').css('overflowY', 'auto');
		$('#overlayLogin').stop().fadeToggle();
	});
	$('#addContactInfo').hide();
	
	// Order history show/hide
	// TODO man ska kunna klicka på "login-knappen" när man är inloggad för att se ordrar
	$('nav a').on('click', function(){
		$('body').css('overflowY', 'hidden');
		$('#overlayOrders').stop().fadeToggle();
	});
	$('#closeOrders').on('click', function(){
		$('body').css('overflowY', 'auto');
		$('#overlayOrders').stop().fadeToggle();
	});
	$('.orderBox').on('click', function(){
		if($(this).attr("id") != 'orderHeader'){
			var orderNumber = $(this).children().children().html();
			$('#overlayOrdersBox h2').append(" - "+orderNumber);
			$('#orders').html('');
				/*
				// Loopa genom alla artiklar i ordern
				<div class="cartArticle">
					<div class="cartProdImg">
						<img src="img/products/paperclips.png" alt="Paperclips" />
					</div>
					<div class="cartProdDesc">
						Gem - blandade färger (500-pack)
						<span></span>
					</div>
					<div class="cartProdQuanBox">
						<div class="cartDecreaseQuan">-</div>
						<input type="text" maxlength="3" value="1" class="cartProdQuan" />
						<div class="cartIncreaseQuan">+</div>
						<div class="cartTrashItem"></div>
					</div>
					<div class="cartProdPriceTotalBox">
						<p class="cartProdPriceTotal">9,90</p>
						<span class="cartProdPriceDiscount"></span>
					</div>
				</div>
				
				// Endast en <hr> om vi byter varutyp - tänk att två pärmar av samma typ, men olika färger, skall vara grupperade
				<hr class="overlayLine" />
				*/
				
				/*
				
				<div id="cartSumBox">
					<div id="cartSum">
						<span>Summa:</span>
						<span id="cartSumValue"></span>
					</div>
					<hr />
					<div id="cartDiscount">
						<span>Total rabatt:</span>
						<span id="cartDiscountValue"></span>
					</div>
					<hr />
					<div id="cartTax">
						<span>Moms:</span>
						<span id="cartTaxValue"></span>
					</div>
					<hr />
					<div id="cartRoundedTotal">
						<span>Öresavrundning:</span>
						<span id="cartRoundedTotalValue"></span>
					</div>
					<hr />
					<div id="cartDeliveryCost">
						<span>Fraktkostand:</span>
						49,00
					</div>
					<hr />
					<div id="cartTotal">
						<span>Totalbelopp:</span>
						<span id="cartTotalValue"></span>
					</div>
				</div>
				
				*/
		}
	});
	
	
	// Cart show/hide
	$('#mainCart').on('click', function(){
		// Hide scrollbar when overlat is active
		CalculateCartTotal();
		$('body').css('overflowY', 'hidden');
		$('#overlayCart').stop().fadeToggle();
	});
	$('#closeCart').on('click', function(){
		$('body').css('overflowY', 'auto');
		$('#overlayCart').stop().fadeToggle();
	});
	
	
	$('#cartEmptyCart').on('click', function(){
		// Töm varukorgen - ge en varning först???
	});
	$('.cartTrashItem').on('click', function(){
		 // $(this). ta bort vara från kundkorgen
	});
	
    /* Visa kontaktinfo - fälten bör vara förifyllda om användaren gjort en tidigare beställnin/registrerat uppgifterna */
	$('#cartProceed').on('click', function () {
	    $('#orderContactInfo').show();
	    $('#cartFix').animate({ scrollTop: $('#orderContactInfo').position().top - 40 }, 500);
	});

	$('#copyDeliveryAdress').on('click', function () {
	    $(this).toggleClass('copyDeliveryAdressChecked');
	    $('#billingAdressBox').slideToggle();
	    $('#cartFix').animate({ scrollTop: $('#billingAdressBox').position().top - 40 }, 500);
	});
	
	// Calculate cart sum
	function CalculateCartTotal(){
		var total = 0;
		$('.cartProdPriceTotal').each(function(){
			total += parseFloat($(this).html().replace(',', '.'));
		});
		$('#cartSumValue').html(total.toFixed(2).replace('.', ','));
		
		var totalDisc = 0;
		$('.cartProdPriceDiscount').each(function(){
			if($(this).html() != ""){
				totalDisc += parseFloat($(this).html().replace(',', '.'));
			}
		});
		$('#cartDiscountValue').html(totalDisc.toFixed(2).replace('.', ','));
		
		var totalWithDiscount = total + totalDisc;

		var tax = totalWithDiscount.toFixed(2) * 0.25;
		$('#cartTaxValue').html(tax.toFixed(2).replace('.', ','));

		totalWithDiscount = totalWithDiscount + tax;
		
		var roundIt = (totalWithDiscount - totalWithDiscount.toFixed(0)).toFixed(2);
		
		$('#cartRoundedTotalValue').html(roundIt.replace('.', ','));
		
		var finalPrice = totalWithDiscount.toFixed(2) - roundIt + 49;
		$('#cartTotalValue').html(finalPrice.toFixed(2).replace('.', ','));
	}
	
	
	
	
	// Update price if quantity of products in cart are changed
	$('.cartDecreaseQuan').on('click', function(){
		// Get current quantity
		var quantity = parseInt($(this).next().val());
		
		if(quantity > 1){
			// Get value of item by dividing product sum by number of items
			var pricePerPiece = parseFloat($(this).parent().next().children('.cartProdPriceTotal').html().replace(',', '.'));
			pricePerPiece = pricePerPiece / quantity;
			var newProdSum = (pricePerPiece * (quantity - 1)).toFixed(2);
			$(this).parent().next().children('.cartProdPriceTotal').html(newProdSum);
			
			// Do the same if a discount is in place
			var pricePerPieceDiscount = parseFloat($(this).parent().next().children('.cartProdPriceDiscount').html().replace(',', '.'));
			if(pricePerPieceDiscount < 0){
				pricePerPieceDiscount = pricePerPieceDiscount / quantity;
				var newProdDiscountSum = (pricePerPieceDiscount * (quantity - 1)).toFixed(2);
				$(this).parent().next().children('.cartProdPriceDiscount').html(newProdDiscountSum);
			}
			
			// Update quantity
			$(this).next().val(quantity - 1);
			CalculateCartTotal();
		}		
	});
	// Same as above, but product is being added
	$('.cartIncreaseQuan').on('click', function(){
		var quantity = parseInt($(this).prev().val());
		
		if(quantity < 999){
			var pricePerPiece = parseFloat($(this).parent().next().children('.cartProdPriceTotal').html().replace(',', '.'));
			pricePerPiece = pricePerPiece / quantity;
			var newProdSum = (pricePerPiece * (quantity + 1)).toFixed(2);
			$(this).parent().next().children('.cartProdPriceTotal').html(newProdSum);
			
			var pricePerPieceDiscount = parseFloat($(this).parent().next().children('.cartProdPriceDiscount').html().replace(',', '.'));
			if(pricePerPieceDiscount < 0){
				pricePerPieceDiscount = pricePerPieceDiscount / quantity;
				var newProdDiscountSum = (pricePerPieceDiscount * (quantity + 1)).toFixed(2);
				$(this).parent().next().children('.cartProdPriceDiscount').html(newProdDiscountSum);
			}
		
			$(this).prev().val(quantity + 1);
			CalculateCartTotal();
		}
	});
	
	
	// Hover effect on products
	$('.productName').hover(function(){
		$(this).prev().addClass('prodHoverColor');
	}, function(){
		$(this).prev().removeClass('prodHoverColor');
	});
	
	
	// Initiate unslider
	$('.spotlightSlider').unslider({
		autoplay: true,
		delay: 5000
	});
	
	
	// Hamburger-menu show/hide function
	$('#hamburger').on('click', function(){
		$('nav').stop().slideToggle();
	});
	// "Menu hidden on upscale"-fix
	$(window).on('resize', function(){
		var winSize = $(window).width();
		if(winSize > 768){
			$('nav').show();
		}
	});
	
	
	// Login-menu toggle
	$('#toggleLogin').on('click', function(){
		$('#overlayTextBox form').hide();
		$('#loginForm').slideToggle();
		$('#toggleForgotten').removeAttr('style');
		$('#overlayTextBox p').hide();
		$('#toggleRegister').show();
		$('#toggleForgotten').show();
	});
	$('#toggleRegister').on('click', function(){
		$('#overlayTextBox form').hide();
		$('#registerForm').slideToggle();
		$('#overlayTextBox p').hide();
		$('#toggleLogin').show();
		$('#toggleForgotten').show();
		$('#toggleForgotten').css('float', 'right');
	});
	$('#toggleForgotten').on('click', function(){
		$('#overlayTextBox form').hide();
		$('#forgottenForm').slideToggle();
		$('#toggleForgotten').removeAttr('style');
		$('#overlayTextBox p').hide();
		$('#toggleLogin').show();
		$('#toggleRegister').show();
	});
});