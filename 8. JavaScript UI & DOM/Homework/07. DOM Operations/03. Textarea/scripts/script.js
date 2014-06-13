window.onload = function(){
    var textareaBgColor = document.getElementById('background-color-input'),
        textareColor = document.getElementById('text-color-input'),
        textarea = document.getElementById('textarea');

    textareaBgColor.addEventListener('change', function(){
        textarea.style.backgroundColor = textareaBgColor.value;
    });

    textareColor.addEventListener('change', function(){
        textarea.style.color = textareColor.value;
    });
};