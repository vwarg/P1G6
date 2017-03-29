function IsLoggedIn(callbackOnFail) {
    $.get("/_services/User/VerifyUser").done(function (data) {
        LoginSuccessful();
        console.log("DITT ID ÄR " + data);
        GetCart();
    }).fail(function () {
        callbackOnFail();
    });
}

//posta till RegisterUser se att allt är bra och attt det inte finns något skräp
////om allt går bra kör isloggedin



function LoginAttempt(email, password) {
    console.log("fick in " + email + " & " + password);
    IsLoggedIn(function () {
        var jqxhr = $.post("/_services/Login/TryLogin", { email: email, password: password })
              .done(function () {
                  IsLoggedIn(function () { console.log("Mistakes were made."); });
                  $('#overlayLogin').stop().fadeToggle();
              })
              .fail(function () {
                  LoginFailed();
              });
    });
}

function AddUserInfo(firstname, lastname, phone, companyname, adressID) {
    console.log("fick in " + firstname + " & " + lastname + " & " + phone + " & " + companyname);
    var jqau = $.post("/_services/User/AddUserInfo", { firstname: firstname, lastname: lastname, phone: phone, companyname: companyname, billingadressID: adressID, deliveryadressID: adressID })
              .done(function (data) {
                  RegisterUser($("#email").val(), $("#password").val(), parseInt(data));
              })
              .fail(function () {
                  LoginFailed();
              });
}
function registerButtonClick() {
    AddAdress($("#country").val(), $("#city").val(), $("#street").val(), $("#zip").val(), $("#phone").val(), $("#department").val());
}
function AddAdress(country, city, street, zip, phone, department) {
    console.log("fick in " + country + " & " + city + " & " + street + " & " + zip + " & " + phone + " & " + department);
    var jqaa = $.post("/_services/User/AddAdress", { country: country, city: city, street: street, zip: zip, phone: phone, department: department })
          .done(function (data) {
              AddUserInfo($("#firstname").val(), $("#lastname").val(), $("#phone").val(), $("#companyname").val(), parseInt(data));
          })
          .fail(function () {
              LoginFailed();
          });
}

function RegisterUser(email, password, contactInfo) {
    console.log("fick in " + email + " & " + password + " & " + contactInfo);
    var jqru = $.post("/_services/User/RegisterUser", { email: email, password: password, contactInfo: contactInfo })
          .done(function () {
              //IsLoggedIn(function () { console.log("Något hände"); });
              $('#overlayLogin').stop().fadeToggle();
          })
          .fail(function () {
              LoginFailed();
          });
}


function LoginSuccessful() {
    //$("#result").text("Successful.");
    console.log("ALLT GICK BRA!!");

    $('body').css('overflowY', 'auto');
    $('#loginButton p').text("Mitt konto");
    $('#loginButton').on('click', function () {
        $('#overlayTextBox form').hide();
        $('#addContactInfo').slideToggle();
        $('#overlayTextBox p').hide();
    });
}

function LoginFailed() {
    //$("#result").text("Failed.");
    alert("NÅT GICK FEL!!! :(");
}

//function Fields() {
//    //$("#result").text("Successful.");
//    console.log("ALLT GICK BRA!!");

//    $('body').css('overflowY', 'auto');
//    $('#toggleRegister').on('click', function () {
//        $('#overlayTextBox form').hide();
//        $('#addContactInfo').slideToggle();
//        $('#overlayTextBox p').hide();
//    });
//}