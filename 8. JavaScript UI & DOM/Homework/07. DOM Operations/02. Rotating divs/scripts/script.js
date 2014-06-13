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


function moveDivs(ballContainer) {
    var angle = 0, width = 150, height = 150;
    var step = 2 * Math.PI / ballContainer.children.length;

    setNewCoords();

    function setNewCoords() {
        for (var i = 0; i < ballContainer.children.length; i++) {
            var x = Math.cos(angle + (i * step)) * width;
            var y = Math.sin(angle + (i * step)) * height;

            ballContainer.children[i].style.left = (x + 420) + 'px';
            ballContainer.children[i].style.top = (y + 300) + 'px';
        }

        angle = (angle + 0.02) % (2 * Math.PI);

        setTimeout(setNewCoords, 15);
    }
}

function includeDivs(initialCount) {
    var count = initialCount || 5;
    var container = document.getElementById('wrapper');
    var ballContainer = document.createElement('div');
    ballContainer.id = 'ball-container';

    for (var i = 0; i < count; i++) {
        ballContainer.appendChild(generateDiv());
    }
    container.appendChild(ballContainer);

    moveDivs(ballContainer);
}

function generateDiv() {
    var div = document.createElement('div');
    div.style.position = 'absolute';
    div.style.width = '60px';
    div.style.height = '60px';
    div.style.backgroundColor = '#' + getRandomColor();
    div.style.borderRadius = '50px';
    div.style.borderColor = "#" + getRandomColor();
    div.style.borderWidth =  getRandomInt(5,10)+'px';
    div.style.borderStyle = 'solid';
    return div;
}

window.onload = function (){
    includeDivs();
};
