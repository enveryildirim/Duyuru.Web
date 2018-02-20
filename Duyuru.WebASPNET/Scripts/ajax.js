/// <reference path="jquery-1.9.1.js" />


var myVar = setInterval(ShowCurrentTime, 500);
function YemekciGetir() {
    $.ajax({
        type: "POST",
        url: "Default.aspx/YemekcileriGetir",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: YemekciOnSuccess,
        failure: function (response) {
            alert(response.d);
        }
    });
}
function YemekciOnSuccess(response) {
    document.getElementById("yemekciler").innerHTML = response.d;
}