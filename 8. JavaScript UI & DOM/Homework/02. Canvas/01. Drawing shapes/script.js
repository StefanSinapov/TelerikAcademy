window.onload = function() {
	var canvas = document.getElementById('the-canvas');
	var canvasCtx = canvas.getContext('2d');


	var bikeColors = {
		fill: "90CAD7",
		stroke: "327D8F"
	};

	var faceColors = {
		fill: "90CAD7",
		stroke: "20525D"
	};

	var hatColors = {
		fill: "396693",
		stroke: "252422"
	};

	var houseColors = {
		fill: "975B5B",
		stroke: "000000"
	};

	drawFace(canvasCtx, faceColors, hatColors);
	drawBike(canvasCtx, bikeColors);
	drawHouse(canvasCtx, houseColors);
}

function drawFace(canvasCtx, faceColors, hatColors) {
	var x = 100,
		y = 150;

	// Head
	canvasCtx.fillStyle = faceColors.fill;
	canvasCtx.strokeStyle = faceColors.stroke;
	canvasCtx.lineWidth = 2;
	canvasCtx.beginPath();
	canvasCtx.arc(x, y, 60, 315 * Math.PI / 180, 225 * Math.PI / 180);
	canvasCtx.fill();
	canvasCtx.stroke();

	// Nose
	canvasCtx.beginPath();
	canvasCtx.moveTo(x - 5, y + 10);
	canvasCtx.lineTo(x - 20, y + 10);
	canvasCtx.lineTo(x - 5, y - 15);
	canvasCtx.stroke();

	// Mouth
	canvasCtx.save();
	canvasCtx.rotate(Math.PI / 17);
	drawEllipse(canvasCtx, x - 60, y + 15, 8, 0, 360, 3);
	canvasCtx.stroke();
	canvasCtx.restore();

	// Eyes
	canvasCtx.lineWidth = 2;
	drawEllipse(canvasCtx, x - 55, y - 17, 7, 0, 360, 1.5);
	canvasCtx.stroke();
	drawEllipse(canvasCtx, x - 23, y - 17, 7, 0, 360, 1.5);
	canvasCtx.stroke();

	// Eye balls
	canvasCtx.fillStyle = faceColors.stroke;
	drawEllipse(canvasCtx, x + 30, y - 17, 6, 0, 360, 0.5); //+41
	canvasCtx.fill();
	drawEllipse(canvasCtx, x + 125, y - 17, 6, 0, 360, 0.5);
	canvasCtx.fill();

	// Hat
	canvasCtx.lineWidth = 3;
	canvasCtx.fillStyle = hatColors.fill;
	canvasCtx.strokeStyle = hatColors.stroke;

	drawEllipse(canvasCtx, x - 80, y - 55, 16, 0, 360, 5);
	canvasCtx.fill();
	canvasCtx.stroke();

	drawEllipse(canvasCtx, x - 65, y - 65, 15, 0, 360, 3);
	canvasCtx.fill();
	canvasCtx.stroke();

	canvasCtx.beginPath()
	canvasCtx.fillRect(x - 40, y - 130, 90, 65); //rect
	canvasCtx.moveTo(x - 40, y - 130);
	canvasCtx.lineTo(x - 40, y - 65);
	canvasCtx.moveTo(x + 50, y - 130);
	canvasCtx.lineTo(x + 50, y - 65);
	canvasCtx.stroke();

	drawEllipse(canvasCtx, x - 65, y - 130, 15, 0, 360, 3);
	canvasCtx.fill();
	canvasCtx.stroke();
}

function drawBike(canvasCtx, colors) {
	var x = 55;
	var y = canvasCtx.canvas.clientHeight - 100;
	canvasCtx.lineWidth = 2;


	canvasCtx.fillStyle = colors.fill;
	canvasCtx.strokeStyle = colors.stroke;

	//wheels
	canvasCtx.beginPath();
	var radius = 50;
	canvasCtx.arc(x, y, radius, 0, 2 * Math.PI);
	canvasCtx.fill();
	canvasCtx.stroke();
	canvasCtx.save();
	canvasCtx.lineWidth = 4;
	canvasCtx.beginPath();
	canvasCtx.arc(x + 180, y, radius, 0, 2 * Math.PI);
	canvasCtx.stroke();
	canvasCtx.fill();
	canvasCtx.restore();


	//rama
	canvasCtx.beginPath();
	canvasCtx.moveTo(x, y);
	canvasCtx.lineTo(x + 80, y);
	canvasCtx.lineTo(x + 165, y - 65);
	canvasCtx.lineTo(x + 55, y - 65); //under the seat
	canvasCtx.lineTo(x + 40, y - 95);
	canvasCtx.lineTo(x + 15, y - 95);
	canvasCtx.lineTo(x + 65, y - 95);
	canvasCtx.moveTo(x + 55, y - 65);
	canvasCtx.lineTo(x, y);
	canvasCtx.moveTo(x + 55, y - 65);
	canvasCtx.lineTo(x + 80, y); //pedals
	canvasCtx.stroke();
	canvasCtx.beginPath();
	canvasCtx.arc(x + 80, y, 15, 0, 2 * Math.PI);
	canvasCtx.moveTo(x + 70, y - 10);
	canvasCtx.lineTo(x + 55, y - 25);
	canvasCtx.moveTo(x + 90, y + 10);
	canvasCtx.lineTo(x + 105, y + 25);
	canvasCtx.stroke();

	//steering wheel
	canvasCtx.beginPath();
	canvasCtx.moveTo(x + 180, y);
	canvasCtx.lineTo(x + 159, y - 100);
	canvasCtx.moveTo(x + 159, y - 100);
	canvasCtx.lineTo(x + 115, y - 90);
	canvasCtx.moveTo(x + 159, y - 100);
	canvasCtx.lineTo(x + 185, y - 130);
	canvasCtx.stroke();
}

