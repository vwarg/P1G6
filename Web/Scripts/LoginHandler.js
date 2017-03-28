function LoginAttempt(email, password) {
    console.log("fick in " + email + " & " + password);
    IsLoggedin(function () {
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
function IsLoggedIn(callbackOnFail) {
    $.get("/_services/User/VerifyUser").done(function (data) {
        LoginSuccessful();
        console.log("DITT ID ÄR " + data);
    }).fail(function () {
        callbackOnFail();
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