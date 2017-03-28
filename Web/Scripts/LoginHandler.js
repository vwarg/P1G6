function IsLoggedIn(callbackOnFail) {
    $.get("/_services/User/VerifyUser").done(function (data) {
        LoginSuccessful();
        console.log("DITT ID ÄR " + data);
    }).fail(function () {
        callbackOnFail();
    });
}

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
function AddUserInfo(firstname, lastname, phone, companyname) {
    console.log("fick in " + firstname + " & " + lastname + " & " + phone + " & " + companyname);
    IsLoggedin(function () {
        var jqau = $.post("/_services/Login/AddUserInfo", { email: firstname, password: password })
              .done(function () {
                  IsLoggedIn(function () { console.log("Mistakes were made."); });
                  $('#overlayLogin').stop().fadeToggle();
              })
              .fail(function () {
                  LoginFailed();
              });
    });
}

function AddAdress(country, city, street, zip, phone, department) {
    console.log("fick in " + country + " & " + city + " & " + street + " & " + zip + " & " + phone + " & " + department);
    IsLoggedin(function () {
        var jqaa = $.post("/_services/Login/AddAdress", { country: country, city: city, street: street, zip: zip, phone: phone, department: department})
              .done(function () {
                  IsLoggedIn(function () { console.log("Mistakes were made."); });
                  $('#overlayLogin').stop().fadeToggle();
              })
              .fail(function () {
                  LoginFailed();
              });
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