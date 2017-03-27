function LoginAttempt() {


    var jqxhr = $.post("/_services/Login/TryLogin", { email: "toast@email.com", password: "PASSWO" })
      .done(function () {
          $.get("/_services/User/VerifyUser", function (data) {
              $("#extra").text("ID: "+data);
          });
          LoginSuccessful();
      })
      .fail(function () {
          LoginFailed();
      });
}

function LoginSuccessful() {
    $("#result").text("Successful.");
}
function LoginFailed() {
    $("#result").text("Failed.");
}