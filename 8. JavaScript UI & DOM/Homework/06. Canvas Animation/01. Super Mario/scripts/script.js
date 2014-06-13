/**
 * Created by Stefan on 12.6.2014 г..
 */

var mario,
    marioImage,
    backgroundImage,
    canvas,
    paper;

function gameLoop () {

    window.requestAnimationFrame(gameLoop);

    mario.update();
    mario.render();
}

function sprite (options) {

    var that = {},
        frameIndex = 0,
        tickCount = 0,
        ticksPerFrame = options.ticksPerFrame || 0,
        numberOfFrames = options.numberOfFrames || 1;

    that.context = options.context;
    that.width = options.width;
    that.height = options.height;
    that.image = options.image;
    that.stepSpeed = options.stepSpeed;
    that.x = 0;
    that.y = that.context.canvas.height - that.height * 1.6;

    that.update = function () {

        tickCount += 1;

        if (tickCount > ticksPerFrame) {

            tickCount = 0;

            // If the current frame index is in range
            if (frameIndex < numberOfFrames - 1) {
                // Go to the next frame
                frameIndex += 1;
            } else {
                frameIndex = 0;
            }
        }

        if(that.x < that.context.canvas.width)
        {
            that.x += that.stepSpeed;
        }
        else{
            that.x = 0;
        }



    };

    that.render = function () {

        // Clear the canvas
        that.context.clearRect(that.x - this.stepSpeed, that.y, that.width, that.height);

        // Draw the animation
        that.context.drawImage(
            that.image,
                frameIndex * that.width / numberOfFrames,
            0,
                that.width / numberOfFrames,
            that.height,
            that.x,
            that.y,
                that.width / numberOfFrames,
            that.height);
    };

    return that;
}

window.onload = function () {

    // Get canvas
//    paper = new Raphael(0, 0, window.innerWidth, window.innerHeight);
//    paper.image("./images/background-mario.png", 0, 0, window.innerWidth, window.innerHeight);

    /*var svgNS = 'http://www.w3.org/2000/svg';
    var svg = document.getElementById('svg-container');
    var backgroundImg = document.createElementNS(svgNS, 'image');
    backgroundImg.setAttribute('x', 0);
    backgroundImg.setAttribute('y', 0);
    backgroundImg.setAttribute('width', window.innerWidth);
    backgroundImg.setAttribute('height', window.innerHeight);
    backgroundImg.setAttribute('src', 'images/coin-sprite-animation.png');
    svg.appendChild(backgroundImg);*/


    canvas = document.getElementById("canvas-container");
    canvas.width  = window.innerWidth;
    canvas.height = window.innerHeight;



    // Create sprite sheet
    marioImage = new Image();

    // Create sprite
    mario = sprite({
        context: canvas.getContext("2d"),
        width: 189,
        height: 126,
        image: marioImage,
        numberOfFrames: 3,
        ticksPerFrame: 4,
        stepSpeed: 5
    });

    // Load sprite sheet
    marioImage.addEventListener("load", gameLoop);
    marioImage.src = "./images/walking-mario-sprite.png";
};