$(document).ready(function () {
    populateChatPreview();
});


function populateChatPreview() {
    console.log("inside populateChatPreview");
    //StartLoading();
    $.ajax({
        url: "/Home/GetConversationPreview",
        data: "",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: wsSucceded,
        error: function (xhr) {
            window.location.href = "error.html";
            console.log("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    });
}
var wsSucceded = function (data) {
    console.log("Ajax succeded");
    populateFrontEnd(data);
};
var populateFrontEnd = function (data) {
    console.log(data);
    console.log(data[0].chatTitle);
    $("#exampleParag").html(data[0].chatTitle);
};