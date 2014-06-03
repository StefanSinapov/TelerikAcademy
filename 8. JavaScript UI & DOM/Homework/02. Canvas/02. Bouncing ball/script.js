window.onload = function () {
	var canvas = document.getElementById('the-canvas');
	var canvasCtx = canvas.getContext('2d');
	var ballCollors = {
		fill: "C56210",
		stroke: "fff"
	};

	animateBall(canvasCtx, canvas, ballCollors);
}

function animateBall(canvasCtx, canvas, ballCollors)
{
	var radius = 20;
    var startX = radius;
    var startY = radius + 10;
    var changeX = 10;
    var changeY = 10;
    var canvasWidth = canvas.clientWidth;
    var canvasHeight = canvas.clientHeight;
    canvasCtx.strokeStyle = ballCollors.stroke;
    canvasCtx.fillStyle = "yellowgreen"

     function moveCircle() {
        canvasCtx.clearRect(0, 0, canvasCtx.canvas.width, canvasCtx.canvas.height);
        drawBall(canvasCtx, startX, startY, radius, 0, 360);

        canvasCtx.stroke();
        canvasCtx.fill();

        startX += changeX;
        startY += changeY;

        if (startX <= radius || startX >= canvasWidth - radius) {
            changeX *= -1;
            PlaySound();
        }

        if (startY <= radius || startY >= canvasHeight - radius) {
            changeY *= -1;
            PlaySound();
        }

        requestAnimationFrame(moveCircle, 10);
    }

    requestAnimationFrame(moveCircle);
}

function PlaySound() {
 	var sound = document.getElementById("bounce-sound");
  	sound.play();
}

function drawBall(canvasCtx, x, y, radius, from, to) {
	canvasCtx.beginPath();
	canvasCtx.arc(x, y, radius, from, to);
}