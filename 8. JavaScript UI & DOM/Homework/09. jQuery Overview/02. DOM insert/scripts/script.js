window.onload = function() {
    var text = $('#text-input').first().value;

    $('#insert-before-button').first().on('click', insertBefore);
    $('#insert-after-button').first().on('click', insertAfter);

};

function insertBefore(){
    $('<div/>').append($('#text-input').val()).insertBefore('#input');
}

function insertAfter (){
    $('<div/>').append($('#text-input').val()).insertAfter('#input');
}