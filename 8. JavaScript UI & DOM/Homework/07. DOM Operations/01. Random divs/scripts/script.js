function getRandomInt(min, max) {
    min = parseInt(min);
    max = parseInt(max);

    if (!isNumber(min)) {
        return 0;
    }

    if (!isNumber(max)) {
        max = min;
        min = 0;
    }

    if (min > max) {
        return 0;
    }

    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function isNumber(n) {
    return !isNaN(parseFloat(n)) && isFinite(n);
}

function getRandomColor(){
//    return (Math.random()*0xFFFFFF<0).toString(16);
    return Math.random().toString(16).substr(-6);
}

var POSITIONS = ['absolute', 'static', 'fixed', 'relative', 'initial', 'inherit'];

function generateRandomDivs(number){
    var div = document.createElement('div'),
        width,
        height,
        backgroundColor,
        color,
        top,
        left,
        content = document.createElement('strong'),
        border,
        borderRadius,
        borderColor,
        borderWidht;

    content.innerHTML = 'div';
    div.appendChild(content);
    div.style.position = 'absolute';

    var fragment = document.createDocumentFragment();

    for (var i = 0; i < number; i++) {
        width = getRandomInt(20, 100)+'px';
        height = getRandomInt(20, 100)+'px';
        backgroundColor = '#' + getRandomColor();
        color = '#' + getRandomColor();
        top = getRandomInt(50, 400) + 'px';
        left = getRandomInt(0,800) + 'px';
        border = getRandomInt(0, 10) + 'px';
        borderRadius = getRandomInt(0, 30) + 'px';
        borderColor = '#' + getRandomColor();
        borderWidht = getRandomInt(0, 10) + 'px';

        div.style.width = width;
        div.style.height = height;
        div.style.backgroundColor = backgroundColor;
        div.style.color = color;
        div.style.top = top;
        div.style.left = left;
        div.style.border = border;
        div.style.borderRadius = borderRadius;
        div.style.borderColor = borderColor;
        div.style.borderWidth = borderWidht;
        div.style.borderStyle = 'solid';
        div.style.textAlign = 'center';

        fragment.appendChild(div.cloneNode(true));
    }

    var container = document.getElementById('wrapper');
    container.appendChild(fragment);
}

window.onload = function (){

    var number = document.getElementById('input-divs-number');
    document.getElementById('generate-divs-button').addEventListener('click', function(){
        generateRandomDivs(number.value);
    });
//    var divs = generateRandomDivs(250);

};
