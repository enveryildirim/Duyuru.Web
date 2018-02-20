<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Deneme.aspx.cs" Inherits="Duyuru.WebASPNET.Deneme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.9.1.js"></script>
     <script type = "text/javascript">
         var myVar = setInterval(ShowCurrentTime, 500);
         function ShowCurrentTime() {
             $.ajax({
                 type: "POST",
                 url: "Deneme.aspx/GetCurrentTime",
                 data: '{}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: OnSuccess,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
}
function OnSuccess(response) {
    document.getElementById("result").innerHTML=response.d;
}




</script>

</head>
<body>
    
        <div>
            {name: "' + $("#txt").value + '" }
        Your Name :
            <input id="txt" type="text" value="enver" />
        <input id="btnGetTime" type="button" value="Show Current Time" onclick="ShowCurrentTime()" />
            <div id="result"></div>
        </div>

    <p>A script on this page starts this clock:</p>
<p id="demo"></p>
    <form id="form1" runat="server">
    <div>
    

    </div>
    </form>
</body>
</html>