function drawHouse(canvasCtx, houseColors) {
	var x = 400,
		y = 160;
	canvasCtx.fillStyle = houseColors.fill;
	canvasCtx.strokeStyle = houseColors.stroke;
	canvasCtx.lineWidth = 3;

	// Body
	canvasCtx.fillRect(x, y, 320, 220);
	canvasCtx.strokeRect(x, y, 320, 220);

	// Door
	canvasCtx.beginPath();
	canvasCtx.moveTo(x + 40, y + 220);
	canvasCtx.lineTo(x + 40, y + 140);
	canvasCtx.moveTo(x + 120, y + 220);
	canvasCtx.lineTo(x + 120, y + 140);
	canvasCtx.stroke();
	drawEllipse(canvasCtx, x - 160, y + 140, 20, Math.PI, 0, 2);
	canvasCtx.moveTo(x + 80, y + 220);
	canvasCtx.lineTo(x + 80, y + 120);
	canvasCtx.stroke();
	drawEllipse(canvasCtx, x + 65, y + 190, 4, 0, 360, 1);
	canvasCtx.stroke();
	drawEllipse(canvasCtx, x + 95, y + 190, 4, 0, 360, 1);
	canvasCtx.stroke();

	//windows
	drawWindow(canvasCtx, x + 30, y + 30, houseColors);
	drawWindow(canvasCtx, x + 180, y + 30, houseColors);
	drawWindow(canvasCtx, x + 180, y + 120, houseColors);

	//reset colors;
	canvasCtx.fillStyle = houseColors.fill;
	canvasCtx.strokeStyle = houseColors.stroke;

	// Roof
	canvasCtx.beginPath();
	canvasCtx.moveTo(x, y);
	canvasCtx.lineTo(x + 160, y - 150);
	canvasCtx.lineTo(x + 319, y);
	canvasCtx.fill();
	canvasCtx.lineTo(x, y);
	canvasCtx.stroke();

	// // Chimney
	canvasCtx.beginPath();
	canvasCtx.moveTo(x + 210, y - 120);
	canvasCtx.lineTo(x + 210, y - 50);
	canvasCtx.moveTo(x + 250, y - 50);
	canvasCtx.lineTo(x + 250, y - 120);
	canvasCtx.fillRect(x+210, y-120, 40, 70);
	canvasCtx.stroke();
	canvasCtx.lineWidth=5;
	drawEllipse(canvasCtx, x-190, y-120, 6.5, 0, 360, 3);
	canvasCtx.stroke();
	canvasCtx.fill();
}

function drawWindow(canvasCtx, x, y, windowColors) {
	canvasCtx.fillStyle = windowColors.stroke;
	canvasCtx.strokeStyle = windowColors.fill;

	canvasCtx.beginPath();
	canvasCtx.fillRect(x, y, 110, 70);
	canvasCtx.moveTo(x + 55, y);
	canvasCtx.lineTo(x + 55, y + 70);
	canvasCtx.moveTo(x, y + 35);
	canvasCtx.lineTo(x + 120, y + 35);
	canvasCtx.stroke();
}

function applyStyles(canvasCtx, fillStyle, strokeStyle) {
	'use strict';
	canvasCtx.fillStyle = fillStyle;
	canvasCtx.strokeStyle = strokeStyle;
	canvasCtx.fill();
	canvasCtx.stroke();
}

function drawEllipse(canvasCtx, x, y, radius, from, to, scaleX) {
	'use strict';
	canvasCtx.save();
	canvasCtx.scale(scaleX, 1);
	canvasCtx.beginPath();
	canvasCtx.arc(x, y, radius, from, to);
	canvasCtx.restore();
}