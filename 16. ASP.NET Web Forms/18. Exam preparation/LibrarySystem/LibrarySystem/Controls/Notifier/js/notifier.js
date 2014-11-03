
if (typeof (jQuery) == 'undefined') {
    console.log("Please add jQuery first");
}

$(document).ready(function () {
    $('.PanelNotificationBox').css({ opacity: 0 });
    $('.PanelNotificationBox').fadeTo("slow", 1.0);
    setTimeout(function () {
        $('.AutoHide').fadeOut('slow', function () {
            $('.AutoHide').remove();
        });
    }, 2000);
});