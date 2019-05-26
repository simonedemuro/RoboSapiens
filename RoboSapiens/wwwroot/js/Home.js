$(document).ready(function () {
    populateChatPreview();
    $(".msg_send_btn").click(onSendClick);
    $(".type_msg").hide();
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
        success: pcpSucceded,
        error: function (xhr) {
            window.location.href = "error.html";
            console.log("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    });
};

function populateChatWindow(chatId) {
    console.log("inside populateChatWindow");
    $.ajax({
        url: "Home/GetChatMessages?ChatId=" + chatId,
        data: "",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: pcwSucceded,
        error: function (xhr) {
            window.location.href = "error.html";
            console.log("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    })
};

function sendMessage(chatId, body, isAgent) {
    var message = {
        "ChatId": chatId,
        "Message": body,
        "IsFromAgent": isAgent
    };
    console.log("message: " + JSON.stringify(message));
    $.ajax({
        url: "Home/PutMessageIntoChat",
        contentType: "application/json",
        data: JSON.stringify(message),
        type: "PUT",
        success: function () {
            populateChatWindow(chatId);
            $(".write_msg").val("");
        },
        error: function (xhr) {
            window.location.href = "error.html";
            console.log("An error occured: " + xhr.status + " " + xhr.statusText);
        }
    })
};

var pcpSucceded = function (data) {
    //console.log("Ajax succeded");
    populatePreviewFrontEnd(data);
    $(".target").click(onChatClick);
};

var pcwSucceded = function (data) {
    //console.log("Ajax succeded");
    populateChatWindowFrontend(data);
};

var picSucceded = function () {

}

var populatePreviewFrontEnd = function (prevewList) {
    //console.log(prevewList);
    $.each(prevewList, function (key, value) {
        renderChatPreviewDiv(value);
    })
};

var renderChatPreviewDiv = function (preview) {
    var previewHtml = "<div class=\"chat_list target\" data-conversation-id=" + preview.chatID + ">" +
        "<div class=\"chat_people\">" +
            "<div class=\"chat_img\"><img src=\"https://ptetutorials.com/images/user-profile.png\" alt=\"img\"></img></div>" +
                "<div class=\"chat_ib\">" +
                    "<h5 class=\"chat_username\">"+preview.username+"<span class=\"chat_date\">" + preview.lastMessageDate + "</span></h5>" +
                        "<p class=\"last_chat_message\">"+ preview.previewMessage + "</p></h5></div></div></div>";
    $(".inbox_chat").append(previewHtml);
};

var populateChatWindowFrontend = function (messageList) {
    //console.log(messageList);
    $(".msg_history").empty();
    $(".type_msg").show();
    $.each(messageList, function (key, value) {
        renderChatWindowDiv(value);
    })
    $(".msg_history").animate({
        scrollTop: $(document).height()
    }, 0);
};

var renderChatWindowDiv = function (message) {
    console.log(message);
    var messageHtml = "<div class=\"" + message.cssSelector1 + "\">";
    if (message.cssSelector1 == "incoming_msg") {
        messageHtml += "<div class=\"incoming_msg_img\"> <img src=\"https://ptetutorials.com/images/user-profile.png\" alt=\"img\"> </div>";
        messageHtml += "<div class=\"" + message.cssSelector2 + "\">";
        messageHtml += "<div class=\"received_withd_msg\">";
        messageHtml += "<p>" + message.messageBody + "</p></div>";
    }

    else {
        messageHtml += "<div class=\"" + message.cssSelector2 + "\">";
        messageHtml += "<p>" + message.messageBody + "</p>";
    }
    messageHtml += "<span class=\"time_date\">" + message.messageTime + "    |    " + message.messageDate + "</span></div>";
    messageHtml += "</div></div></div>";
    $(".msg_history").append(messageHtml);
}

var onChatClick = function () {
    var target = $(event.target);
    while (!target.hasClass("chat_list")) target = target.parent();
    var chatId = target.attr("data-conversation-id");
    $(".chat_list").removeClass("active_chat");
    target.toggleClass("active_chat");
    populateChatWindow(chatId);
}

var onSendClick = function () {
    var chatId = $(".active_chat").attr("data-conversation-id");
    var text = $(".write_msg").val();
    if (text != "") {
        sendMessage(chatId, text, true);
    }
}