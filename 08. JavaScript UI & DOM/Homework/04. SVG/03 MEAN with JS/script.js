window.onload = function() {
	var svgNS = 'http://www.w3.org/2000/svg';
	var svgID = 'svg-container';
	drawScreen(svgNS, svgID)
};

function drawScreen(svgNS, svgID) {
	// M
	drawText(svgNS, svgID, 'M', 50, 140, '#3E3F37', '40px', 'Arial', 'bold');
	drawCircle(svgNS, svgID, 160, 125, 60, '#3E3F37', 'none');
	drawPath(svgNS, svgID,
		'M177,137.501c0-1.44-11.54-3-17-3c-5.45,0-17,1.56-17,3c0-12.51,11.55-39,17-39 C165.46,98.501,177,124.991,177,137.501z',
		'#5EB14A');
	drawPath(svgNS, svgID,
		'M177,137.501c0-12.492-11.546-39-17-39v36C165.454,134.501,177,136.541,177,137.501z',
		'#449644');

	// E
	drawText(svgNS, svgID, 'E', 53, 210, "#282827", '40px', 'Arial', 'bold');
	drawCircle(svgNS, svgID, 160, 195, 60, "#282827", 'none');
	drawText(svgNS, svgID, 'express', 111, 204, 'white', '28px', 'Arial', 'normal');

	//A
	drawText(svgNS, svgID, 'A', 52, 280, '#E23337', '40px', 'Arial', 'bold');
	drawCircle(svgNS, svgID, 160, 265, 60, '#E23337', 'none');
	drawPolygon(svgNS, svgID, '167.621,276.833 160.933,262.184 160.933,245.167 175.058,276.833', '#B3B3B3');
	drawPolygon(svgNS, svgID,
		'126.121,251.75 161.433,237.188 195.246,251.75 191.871,284.813 188.371,282.25 191.308,254.25 161.433,242.125 130.933,254.25 133.871,283.563 130.933,284.813',
		'#B1B8B8');
	drawPolygon(svgNS, svgID, '155.371,276.833 147.433,276.833 160.933,245.167 160.933,262.184', '#F1F1F1');

	//N
	drawText(svgNS, svgID, 'N', 50, 350, '#8EC74E', '40px', 'Arial', 'bold');
	drawCircle(svgNS, svgID, 160, 335, 60, '#8EC74E', 'none');
	drawPolyline(svgNS, svgID,
		'173.937,327.955 166.104,332.955 166.104,343.621 173.937,348.288 182.937,342.788 182.937,319.121 178.104,315.621 178.104,329.788 173.937,327.955 173.937,334.955 171.104,338.182 173.937,341.288 176.958,338.182 173.937,334.955',
		'#3E3F37');
	drawPolygon(svgNS, svgID,
		'160.683,343.517 151.312,349.076 141.812,343.74 141.683,332.846 151.053,327.286 160.553,332.622',
		'#FFFFFF');
	drawPolygon(svgNS, svgID,
		'176.083,339.176 174.034,340.446 171.909,339.307 171.833,336.896 173.882,335.626 176.007,336.766',
		'#FFFFFF');
	drawPolygon(svgNS, svgID,
		'123.333,337.119 127.417,335.035 131.5,337.119 131.5,344.453 137.5,346.953 138,346.953 138,333.619 127.167,327.286 117,333.619 117,346.953 118,346.953 123.333,344.453',
		'#3E3F37');
	drawPolygon(svgNS, svgID,
		'199.823,324.098 189.948,330.598 189.948,340.348 198.448,345.681 204.573,343.014 196.823,337.723 196.823,333.098 199.823,331.223 203.891,334.25 208.073,332.223',
		'#3E3F37');
	drawPolygon(svgNS, svgID,
		'196.813,333.109 196.813,337.734 198.736,339.048 203.88,334.262 199.813,331.234',
		'#FFFFFF');
}

function drawCircle(svgNS, svgID, cx, cy, radius, fill, stroke) {
	var circle = document.createElementNS(svgNS, 'circle');
	circle.setAttribute('cx', cx);
	circle.setAttribute('cy', cy);
	circle.setAttribute('r', radius);
	circle.setAttribute('fill', fill);
	circle.setAttribute('stroke', stroke);
	document.getElementById(svgID).appendChild(circle);
}

function drawText(svgNS, svgID, content, x, y, color, fontSize, fontFamily, fontWeight) {
	var text = document.createElementNS(svgNS, 'text');
	text.setAttribute('x', x);
	text.setAttribute('y', y);
	text.setAttribute('fill', color);
	text.setAttribute('font-size', fontSize);
	text.setAttribute('font-family', fontFamily);
	text.setAttribute('font-weight', fontWeight);
	var textNode = document.createTextNode(content);
	text.appendChild(textNode);
	document.getElementById(svgID).appendChild(text);
}

function drawPath(svgNS, svgID, directions, fill) {
	var path = document.createElementNS(svgNS, 'path');
	path.setAttribute('d', directions);
	path.setAttribute('fill', fill);
	path.setAttribute('stroke', 'none');
	document.getElementById(svgID).appendChild(path);
}

function drawPolygon(svgNS, svgID, points, fill) {
	var polygon = document.createElementNS(svgNS, 'polygon');
	polygon.setAttribute('points', points);
	polygon.setAttribute('fill', fill);
	document.getElementById(svgID).appendChild(polygon);
}

function drawPolyline(svgNS, svgID, points, fill) {
	var polyline = document.createElementNS(svgNS, 'polyline');
	polyline.setAttribute('points', points);
	polyline.setAttribute('fill', fill);
	document.getElementById(svgID).appendChild(polyline);
}