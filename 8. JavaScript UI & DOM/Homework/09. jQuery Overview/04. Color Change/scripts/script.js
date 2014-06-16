
window.onload = function(){
    $('#change-color-btn').first().on('click', function() {
        var color = $('#background-color-picker').val();
        $('body').first().css('background-color', color);
    });
};